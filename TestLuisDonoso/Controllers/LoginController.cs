using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLuisDonoso.Models;
using TestLuisDonoso.Util;

namespace TestLuisDonoso.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Envía a pagina de ingreso al sistema
        /// </summary>
        public ActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        /// <summary>
        ///  Registra el ingreso del usuario en el sisteam y lo guarda en session
        /// </summary>
        [HttpPost]
        public ActionResult LogIn(Usuario model)
        {
            TestDB db = new TestDB();
            Usuario usuario = db.Usuario.Find(model.UserName);
            db.Dispose();

            if(usuario != null)
            {
                if (usuario.Password == Funciones.MD5Hash(model.Password))
                {
                    HttpContext.Session["Usuario"] = usuario;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.Message = "Contraseña incorrecta";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.Message = "Usuario No existe.";
                return View("Index");
            }            
        }
    }
}