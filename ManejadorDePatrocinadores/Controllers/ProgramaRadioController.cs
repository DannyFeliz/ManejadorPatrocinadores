using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManejadorDePatrocinadores.Controllers
{
    public class ProgramaRadioController : Controller
    {
        // GET: ProgramaRadio
        /// <summary>
        /// Obtener vista de lista de Programas de Radio
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            ViewData["programas_de_radio"] = Models.ProgramaRadio.obtenerTodas();
            return View();
        }

        // GET: ProgramaRadio/Details/5
        /// <summary>
        /// Obtener vista con los detalles de un Programa de Radio
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProgramaRadio/Create
        /// <summary>
        /// Obtener vista para crear un Programa de Radio
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Create()
        {
            ViewData["dias_de_la_semana"] = Utils.Helpers.DaysList();
            return View();
        }

        // POST: ProgramaRadio/Create
        /// <summary>
        /// Endpoint para crear un Programa de Radio
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                using (var connection = Utils.Db.Connection())
                {
                    connection.Open();
                    var nombre = collection.GetValue("nombre").AttemptedValue;
                    var encargado = collection.GetValue("responsable").AttemptedValue;
                    var cantidad = collection.GetValues("dia[]").ToArray().Length;
                    var dias = collection.GetValues("dia[]").ToArray();
                    var horas_inicio = collection.GetValues("hora_inicio[]").ToArray();
                    var horas_fin = collection.GetValues("hora_fin[]").ToArray();

                    for (int i = 0;  i <= cantidad; i++)
                    {
                        var dia = dias[i];
                        var hora_inicio = horas_inicio[i];
                        var hora_fin = horas_fin[i];

                        SqlCommand cmd = new SqlCommand("insertar_programa_radio", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("nombre", nombre);
                        cmd.Parameters.AddWithValue("responsable", encargado);
                        cmd.Parameters.AddWithValue("dia", dia);
                        cmd.Parameters.AddWithValue("hora_inicio", hora_inicio);
                        cmd.Parameters.AddWithValue("hora_fin", hora_fin);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                ViewData["programas_de_radio"] = Models.ProgramaRadio.obtenerTodas();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["dias_de_la_semana"] = Utils.Helpers.DaysList();
                return View();
            }
        }

        // GET: ProgramaRadio/Edit/5
        /// <summary>
        /// Obtener vista para editar un Programa de Radio
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProgramaRadio/Edit/5
        /// <summary>
        /// Endpoint para editar un Programa de Radio
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramaRadio/Delete/5
        /// <summary>
        /// Obtener vista para eliminar un Programa de Radio
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProgramaRadio/Delete/5
        /// <summary>
        /// Endpoint para eliminar un Programa de Radio
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
