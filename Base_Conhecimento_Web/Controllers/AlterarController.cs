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
        public static int id = 0;


        public IActionResult Index()
        {
            Usuario user = fachada.Login(id);

            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
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
                return View("Resultado", solucoes);
            }
            else
            {
                return View("SemResultado");
            }
        }

        // GET: Solucao/Edit/5

        public IActionResult Alterar(int id)
        {

            ChamadoSolucaoViewModel solucaoChamado = new ChamadoSolucaoViewModel();

            solucaoChamado.solucaoModel = fachada.consultaSolucaoId(id);
            solucaoChamado.chamadoModel = fachada.consultaChamadoporId(id);
            List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();
            cs.Add(solucaoChamado);

            return View("Alterar", solucaoChamado);


        }

        [HttpPost]
        public IActionResult Salvar(ChamadoSolucaoViewModel chamadoSolucao)
        {
            Chamado cham = fachada.alterarChamado(chamadoSolucao.chamadoModel);
            Solucao sol = fachada.alterarSolucao(chamadoSolucao.solucaoModel);


            if ( cham!=null && sol!=null )
            {
                chamadoSolucao.chamadoModel = cham;
                chamadoSolucao.solucaoModel = sol;
                List<ChamadoSolucaoViewModel> solucaoAlterada = new List<ChamadoSolucaoViewModel>();
                solucaoAlterada.Add(chamadoSolucao);
                UploadedFileSolucao(chamadoSolucao.solucaoModel);
                UploadedFileChamado(chamadoSolucao.chamadoModel);
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

            var arquivo = Path.Combine("C:/Users/gus_f/Desktop/Base/Base_Conhecimento_New/Base_Conhecimento_Web/wwwroot/Base/Chamado/" + nome);

            int id = 0;
            ChamadoSolucaoViewModel chamadoSolucao = new ChamadoSolucaoViewModel();
            List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();

            if (System.IO.File.Exists(arquivo))
            {
                chamadoSolucao = fachada.ExluirArquivo(nome);
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
                    string uploadsFolder = Path.Combine("C:/Users/gus_f/Desktop/Base/Base_Conhecimento_New/Base_Conhecimento_Web/wwwroot/Base/");
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
                    string uploadsFolder = Path.Combine("C:/Users/gus_f/Desktop/Base/Base_Conhecimento_New/Base_Conhecimento_Web/wwwroot/Base/Chamado");
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
