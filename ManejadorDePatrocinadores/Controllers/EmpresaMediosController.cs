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
        public ActionResult Index()
        {
            ViewData["empresasMedios"] = EmpresaMedio.obtenerTodas();
            

            return View();
        }

        // GET: EmpresaMedios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpresaMedios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaMedios/Create
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

        // GET: EmpresaMedios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpresaMedios/Edit/5
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

        // GET: EmpresaMedios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpresaMedios/Delete/5
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
