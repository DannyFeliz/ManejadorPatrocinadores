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
        // GET: CadenaRadio
        public ActionResult Index()
        {
            ViewData["cadenasRadios"] = CadenaRadio.obtenerTodas();

            return View();
        }

        // GET: CadenaRadio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadenaRadio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadenaRadio/Create
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
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            ViewData["cadenasRadios"] = CadenaRadio.obtenerTodas();
            return RedirectToAction("Index");
        }

        // GET: CadenaRadio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadenaRadio/Edit/5
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

        // GET: CadenaRadio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadenaRadio/Delete/5
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
