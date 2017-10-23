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

            var connection = Utils.Db.Connection();
            var list = new List<EmisoraRadio>();

            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC lista_emisoras_radios";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        var emisoraRadio = new EmisoraRadio
                        {
                            nfi = Convert.ToInt32(row.GetValue(row.GetOrdinal("nfi"))),
                            banda_hertziana = row.GetValue(row.GetOrdinal("banda_hertziana")).ToString(),
                            direccion_postal = row.GetValue(row.GetOrdinal("direccion_postal")).ToString(),
                            director = row.GetValue(row.GetOrdinal("director")).ToString(),
                            nombre = row.GetValue(row.GetOrdinal("nombre")).ToString(),
                            provincia = row.GetValue(row.GetOrdinal("provincia")).ToString()
                        };
                        list.Add(emisoraRadio);
                    }
                    ViewData["rows"] = list;
                }
                connection.Close();
            }

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
//                    string sql = "EXEC insertar_emisora_radio 3434, 'La emisora', 'La Dirección', 'El Director', 'AM', 'La Provincia';";
                //                    SqlCommand cmd = new SqlCommand(sql, connection);

                SqlCommand cmd = new SqlCommand("insertar_emisora_radio", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("nfi",123123);
                    cmd.Parameters.AddWithValue("nombre", "ASDA");
                    cmd.Parameters.AddWithValue("direccion", "Dire");
                    cmd.Parameters.AddWithValue("director", "El dire");
                    cmd.Parameters.AddWithValue("banda", "AM");
                    cmd.Parameters.AddWithValue("provincia", "Santo Domingo");
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

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
