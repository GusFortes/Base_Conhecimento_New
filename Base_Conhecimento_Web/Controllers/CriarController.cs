using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Base_Conhecimento;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Base_Conhecimento_Web.Controllers
{
    public class CriarController : Controller
    {
        private FachadaBase fachada = FachadaBase.getInstance();
        public static string id = "";

        public IActionResult Index()
        {
            Usuario user = new Usuario();

            ChamadoSolucaoViewModel chamadoSolucao = new ChamadoSolucaoViewModel();

            if (fachada.Login(user).nome == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (fachada.retornaUsuario().nivel)
                {
                    return View(chamadoSolucao);
                }
                else
                {
                    return View("Erro");
                }
            }
        }


        [HttpPost]
        public IActionResult Salvar(ChamadoSolucaoViewModel chamadoSolucao)
        {
            if (fachada.consultaChamadoId(chamadoSolucao.chamadoModel.chamadoID).chamadoID != null)
            {
                ModelState.AddModelError("chamadoModel.chamadoID", "Esse código de chamado já está cadastrado. Favor, verifique.");
            }

            if (!chamadoSolucao.solucaoModel.visualizacao.Equals("Analista") && !chamadoSolucao.solucaoModel.visualizacao.Equals("Cliente"))
            {
                ModelState.AddModelError("solucaoModel.visualizacao", "Escolha uma opção");
            }



            if (ModelState.IsValid == false)
            {
                return View("Index", chamadoSolucao);
            }

            Solucao sol = chamadoSolucao.solucaoModel;
            Chamado cham = chamadoSolucao.chamadoModel;
            fachada.registrarChamado(cham);
            ChamadoSolucaoViewModel chamadoSolucaoView = fachada.persistirInformacoes(sol, cham);

            if (chamadoSolucaoView.solucaoModel != null && chamadoSolucaoView.chamadoModel != null)
            {
                List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();
                cs.Add(chamadoSolucao);
                UploadedFileSolucao(chamadoSolucaoView.solucaoModel);
                UploadedFileChamado(chamadoSolucaoView.chamadoModel);
                return View("Salvar", cs);
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpPost]
        public IActionResult Voltar()
        {
            return RedirectToAction("Index", "Home");
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
                }
            }

        }

    }

}

