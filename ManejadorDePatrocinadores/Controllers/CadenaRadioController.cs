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
            ViewData["directoresLista"] = Director.obtenerTodos();
            ViewData["emisoraLista"] = EmisoraRadio.obtenerTodas();
            ViewData["empresaMediosLista"] = EmpresaMedio.obtenerTodas();

            return View();
        }

        // GET: EmisoraRadio/Create
        public string programs()
        {
            return "[{\"nombre\": \"Buenas Noches\", \"id\":433}, {\"nombre\": \"Serie 1\", \"id\": 234}]";
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
