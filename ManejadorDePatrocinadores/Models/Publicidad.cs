using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ManejadorDePatrocinadores.Models
{
    public class Publicidad
    {
        public int id { get; private set; }

        [DisplayName("Programa de Radio")]
        public int programa_radio { get; set; }
        [DisplayName("Tiempo de Publicidad (Segundos)")]
        public int segundos { get; set; }
        [DisplayName("Patrocinador")]
        public int patrocinador { get; set; }
        [DisplayName("Precio x Segundo")]
        public float precio_segundo { get; set; }
        [DisplayName("Costo por Publicidad")]
        public float costo { get; set; }

        public static List<Publicidad> obtenerTodas()
        {
            var connection = Utils.Db.Connection();
            var list = new List<Publicidad>();

            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC lista_publicidad";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        var listaPublicidad = new Publicidad
                        {
                            id = Convert.ToInt32(row.GetValue(row.GetOrdinal("id"))),
                            programa_radio = Convert.ToInt32(row.GetValue(row.GetOrdinal("programa_radio"))),
                            segundos = Convert.ToInt32(row.GetValue(row.GetOrdinal("segundos")).ToString()),
                            patrocinador = Convert.ToInt32(row.GetValue(row.GetOrdinal("patrocinador"))),
                            precio_segundo = Convert.ToInt32(row.GetValue(row.GetOrdinal("precio_segundo"))),
                            costo = Convert.ToInt32(row.GetValue(row.GetOrdinal("costo"))),
                        };
                        list.Add(listaPublicidad);
                    }
                }
                connection.Close();
            }

            return list;
        }
    }
}