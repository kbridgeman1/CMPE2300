using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public static class ADODataOp
{

    private static string sConnection = ConfigurationManager.ConnectionStrings["kbridgeman1_pubsConnectionString"].ConnectionString;

    public static SqlDataSource GetTitles(string sFilter)
    {
        //could filter with sFilter, if needed
        string sQuery = "SELECT title_id, title FROM titles";

        return new SqlDataSource(sConnection,sQuery);
    }

    public static List<string> GetTitleInfo(string titleID)
    {
        List<string> retData = new List<string>();

        string sQuery = "SELECT stor_id as 'Store ID', qty as 'Quantity', ord_date as 'Order Date' from sales";

        if (titleID != null)
            sQuery += " WHERE title_id like '" + titleID + "'";

        using (SqlConnection conn = new SqlConnection(sConnection))
        {
            conn.Open();

            using(SqlCommand comm = new SqlCommand(sQuery, conn))
            {
                SqlDataReader sdr = comm.ExecuteReader(CommandBehavior.CloseConnection);

                if (!sdr.HasRows) return retData;

                while (sdr.Read())
                {
                    string s = "";

                    s += sdr["Store ID"] + " : ";
                    s += sdr["Quantity"] + " : ";
                    s += sdr["Order Date"];

                    retData.Add(s);
                }
            }
        }

        return retData;
    }


}