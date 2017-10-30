using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ManejadorDePatrocinadores.Models
{
    public class EmpresaMedio
    {
        [DisplayName("NFI")]
        public int nif { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Dirección Postal")]
        public string direccion_postal { get; set; }
        [DisplayName("Director")]
        public int director { get; set; }
        [DisplayName("Director")]
        public virtual string director_nombre { get; set; }

        public static List<EmpresaMedio> obtenerTodas()
        {
            var connection = Utils.Db.Connection();
            var list = new List<EmpresaMedio>();

            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC lista_empresas_medios";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        var empresaMedio = new EmpresaMedio
                        {
                            nif = Convert.ToInt32(row.GetValue(row.GetOrdinal("nif"))),
                            nombre = row.GetValue(row.GetOrdinal("nombre")).ToString(),
                            direccion_postal = row.GetValue(row.GetOrdinal("direccion_postal")).ToString(),
                            director_nombre = row.GetValue(row.GetOrdinal("director_nombre")).ToString(),
                        };
                        list.Add(empresaMedio);
                    }
                }
                connection.Close();
            }

            return list;
        }
    }

    
}