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

    public static List<List<string>> GetProducts(string supplierID)
    {
        List<List<string>> retData = new List<List<string>>();
        string sQuery = "SELECT ProductName as 'Name', QuantityPerUnit as 'Qty', UnitsInStock as 'Units in Stock'";
        sQuery += " FROM Products";
        sQuery += " WHERE SupplierID LIKE '%" + supplierID + "%'";
        
        if (supplierID == null || supplierID == "")
            return retData;

        using (SqlConnection conn = new SqlConnection(sConnection))
        {
            conn.Open();
            using(SqlCommand comm = new SqlCommand(sQuery, conn))
            {
                SqlDataReader sdr = comm.ExecuteReader(CommandBehavior.CloseConnection);

                if (!sdr.HasRows) return retData;

                List<string> tList = new List<string>();

                for(int i =0;i<sdr.FieldCount;i++)
                    tList.Add(sdr.GetName(i));
                    
                retData.Add(tList);

                while (sdr.Read())
                {
                    tList = new List<string>();
                    tList.Add(sdr[retData[0][0]].ToString());
                    tList.Add(sdr[retData[0][1]].ToString());
                    tList.Add(sdr[retData[0][2]].ToString());
                    retData.Add(tList);
                }
            }
        }


        return new List<List<string>>();
    }
  
}