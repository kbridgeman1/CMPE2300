using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public static class NorthwindAccess
{
    private static string sConnection = ConfigurationManager.ConnectionStrings["kbridgeman1_NorthwindCustomersConnectionString"].ConnectionString;

    public static SqlDataSource GetSuppliersSDS(string filter)
    {
        string sQuery = "SELECT * FROM Suppliers";

        if (filter != null && filter != "")
            sQuery += " WHERE CompanyName like '%" + filter + "%'";

        return new SqlDataSource(sConnection, sQuery);
    }

  //  public static void 
}