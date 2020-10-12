using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base_Conhecimento;
using Microsoft.AspNetCore.Mvc;

namespace Base_Conhecimento_Web.Controllers
{
    public class ConsultaController : Controller
    {
        FachadaBase fachada = new FachadaBase();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Consultar(Solucao sol)
        {
            String problema = sol.descricao;
            List<Solucao> solucoes = fachada.consultaSolucoes(problema);
            if (solucoes.Count > 0)
            {
                return View("Resultado", solucoes);
            }
            else
            {
                return View("SemResultado");
            }

        }
    }
}
