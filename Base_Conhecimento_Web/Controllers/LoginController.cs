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
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            if (fachada.Login(usuario.usuarioID).usuarioID == 0)
            {
                ModelState.AddModelError("usuarioID", "Credenciais Inválidas. Favor, verifique."); ;
                return View("Index", usuario);
            }
            else
           {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            fachada.Logout();
            return RedirectToAction("Index", "Home");
        }



    }
}

