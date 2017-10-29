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
        [MaxLength(9)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        [DisplayName("NFI")]
        public int nfi { get; set; }
        [DisplayName("Nombre")]
        [MaxLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string nombre { get; set; }
        [DisplayName("Dirección Postal")]
        [MaxLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string direccion_postal { get; set; }
        [DisplayName("Director")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string director { get; set; }
        [DisplayName("Banda Hertziana")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string banda_hertziana { get; set; }
        [MaxLength(75)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        [DisplayName("Provincia")]
        public string provincia  { get; set; }


        public static List<EmisoraRadio> obtenerTodas()
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
                }
                connection.Close();
            }

            return list;
        }
    }
}