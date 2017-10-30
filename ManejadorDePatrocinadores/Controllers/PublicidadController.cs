using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ManejadorDePatrocinadores.Controllers
{
    public class PublicidadController : Controller
    {
        // GET: Publicidad
        public ActionResult Index()
        {   
            ViewData["publicidad"] = Models.Publicidad.obtenerTodas();
            return View();
        }

        // GET: Publicidad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Publicidad/Create
        public ActionResult Create()
        {
            ViewData["patrocinadores"] = Models.Patrocinador.obtenerTodos();
            ViewData["programas_de_radio"] = Models.ProgramaRadio.obtenerTodas();
            return View();
        }

        // POST: Publicidad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                using (var connection = Utils.Db.Connection())
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("insertar_publicidad", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("programa_radio", collection.GetValue("programa_radio").AttemptedValue);
                    cmd.Parameters.AddWithValue("segundos", collection.GetValue("segundos").AttemptedValue);
                    cmd.Parameters.AddWithValue("patrocinador", collection.GetValue("patrocinador").AttemptedValue);
                    cmd.Parameters.AddWithValue("precio_segundo", collection.GetValue("precio_segundo").AttemptedValue);
                    cmd.Parameters.AddWithValue("costo", collection.GetValue("costo").AttemptedValue);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                ViewData["publicidad"] = Models.Publicidad.obtenerTodas();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["patrocinadores"] = Models.Patrocinador.obtenerTodos();
                ViewData["programas_de_radio"] = Models.ProgramaRadio.obtenerTodas();
                return View();
            }
        }

        // GET: Publicidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Publicidad/Edit/5
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

        // GET: Publicidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Publicidad/Delete/5
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
