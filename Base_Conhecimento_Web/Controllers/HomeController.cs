﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Base_Conhecimento.Models;

namespace Base_Conhecimento.Controllers
{
    public class HomeController : Controller
    {
        private FachadaBase fachada = FachadaBase.getInstance();
        public IActionResult Index()
        {
            List<Solucao> solucoes = fachada.consultaTodasSolucoes();
            List<Chamado> chamados = fachada.consultaTodosChamados();
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
    }
}
