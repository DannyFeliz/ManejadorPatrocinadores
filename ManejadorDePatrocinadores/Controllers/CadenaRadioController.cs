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
    public class CadenaRadioController : Controller
    {

        /// <summary>
        /// Obtiene el listado de todas las cadenas de radio
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            ViewData["cadenasRadios"] = CadenaRadio.obtenerTodas();

            return View();
        }

        /// <summary>
        /// Muetras formulario de creación de Cadena de Radio
        /// Summary
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            ViewData["directoresLista"] = Director.obtenerTodos();
            ViewData["emisoraLista"] = EmisoraRadio.obtenerTodas();
            ViewData["empresaMediosLista"] = EmpresaMedio.obtenerTodas();

            return View();
        }

        /// <summary>
        /// Obtiene el listado de todos los programas de radio registrado
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult programs()
        {
            var connection = Utils.Db.Connection();
            var list = new List<ProgramaRadio>();

            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC lista_programa_radio";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        var emisoraRadio = new ProgramaRadio
                        {
                            id = Convert.ToInt32(row.GetValue(row.GetOrdinal("id"))),
                            dia = Convert.ToInt32(row.GetValue(row.GetOrdinal("dia"))),
                            hora_inicio = row.GetValue(row.GetOrdinal("hora_inicio")).ToString(),
                            hora_fin = row.GetValue(row.GetOrdinal("hora_fin")).ToString(),
                            nombre = row.GetValue(row.GetOrdinal("nombre")).ToString(),
                            responsable = row.GetValue(row.GetOrdinal("encargado")).ToString(),
                        };
                        list.Add(emisoraRadio);
                    }
                }
                connection.Close();
            }

            return Json(new { list }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Inserta una nueva cadena de radio junto a sus depedencias
        /// </summary>
        /// <param name="collection">Formulario</param>
        /// <returns>void</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            using (var connection = Utils.Db.Connection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("insertar_cadena_radio", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nombre_representativo", collection.GetValue("nombre_representativo").AttemptedValue);
                cmd.Parameters.AddWithValue("sede_central", collection.GetValue("sede_central").AttemptedValue);
                cmd.Parameters.AddWithValue("director", collection.GetValue("director").AttemptedValue);
                cmd.Parameters.AddWithValue("empresa_medios", collection.GetValue("empresa_medios").AttemptedValue);
                cmd.Parameters.AddWithValue("duracion", collection.GetValue("duracion").AttemptedValue);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            var id = ultimoId();


            var count = collection.Count;
            count = count - 6;
            if (count > 0) { 
                for (var i = 1; i <= count; i++)
                {
                    using (var connection = Utils.Db.Connection())
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("insertar_cadenas_programas_radio", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("programa_radio", Convert.ToInt16(collection.GetValue("programa-" + i).AttemptedValue));
                        cmd.Parameters.AddWithValue("cadena_radio", id);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }

            ViewData["cadenasRadios"] = CadenaRadio.obtenerTodas();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Obtiene el último id la cadena de radio
        /// </summary>
        /// <returns>int</returns>
        public int ultimoId()
        {
            var connection = Utils.Db.Connection();
            int id = 0;


            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC ultima_cadena_radio_id";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        id = Convert.ToInt16(row.GetValue(row.GetOrdinal("id")));
                    };
                }
                connection.Close();
            }

            return id;
        }
    }
}
