using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManejadorDePatrocinadores.Models
{
    public class ProgramaRadio
    {
        public int id { get; set; }
        [DisplayName("Dia")]
        public int dia { get; set; }
        [DataType(DataType.Time)]
        [DisplayName("Hora de Inicio")]
        public string hora_inicio { get; set; }
        [DataType(DataType.Time)]
        [DisplayName("Hora de Finalizacion")]
        public string hora_fin { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Responsable")]
        public string responsable { get; set; }


        /// <summary>
        /// Obtener lista de todos los Programas de Radio
        /// </summary>
        /// <returns>List<ProgramaRadio></returns>
        public static List<ProgramaRadio> obtenerTodas()
        {
            var connection = Utils.Db.Connection();
            var list = new List<ProgramaRadio>();

            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC lista_programa_radio";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        var listaProgramasDeRadio = new ProgramaRadio
                        {
                            id = Convert.ToInt32(row.GetValue(row.GetOrdinal("id"))),
                            nombre = row.GetValue(row.GetOrdinal("nombre")).ToString(),
                            responsable = row.GetValue(row.GetOrdinal("encargado")).ToString(),
                            dia = Convert.ToInt32(row.GetValue(row.GetOrdinal("dia"))),
                            hora_inicio = row.GetValue(row.GetOrdinal("hora_inicio")).ToString(),
                            hora_fin = row.GetValue(row.GetOrdinal("hora_fin")).ToString(),
                        };
                        list.Add(listaProgramasDeRadio);
                    }
                }
                connection.Close();
            }

            return list;
        }
    }
}