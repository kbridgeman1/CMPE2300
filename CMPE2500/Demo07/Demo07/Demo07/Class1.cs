using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Demo07
{
    public class Class1
    {
        public static string connString = ConfigurationManager.ConnectionStrings["kbridgeman1_pubsConnectionString"].ConnectionString;

        public static SqlDataReader GetTitles(string filter)
        {
            SqlDataReader reader;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "GetTitles";

                SqlParameter param = new SqlParameter("@filter", SqlDbType.VarChar, 80);
                param.Value = filter;
                param.Direction = ParameterDirection.Input;

                comm.Parameters.Add(param);

                reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            }

            return reader;
        }

        public static SqlDataReader GetSummary(string titleID)
        {
            SqlDataReader sqlrdr;
            
            SqlConnection sqlconn = new SqlConnection(connString);
            sqlconn.Open();

            using (SqlCommand sqlcomm = new SqlCommand())
            {
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "GetSummary";

                SqlParameter sqlparam = new SqlParameter("@titleID", SqlDbType.VarChar, 6);
                sqlparam.Value = titleID;
                sqlparam.Direction = ParameterDirection.Input;
                sqlcomm.Parameters.Add(sqlparam);

                sqlrdr = sqlcomm.ExecuteReader(CommandBehavior.CloseConnection);
            }

            return sqlrdr;
        }


    }
}