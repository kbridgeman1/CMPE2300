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
            using (SqlCommand comm = new SqlCommand(sQuery, conn))
            {
                SqlDataReader sdr = comm.ExecuteReader(CommandBehavior.CloseConnection);

                if (!sdr.HasRows) return retData;

                List<string> tList = new List<string>();

                for (int i = 0; i < sdr.FieldCount; i++)
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
        return retData;
    }

    public static void FillCustomersDDL(string companyName, DropDownList ddl)
    {
        SqlDataReader sqlReader;

        SqlConnection sqlConn = new SqlConnection(sConnection);
        sqlConn.Open();

        using (SqlCommand sqlComm = new SqlCommand())
        {
            sqlComm.Connection = sqlConn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "GetCustomers";

            SqlParameter sqlParam = new SqlParameter("@filter", SqlDbType.VarChar, 25);

            if (companyName != null || companyName != "")
                sqlParam.Value = companyName;
            else
                sqlParam.Value = "";

            sqlParam.Direction = ParameterDirection.Input;

            sqlComm.Parameters.Add(sqlParam);

            sqlReader = sqlComm.ExecuteReader(CommandBehavior.CloseConnection);
        }

        ddl.DataSource = sqlReader;
        ddl.DataTextField = "Company Name";
        ddl.DataValueField = "Customer ID";

        ddl.Items.Clear();
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem(String.Format("Select a Customer from [{0}]", ddl.Items.Count), "-1"));
    }

    public static SqlDataReader CustomerCategorySummary(string CustomerID)
    {
        SqlDataReader sqlReader;

        SqlConnection sqlConn = new SqlConnection(sConnection);
        sqlConn.Open();

        using (SqlCommand sqlComm = new SqlCommand())
        {
            sqlComm.Connection = sqlConn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "CustCatSummary";

            SqlParameter sqlParam = new SqlParameter("@CustomerID", SqlDbType.VarChar, 5);

            sqlParam.Value = CustomerID;
            sqlParam.Direction = ParameterDirection.Input;
            sqlComm.Parameters.Add(sqlParam);
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.CloseConnection);
        }

        return sqlReader;
    }

    public static SqlDataReader GetOrderDetails(int OrderID)
    {
        SqlDataReader sqlReader;

        SqlConnection conn = new SqlConnection(sConnection);

        conn.Open();
        using (SqlCommand comm = new SqlCommand())
        {
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "GetOrderDetails";

            SqlParameter sqlPar = new SqlParameter("@OrderID", SqlDbType.Int);
            sqlPar.Value = OrderID;
            sqlPar.Direction = ParameterDirection.Input;

            comm.Parameters.Add(sqlPar);
            sqlReader = comm.ExecuteReader(CommandBehavior.CloseConnection);
        }

        return sqlReader;
    }

    public static int GetProductID(string ProductName)
    {
        string sQuery = "select odd.ProductID from [Order Details] as odd inner join Products as prd on odd.ProductID = prd.ProductID";
        sQuery += " where prd.ProductName like '" + ProductName + "'";

        using (SqlConnection conn = new SqlConnection(sConnection))
        {
            conn.Open();
            using (SqlCommand comm = new SqlCommand(sQuery,conn))
            {
                SqlDataReader sqlReader = comm.ExecuteReader(CommandBehavior.CloseConnection);

                if (!sqlReader.HasRows) return -1;

                if (sqlReader.Read())
                    return int.Parse(sqlReader["ProductID"].ToString());
            }
        }

        return -1;
    }

    public static string DeleteOrderDetails(int OrderID, int ProductID)
    {

        using (SqlConnection conn = new SqlConnection(sConnection))
        {
            conn.Open();

            using (SqlCommand comm = new SqlCommand("DeleteOrderDetails", conn))
            {
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlPar = new SqlParameter("@OrderID", SqlDbType.Int);
                sqlPar.Value = OrderID;
                sqlPar.Direction = ParameterDirection.Input;
                comm.Parameters.Add(sqlPar);

                sqlPar = new SqlParameter("@ProductID", SqlDbType.Int);
                sqlPar.Value = ProductID;
                sqlPar.Direction = ParameterDirection.Input;
                comm.Parameters.Add(sqlPar);

                sqlPar = new SqlParameter("@Output", SqlDbType.VarChar, 80);
                sqlPar.Value = "";
                sqlPar.Direction = ParameterDirection.Output;
                comm.Parameters.Add(sqlPar);

                sqlPar = new SqlParameter("@Return", SqlDbType.Int);
                sqlPar.Value = 0;
                sqlPar.Direction = ParameterDirection.ReturnValue;
                comm.Parameters.Add(sqlPar);

                comm.ExecuteNonQuery();

                int rowsAffects = (int)comm.Parameters["@Return"].Value;
                return (string)comm.Parameters["@Output"].Value;
            }
        }
    }

}