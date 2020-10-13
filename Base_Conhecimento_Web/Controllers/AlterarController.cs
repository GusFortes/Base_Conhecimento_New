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

            Solucao sol = new Solucao();
            sol = fachada.consultaSolucaoId(id);

            return View("Alterar", sol);


        }

        [HttpPost]
        public IActionResult Salvar(Solucao sol)
        {

            if (fachada.alterarSolucao(sol))
            {
                List<Solucao> solucaoAlterada = new List<Solucao>();
                solucaoAlterada.Add(sol);

                return View("SolucaoAlterada", solucaoAlterada);
            }
            else
            {
                return View("SemResultado");
            }
        }

    }
}
