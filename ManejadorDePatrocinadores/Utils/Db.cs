using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManejadorDePatrocinadores.Utils
{
	public class Db
	{
	    public static SqlConnection Connection()
	    {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        }
	}
}