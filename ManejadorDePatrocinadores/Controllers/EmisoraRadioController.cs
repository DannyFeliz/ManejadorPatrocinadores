using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManejadorDePatrocinadores.Models;

namespace ManejadorDePatrocinadores.Controllers
{
    public class EmisoraRadioController : Controller
    {
        /// <summary>
        /// Muestra el listado de todas las emisoras
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {

            ViewData["rows"] = EmisoraRadio.obtenerTodas();

            return View();
        }

        /// <summary>
        /// Muestra el formulario de creación de emisoras de radios
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            ViewData["provinces"] = Utils.Helpers.ProvincesList();
            ViewData["directoresLista"] = Director.obtenerTodos();
            return View();
        }


        /// <summary>
        /// Inserta una nueva emisora de radio
        /// </summary>
        /// <returns>void</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
//            try
//            {
                // TODO: Add insert logic here

                using (var connection = Utils.Db.Connection())
                {
                    connection.Open();

                SqlCommand cmd = new SqlCommand("insertar_emisora_radio", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("nfi", collection.GetValue("nfi").AttemptedValue);
                    cmd.Parameters.AddWithValue("nombre", collection.GetValue("nombre").AttemptedValue);
                    cmd.Parameters.AddWithValue("direccion", collection.GetValue("direccion_postal").AttemptedValue);
                    cmd.Parameters.AddWithValue("director", collection.GetValue("director").AttemptedValue);
                    cmd.Parameters.AddWithValue("banda", collection.GetValue("banda_hertziana").AttemptedValue);
                    cmd.Parameters.AddWithValue("provincia", collection.GetValue("provincia").AttemptedValue);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                ViewData["rows"] = EmisoraRadio.obtenerTodas();
                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
        }

    }
}
