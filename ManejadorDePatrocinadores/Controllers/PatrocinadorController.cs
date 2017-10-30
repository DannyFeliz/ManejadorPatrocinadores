using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;

namespace ManejadorDePatrocinadores.Controllers
{
    public class PatrocinadorController : Controller
    {
        // GET: Patrocinador
        public ActionResult Index()
        {
            ViewData["patrocinadores"] = Models.Patrocinador.obtenerTodos();
            return View();
        }

        // GET: Patrocinador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patrocinador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patrocinador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                using (var connection = Utils.Db.Connection())
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("insertar_patrocinador", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("numero_contrato", collection.GetValue("numero_contrato").AttemptedValue);
                    cmd.Parameters.AddWithValue("nombre", collection.GetValue("nombre").AttemptedValue);
                    cmd.Parameters.AddWithValue("duracion_contrato", collection.GetValue("duracion_contrato").AttemptedValue);
                    cmd.Parameters.AddWithValue("importe_contrato", collection.GetValue("importe_contrato").AttemptedValue);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                ViewData["patrocinadores"] = Models.Patrocinador.obtenerTodos();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patrocinador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patrocinador/Edit/5
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

        // GET: Patrocinador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patrocinador/Delete/5
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
