using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base_Conhecimento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base_Conhecimento_Web.Controllers
{
    public class LoginController : Controller
    {
        private FachadaBase fachada = FachadaBase.getInstance();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            if (fachada.Login(usuario.usuarioID) == null)
            {
                ModelState.AddModelError("", "Usuário ou senha inválidos");
                return View("Index");
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }



    }
}

