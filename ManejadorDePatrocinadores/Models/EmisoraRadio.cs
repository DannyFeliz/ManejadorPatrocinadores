using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManejadorDePatrocinadores.Models
{
    public class EmisoraRadio
    {
        [DisplayName("NFI")]
        public int nfi { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Dirección Postal")]
        public string direccion_postal { get; set; }
        [DisplayName("Director")]
        public string director { get; set; }
        [DisplayName("Banda Hertziana")]
        public string banda_hertziana { get; set; }
        [DisplayName("Provincia")]
        public string provincia  { get; set; }
    }
}