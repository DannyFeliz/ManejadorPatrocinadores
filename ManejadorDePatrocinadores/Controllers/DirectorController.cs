using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManejadorDePatrocinadores.Models;

namespace ManejadorDePatrocinadores.Controllers
{
    public class DirectorController : Controller
    {
        /// <summary>
        /// Muestra el listado de directores
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            ViewData["directores"] = Director.obtenerTodos();

            return View();
        }


        /// <summary>
        /// Muestra el formulario de creación directores
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Inserta un nuevo director
        /// Summary
        /// </summary>
        /// <returns>void</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            using (var connection = Utils.Db.Connection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("insertar_director", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nombre", collection.GetValue("nombre").AttemptedValue);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            ViewData["directores"] = Director.obtenerTodos();
            return RedirectToAction("Index");

        }
    }
}
