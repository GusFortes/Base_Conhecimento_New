using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Base_Conhecimento.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Base_Conhecimento.Controllers
{
    public class HomeController : Controller
    {
        private FachadaBase fachada = FachadaBase.getInstance();
        public IActionResult Index()
        {
            
            List<Chamado> chamados = fachada.consultaTodosChamados();
            List <ChamadoUserViewModel> usuariochamados = new List<ChamadoUserViewModel>();
            ChamadoUserViewModel chamadoUser = new ChamadoUserViewModel();
            

            return View(chamados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Solucao(String id)
        {
            List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();
            ChamadoSolucaoViewModel chamadoSolucao = new ChamadoSolucaoViewModel();
            chamadoSolucao.chamadoModel = fachada.consultaChamadoId(id);
            chamadoSolucao.solucaoModel = fachada.consultaSolucaoId(chamadoSolucao.chamadoModel.solucaoID);

            cs.Add(chamadoSolucao);

            return View("Solucao", cs);
        }

        public IActionResult Delete(String file)
        {
            //DeleteFile(file);
            return RedirectToAction("Index", "Home");

        }

        private void DeleteFile(String file)
        {
           // string nomearquivo = file.FileName;
            //var arquivo = Path.Combine("C:/Users/gus_f/Desktop/Base/Base_Conhecimento_New/Base_Conhecimento_Web/wwwroot/Base/", nomearquivo);
            //if (System.IO.File.Exists(arquivo))
            //{
            //    System.IO.File.Delete(arquivo);
            //}
        }
    }
}
