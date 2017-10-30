using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManejadorDePatrocinadores.Models
{
    public class Patrocinador
    {
        [DisplayName("Id")]
        public int numero_contrato { get; set; }
        [DisplayName("Nombre")]
        [MaxLength(75)]
        public string nombre { get; set; }
        [DisplayName("Duracion del Contrato")]
        public int duracion_contrato { get; set; }
        [DisplayName("Importe del Contrato")]
        public float importe_contrato { get; set; }

        public static List<Patrocinador> obtenerTodos()
        {
            var connection = Utils.Db.Connection();
            var list = new List<Patrocinador>();

            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC lista_patrocinadores";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        var patrocinadores = new Patrocinador
                        {
                            numero_contrato = Convert.ToInt32(row.GetValue(row.GetOrdinal("numero_contrato"))),
                            nombre = row.GetValue(row.GetOrdinal("nombre")).ToString(),
                            duracion_contrato = Convert.ToInt32(row.GetValue(row.GetOrdinal("duracion_contrato"))),
                            importe_contrato = Convert.ToInt32(row.GetValue(row.GetOrdinal("importe_contrato"))),
                        };
                        list.Add(patrocinadores);
                    }
                }
                connection.Close();
            }

            return list;
        }
    }
}
