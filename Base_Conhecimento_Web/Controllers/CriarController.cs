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

        //public IActionResult Avancar(Chamado cham)
        //{
        //    fachada.registrarChamado(cham);
        //    return View("Solucao");
        //}

        [HttpPost]
        public IActionResult Salvar(ChamadoSolucaoViewModel chamadoSolucao)
        {
            Solucao sol = chamadoSolucao.solucaoModel;
            Chamado cham = chamadoSolucao.chamadoModel;
            fachada.registrarChamado(cham);
            if (fachada.persistirSolucao(sol) != null)
            {

                List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();
                ChamadoSolucaoViewModel chamadoSolucaoView = new ChamadoSolucaoViewModel();
                chamadoSolucaoView.chamadoModel = fachada.retornarChamado();
                chamadoSolucaoView.solucaoModel = sol;
                cs.Add(chamadoSolucao);
                UploadedFile(sol);
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
            return View("Index");
        }

        private void UploadedFile(Solucao model)
        {
            string uniqueFileName;

            if (model.arquivos != null)
            {
                foreach (IFormFile file in model.arquivos)
                {
                    string uploadsFolder = Path.Combine("C:/Users/gus_f/AppData/Local/Base");
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

