using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Base_Conhecimento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Base_Conhecimento_Web.Controllers
{
    public class AlterarController : Controller
    {
        private FachadaBase fachada = FachadaBase.getInstance();
        public static string id = "0";


        public IActionResult Index(Solucao sol)
        {
            Usuario user = new Usuario();

            if (fachada.Login(user).usuarioID == null )
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (fachada.retornaUsuario().nivel)
                {
                    return View(sol);
                }
                else
                {
                    return View("Erro");
                }
            }
        }

        [HttpPost]
        public IActionResult Consultar(Solucao sol)
        {
            int id = sol.solucaoID;
            List<Solucao> solucoes = new List<Solucao>();
            solucoes.Add(fachada.consultaSolucaoId(id));
            if (solucoes.Count > 0)
            {
                if (solucoes.First().solucaoID == 0)
                {
                    ModelState.AddModelError("solucaoID", "Solução não encontrada.");

                    return View("Index", sol);
                }

                return View("Resultado", solucoes);
            }
            else
            {
                ModelState.AddModelError("solucaoID", "Solução não encontrada.");

                return View("Index", sol);
            }
        }

        // GET: Solucao/Edit/5

        public IActionResult Alterar(int id)
        {

            ChamadoSolucaoViewModel solucaoChamado = new ChamadoSolucaoViewModel();

            solucaoChamado.solucaoModel = fachada.consultaSolucaoId(id);
            solucaoChamado.chamadoModel = fachada.consultaChamadoporIdSolucao(id);
            List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();
            cs.Add(solucaoChamado);

            return View("Alterar", solucaoChamado);


        }

        [HttpPost]
        public IActionResult Salvar(ChamadoSolucaoViewModel chamadoSolucao)
        {
            Chamado cham = fachada.alterarChamado(chamadoSolucao.chamadoModel);
            Solucao sol = fachada.alterarSolucao(chamadoSolucao.solucaoModel);

            if (cham != null && sol != null)
            {
                chamadoSolucao.chamadoModel = fachada.consultaChamadoporIdSolucao(cham.solucaoID);
                chamadoSolucao.solucaoModel = fachada.consultaSolucaoId(cham.solucaoID);
                List<ChamadoSolucaoViewModel> solucaoAlterada = new List<ChamadoSolucaoViewModel>();
                solucaoAlterada.Add(chamadoSolucao);
                UploadedFileSolucao(sol);
                UploadedFileChamado(cham);
                return View("SolucaoAlterada", solucaoAlterada);
            }
            else
            {
                return View("SemResultado");
            }
        }

        public ActionResult Delete(String nome)
        {

            if (nome == null) { }

            var arquivo = Path.Combine("wwwroot/Base/Chamado/" + nome);

            int id = 0;
            ChamadoSolucaoViewModel chamadoSolucao = new ChamadoSolucaoViewModel();
            List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();

            if (System.IO.File.Exists(arquivo))
            {
                chamadoSolucao = fachada.ExluirArquivoChamado(nome);
                cs.Add(chamadoSolucao);
                System.IO.File.Delete(arquivo);

                id = chamadoSolucao.chamadoModel.solucaoID;
            }

            return RedirectToAction("Alterar", "Alterar", new { id });
        }


        public ActionResult DeleteArquivoSolucao(String nome)
        {

            if (nome == null) { }

            var arquivo = Path.Combine("wwwroot/Base/Solucao/" + nome);

            int id = 0;
            ChamadoSolucaoViewModel chamadoSolucao = new ChamadoSolucaoViewModel();
            List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();

            if (System.IO.File.Exists(arquivo))
            {
                chamadoSolucao = fachada.ExluirArquivoSolucao(nome);
                cs.Add(chamadoSolucao);
                System.IO.File.Delete(arquivo);

                id = chamadoSolucao.chamadoModel.solucaoID;
            }

            return RedirectToAction("Alterar", "Alterar", new { id });
        }

        private void UploadedFileSolucao(Solucao model)
        {
            string uniqueFileName;

            if (model.arquivos != null)
            {
                foreach (IFormFile file in model.arquivos)
                {
                    string uploadsFolder = Path.Combine("wwwroot/Base/Solucao");
                    uniqueFileName = model.solucaoID + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    // File arquivo = (File)file;
                }
            }

        }
        private void UploadedFileChamado(Chamado model)
        {
            string uniqueFileName;

            if (model.arquivos != null)
            {
                foreach (IFormFile file in model.arquivos)
                {
                    string uploadsFolder = Path.Combine("wwwroot/Base/Chamado");
                    uniqueFileName = model.solucaoID + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    // File arquivo = (File)file;
                }
            }

        }








    }
}
