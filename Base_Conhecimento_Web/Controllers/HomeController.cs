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
            Usuario usuarioLogado = fachada.retornaUsuario();
            List<ChamadoSolucaoUserViewModel> cs = new List<ChamadoSolucaoUserViewModel>();

            if (chamados == null || chamados.Count == 0)
            {
                ChamadoSolucaoUserViewModel chamadoSolucaoAux = new ChamadoSolucaoUserViewModel();
                chamadoSolucaoAux.usuarioModel = usuarioLogado;
                cs.Add(chamadoSolucaoAux);
            }
            else
            {

                foreach (Chamado c in chamados)
                {
                    ChamadoSolucaoUserViewModel chamadoSolucao = new ChamadoSolucaoUserViewModel();
                    chamadoSolucao.solucaoModel = fachada.consultaSolucaoId(c.solucaoID);
                    chamadoSolucao.chamadoModel = c;
                    chamadoSolucao.usuarioModel = usuarioLogado;
                    if (chamadoSolucao.solucaoModel.status.Equals("Ativo"))
                    {
                        cs.Add(chamadoSolucao);
                    }
                }
            }

            return View(cs);
        }

        public IActionResult Login()
        {
            return RedirectToAction("Index", "Login"); ;
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Logout", "Login"); ;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Solucao(String id, bool curtida)
        {
            List<ChamadoSolucaoViewModel> cs = new List<ChamadoSolucaoViewModel>();
            ChamadoSolucaoViewModel chamadoSolucao = new ChamadoSolucaoViewModel();
            chamadoSolucao.chamadoModel = fachada.consultaChamadoId(id);
            chamadoSolucao.solucaoModel = fachada.consultaSolucaoId(chamadoSolucao.chamadoModel.solucaoID);

            if (curtida == true)
            {

            }
            else
            {
                fachada.incrementarVisitas(chamadoSolucao.solucaoModel.solucaoID);
            }
            cs.Add(chamadoSolucao);

            return View("Solucao", cs);
        }

        public IActionResult Like(int solucao)
        {
            fachada.incrementarCurtidas(solucao);
            Chamado cham = fachada.consultaChamadoporIdSolucao(solucao);
            String id = cham.chamadoID;
            bool curtida = true;
            return RedirectToAction("Solucao", "Home", new { id, curtida });

        }
    }
}
