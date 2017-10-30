using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ManejadorDePatrocinadores.Models
{
    public class CadenaRadio
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Nombre")]
        [MaxLength(75)]
        public string nombre_representativo { get; set; }
        [DisplayName("Sede Central")]
        public int sede_central { get; set; }
        [DisplayName("Director")]
        public int director { get; set; }
        [DisplayName("Empresa de Medios")]
        public int empresa_medios  { get; set; }
        public virtual string director_nombre { get; set; }
        public virtual string sede_central_nombre { get; set; }
        public virtual string empresa_medios_nombre { get; set; }


        public static List<CadenaRadio> obtenerTodas()
        {
            var connection = Utils.Db.Connection();
            var list = new List<CadenaRadio>();

            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC lista_cadenas_radios";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        var cadenaRadio = new CadenaRadio
                        {
                            id = Convert.ToInt32(row.GetValue(row.GetOrdinal("id"))),
                            nombre_representativo = row.GetValue(row.GetOrdinal("nombre_representativo")).ToString(),
                            sede_central = Convert.ToInt32(row.GetValue(row.GetOrdinal("sede_central"))),
                            sede_central_nombre = row.GetValue(row.GetOrdinal("sede_central_nombre")).ToString(),
                            director = Convert.ToInt32(row.GetValue(row.GetOrdinal("director"))),
                            director_nombre = row.GetValue(row.GetOrdinal("director_nombre")).ToString(),
                            empresa_medios = Convert.ToInt32(row.GetValue(row.GetOrdinal("empresa_medios"))),
                            empresa_medios_nombre = row.GetValue(row.GetOrdinal("empresa_medios_nombre")).ToString()
                        };
                        list.Add(cadenaRadio);
                    }
                }
                connection.Close();
            }

            return list;
        }
    }
}