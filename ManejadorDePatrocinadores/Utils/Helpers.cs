using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ManejadorDePatrocinadores.Utils
{
    public class Helpers
    {
        public static List<SelectListItem> ProvincesList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "Azua", Value = "Azua"},
                new SelectListItem {Text = "Bahoruco", Value = "Bahoruco"},
                new SelectListItem {Text = "Barahona", Value = "Barahona"},
                new SelectListItem {Text = "Dajabónn", Value = "Dajabónn"},
                new SelectListItem {Text = "Distrito Nacional", Value = "Distrito Nacional"},
                new SelectListItem {Text = "Duarte", Value = "Duarte"},
                new SelectListItem {Text = "El Seibo", Value = "El Seibo"},
                new SelectListItem {Text = "Elías Piña", Value = "Elías Piña"},
                new SelectListItem {Text = "Espaillat", Value = "Espaillat"},
                new SelectListItem {Text = "Hato Mayor", Value = "Hato Mayor"},
                new SelectListItem {Text = "Independencia", Value = "Independencia"},
                new SelectListItem {Text = "La Altagracia", Value = "La Altagracia"},
                new SelectListItem {Text = "La Romana", Value = "La Romana"},
                new SelectListItem {Text = "La Vega", Value = "La Vega"},
                new SelectListItem {Text = "Maria Trinidad Sánchez", Value = "Maria Trinidad Sánchez"},
                new SelectListItem {Text = "Monseñor Nouel", Value = "Monseñor Nouel"},
                new SelectListItem {Text = "Monte Cristi", Value = "Monte Cristi"},
                new SelectListItem {Text = "Monte Plata", Value = "Monte Plata"},
                new SelectListItem {Text = "Peravia", Value = "Peravia"},
                new SelectListItem {Text = "Perdenales", Value = "Perdenales"},
                new SelectListItem {Text = "Puerto Plata", Value = "Puerto Plata"},
                new SelectListItem {Text = "Salcedo", Value = "Salcedo"},
                new SelectListItem {Text = "Samaná", Value = "Samaná"},
                new SelectListItem {Text = "San Cristóbal", Value = "San Cristóbal"},
                new SelectListItem {Text = "San José de Ocoa", Value = "San José de Ocoa"},
                new SelectListItem {Text = "San Juan de la Maguana", Value = "San Juan de la Maguana"},
                new SelectListItem {Text = "San Pedro de Macorís", Value = "San Pedro de Macorís"},
                new SelectListItem {Text = "Sánchez Ramirez", Value = "Sánchez Ramirez"},
                new SelectListItem {Text = "Santiago Rodríguez", Value = "Santiago Rodríguez"},
                new SelectListItem {Text = "Santiago", Value = "Santiago"},
                new SelectListItem {Text = "Valverde", Value = "Valverde"}
            };
        }
    }
}