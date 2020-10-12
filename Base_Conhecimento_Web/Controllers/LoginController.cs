//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Base_Conhecimento_Negocio;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace Base_Conhecimento_Web.Controllers
//{
//    public class LoginController : Controller
//    {
//        [AllowAnonymous]
//        public ActionResult Login(string returnUrl)
//        {
//            ViewBag.ReturnUrl = returnUrl;
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public ActionResult Login(Usuario login, string returnUrl)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(login);
//            }

//            var achou = (login.nome == "ranieresilva" && login.usuarioID == "123");

//            if (achou)
//            {
//                FormsAuthentication.SetAuthCookie(login.nome, login.email);
//                if (Url.IsLocalUrl(returnUrl))
//                {
//                    return Redirect(returnUrl);
//                }
//                else
//                {
//                    RedirectToAction("Index", "Home");
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "Login inválido.");
//            }

//            return View(login);
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public ActionResult LogOff()
//        {
//            FormsAuthentication.SignOut();
//            return RedirectToAction("Index", "Home");
//        }
//    }
//}

