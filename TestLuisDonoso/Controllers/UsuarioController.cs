using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLuisDonoso.Infraestructura;
using TestLuisDonoso.Models;
using TestLuisDonoso.Util;

namespace TestLuisDonoso.Controllers
{
    
    public class UsuarioController : Controller
    {
        /// <summary>
        ///     Retorna vista principal con usuarios
        /// </summary>
        [CustomAuthenticationFilter]
        public ActionResult Index()
        {
            TestDB db = new TestDB();

            List<Usuario> listUsuarios = db.Usuario.ToList();

            return View(listUsuarios);
        }
        
        /// <summary>
        /// Retorna Vista para crear usuarios
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Método que inserta usuario en la BD
        /// </summary>
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            TestDB db = new TestDB();
            usuario.Password = Funciones.MD5Hash(usuario.Password);

            db.Usuario.Add(usuario);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}