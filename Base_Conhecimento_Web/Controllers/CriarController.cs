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
    [Authorize]
    public class CriarController : Controller
    {
        private FachadaBase fachada = FachadaBase.getInstance();


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Avancar(Chamado cham)
        {


            fachada.registrarChamado(cham);
            return View("Solucao");
        }

        [HttpPost]
        public IActionResult Salvar(Solucao sol)
        {


            if (fachada.persistirSolucao(sol) != null)
            {

                List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();
                ChamadoSolucaoViewModel chamadoSolucao = new ChamadoSolucaoViewModel();
                chamadoSolucao.chamadoModel = fachada.retornarChamado();
                chamadoSolucao.solucaoModel = sol;
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

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create("C:/Users/gus_f/AppData/Local"))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size });
        }



        private void UploadedFile(Solucao model)
        {
            string uniqueFileName = null;

            if (model.arquivos != null)
            {
                string uploadsFolder = Path.Combine("C:/Users/gus_f/AppData/Local");
                uniqueFileName = model.solucaoID + "_" + model.arquivos.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.arquivos.CopyTo(fileStream);
                }
            }

        }
    }
}

