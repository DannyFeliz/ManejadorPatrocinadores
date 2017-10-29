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
        // GET: EmisoraRadio
        public ActionResult Index()
        {

            ViewData["rows"] = EmisoraRadio.obtenerTodas();

            return View();
        }

        // GET: EmisoraRadio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmisoraRadio/Create
        public ActionResult Create()
        {
            var selectList = new SelectList(new List<SelectListItem>
                        {
                            new SelectListItem {Text = "FM", Value = "FM"},
                            new SelectListItem {Text = "AM", Value = "AM"},
                        }, "Value", "Text");

            ViewData["provinces"] = Utils.Helpers.ProvincesList();




            return View();
        }

        // POST: EmisoraRadio/Create
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

        // GET: EmisoraRadio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmisoraRadio/Edit/5
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

        // GET: EmisoraRadio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmisoraRadio/Delete/5
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
