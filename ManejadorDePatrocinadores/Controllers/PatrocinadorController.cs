using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;

namespace ManejadorDePatrocinadores.Controllers
{
    public class PatrocinadorController : Controller
    {
        // GET: Patrocinador
        /// <summary>
        /// Obtener lista de Patrocinadores
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            ViewData["patrocinadores"] = Models.Patrocinador.obtenerTodos();
            return View();
        }

        // GET: Patrocinador/Details/5
        /// <summary>
        /// Obtener lista de detalles de Patrocinadores
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patrocinador/Create
        /// <summary>
        /// Obtener vista de creacion de Patrocinadores
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patrocinador/Create
        /// <summary>
        /// Endpoint para crear Patrocinador
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
        /// <summary>
        /// Obtener un Patrocinador en especifico
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patrocinador/Edit/5
        /// <summary>
        /// Endpoint para actualizar un Patrocinador
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

        // GET: Patrocinador/Delete/5
        /// <summary>
        /// Obtener vista para eliminar un Patrocinador
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patrocinador/Delete/5
        /// <summary>
        /// Endpoint para eliminar un Patrocinador
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
