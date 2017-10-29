using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManejadorDePatrocinadores.Models;

namespace ManejadorDePatrocinadores.Controllers
{
    public class DirectorController : Controller
    {
        // GET: Director
        public ActionResult Index()
        {
            ViewData["directores"] = Director.obtenerTodos();

            return View();
        }

        // GET: Director/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Director/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Director/Edit/5
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

        // GET: Director/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Director/Delete/5
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
