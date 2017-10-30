using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManejadorDePatrocinadores.Models
{
    public class Director
    {
        public int id { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        public static List<Director> obtenerTodos()
        {
            var connection = Utils.Db.Connection();
            var list = new List<Director>();
            

            using (var query = connection.CreateCommand())
            {
                query.CommandText = "EXEC lista_directores";
                connection.Open();
                using (var row = query.ExecuteReader())
                {
                    while (row.Read())
                    {
                        var director = new Director
                        {
                            id = Convert.ToInt32(row.GetValue(row.GetOrdinal("id"))),
                            nombre = row.GetValue(row.GetOrdinal("nombre")).ToString(),

                        };
                        list.Add(director);
                    }
                }
                connection.Close();
            }

            return list;
        }
    }

    
}