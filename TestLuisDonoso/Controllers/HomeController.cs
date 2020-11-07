using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLuisDonoso.Models;
using TestLuisDonoso.Infraestructura;

namespace TestLuisDonoso.Controllers
{
    [CustomAuthenticationFilter]  

    public class HomeController : Controller
    {
        /// <summary>
        /// Página principal del sitio
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        ///  Envía a página de "no Autorizado"
        /// </summary>
        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "Un Authorized Page!";

            return View();
        }
    }
}