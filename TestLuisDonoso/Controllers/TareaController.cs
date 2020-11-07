using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLuisDonoso.Infraestructura;
using TestLuisDonoso.Models;
using TestLuisDonoso.ViewModels;

namespace TestLuisDonoso.Controllers
{
    [CustomAuthenticationFilter]
    public class TareaController : Controller
    {
        /// <summary>
        ///     Envía a pagina con lista de tareas.
        /// </summary>
        public ActionResult Index()
        {
            TestDB db = new TestDB();

            List<TareaVM> listTareasVM = new List<TareaVM>();
            List<Tarea> listTareas = db.Tarea.ToList();

            foreach (var item in listTareas)
            {
                TareaVM tarea = new TareaVM();
                tarea.IDTarea = item.ID;
                tarea.EstadoTarea = item.Estado.Descripcion;
                tarea.EstadoTareaID = item.EstadoID;
                tarea.NombreTarea = item.Nombre;
                tarea.DescripcionTarea = item.Descripcion;
                tarea.Usuario = item.Usuario.Nombre;

                listTareasVM.Add(tarea);
            }

            return View(listTareasVM);
        }

        /// <summary>
        ///     Método que actualiza estado de la tarea como "Resuelto
        /// </summary>
        /// <param name="idTarea">ID de la tarea</param>
        [HttpGet]
        public ActionResult UpdateState(int idTarea)
        {
            TestDB db = new TestDB();
            Tarea tarea = db.Tarea.Find(idTarea);

            tarea.EstadoID = 2;

            db.Entry(tarea).State = EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }    

        /// <summary>
        ///  Retorna Vista para editar una tarea segun su id
        /// </summary>
        [HttpGet]
        public ActionResult Edit(int idTarea)
        {
            TestDB db = new TestDB();
            Tarea tarea = db.Tarea.Find(idTarea);

            CargaComboEstados();
            CargaComboUsuarios();
            
            return View(tarea);
        }

        /// <summary>
        ///  Método que actualiza Tarea
        /// </summary>
        [HttpPost]
        public ActionResult Update(Tarea model)
        {
            TestDB db = new TestDB();

            Tarea tarea = db.Tarea.Find(model.ID);
            tarea.EstadoID = model.EstadoID;
            
            db.Entry(tarea).State = EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        /// <summary>
        ///  Metodo que retorna vista para crear Tareas
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            CargaComboEstados();
            CargaComboUsuarios();

            return View();
        }

        /// <summary>
        /// Método que inserta la tarea en la vase de datos
        /// </summary>
        [HttpPost]
        public ActionResult Create(Tarea tarea)
        {
            TestDB db = new TestDB();

            db.Tarea.Add(tarea);
            db.SaveChanges();         
            
                
            return RedirectToAction("Index");
        }


        #region MetodosAuxiliares
        /// <summary>
        /// Carga ViewBag con información de los estados
        /// </summary>
        private void CargaComboEstados()
        {
            TestDB db = new TestDB();

            List<Estado> listaEstados = db.Estado.ToList();
            List<SelectListItem> selectListEstado = new List<SelectListItem>();


            foreach (var item in listaEstados)
            {
                selectListEstado.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.ID.ToString()
                });
            }
            db.Dispose();

            ViewBag.listEstado = selectListEstado;
        }

        /// <summary>
        /// Carga ViewBag con información de los usuarios
        /// </summary>
        private void CargaComboUsuarios()
        {
            TestDB db = new TestDB();

            List<Usuario> listaUsuarios = db.Usuario.ToList();
            List<SelectListItem> selectListUsuario = new List<SelectListItem>();

            foreach (var item in listaUsuarios)
            {
                selectListUsuario.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.UserName
                });
            }

            db.Dispose();

            ViewBag.listadoUsuarios = selectListUsuario;
        }
        #endregion
    }
}