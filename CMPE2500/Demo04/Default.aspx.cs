using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e == null || e.Row == null || e.Row.DataItem == null) return;

        DataRowView drv = e.Row.DataItem as DataRowView;

        string sProductName = (string)drv["ProductName"];

        if(sProductName.Contains("C"))
        {
            e.Row.BackColor = Color.Yellow;
            e.Row.Cells[1].BackColor = Color.OrangeRed;
        }
    }
}