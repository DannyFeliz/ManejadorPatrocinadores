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
    public class EmpresaMediosController : Controller
    {
        // GET: EmpresaMedios
        /// <summary>
        /// Muestra el listado de todas las empresas de medios
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            ViewData["empresasMedios"] = EmpresaMedio.obtenerTodas();
            

            return View();
        }


        // GET: EmpresaMedios/Create
        /// <summary>
        /// Muestra el formulario de creación de empresas de medios
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaMedios/Create
        /// <summary>
        /// Inserta una nueva empresa de medios
        /// </summary>
        /// <returns>void</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            using (var connection = Utils.Db.Connection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("insertar_empresa_medios", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nif", collection.GetValue("nif").AttemptedValue);
                cmd.Parameters.AddWithValue("nombre", collection.GetValue("nombre").AttemptedValue);
                cmd.Parameters.AddWithValue("direccion_postal", collection.GetValue("direccion_postal").AttemptedValue);
                cmd.Parameters.AddWithValue("director", collection.GetValue("director").AttemptedValue);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            ViewData["empresasMedios"] = EmpresaMedio.obtenerTodas();
            return RedirectToAction("Index");

        }
    }
}
