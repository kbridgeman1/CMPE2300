using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    string sConnection = ConfigurationManager.ConnectionStrings["kbridgeman1_pubsConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Add(new ListItem("Choose an author...", "-1"));
            DropDownList1.AppendDataBoundItems = true;
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(sConnection);
        conn.Open();

        SqlCommand comm = new SqlCommand("DeleteTitleAuthor", conn);
        comm.CommandType = CommandType.StoredProcedure;

        SqlParameter sqlPar = new SqlParameter("@AuthorID", SqlDbType.VarChar, 11);
        sqlPar.Value = DropDownList1.SelectedValue;
        sqlPar.Direction = ParameterDirection.Input;

        comm.Parameters.Add(sqlPar);

        sqlPar = new SqlParameter("@Status", SqlDbType.VarChar, 50);
        sqlPar.Value = "";
        sqlPar.Direction = ParameterDirection.Output;
        comm.Parameters.Add(sqlPar);

        sqlPar = new SqlParameter("@Return", SqlDbType.VarChar, 50);
        sqlPar.Value = 0;
        sqlPar.Direction = ParameterDirection.ReturnValue;
        comm.Parameters.Add(sqlPar);

        comm.ExecuteNonQuery();

        int rowsDeleted = (int)comm.Parameters["@Return"].Value;
        string statusMessage = (string)comm.Parameters["@Status"].Value;
        Label1.Text = "Status: " + statusMessage + "Return Value: " + rowsDeleted;
    }
}

//alter procedure DeleteTitleAuthor
//    @AuthorID varchar(11),
//    @Status varchar(50) = '' output
//as
//declare @Ret int
//delete
//from kbridgeman1_pubs.dbo.titleauthor
//where @AuthorID = au_id
//set @Ret = @@ROWCOUNT 
//set @Status = CAST(@Ret as varchar(4)) + ' records deleted.'
//return @Ret
//go

//declare @Message varchar(50) = ''
//declare @Return int = 0
//execute @Return = DeleteTitleAuthor '213-46-8915', @Message output

//select @Message, @Return
//go