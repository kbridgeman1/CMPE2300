using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class ICA10_KurtisBridgeman : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnShowProducts_Click(object sender, EventArgs e)
    {
        multViewMain.ActiveViewIndex = 0;
    }
    protected void btnEditEmployees_Click(object sender, EventArgs e)
    {
        multViewMain.ActiveViewIndex = 1;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e == null || e.Row == null || e.Row.DataItem == null) return;

        DataRowView drv = (DataRowView)e.Row.DataItem;
        
        Int16 iUnitsInStock = (Int16)(drv["UnitsInStock"]);
        Int16 iUnitsOnOrder = (Int16)drv["UnitsOnOrder"];
        decimal dUnitPrice = (decimal)drv["UnitPrice"];

        if (iUnitsInStock < 25)
            e.Row.BackColor = Color.LightSalmon;

        if (dUnitPrice > 25)
            e.Row.Cells[3].BackColor = Color.Yellow;

        if (iUnitsInStock < 20 && iUnitsOnOrder < 5)
        {
            e.Row.BackColor = Color.Cyan;
            e.Row.Cells[4].BackColor = Color.GreenYellow;
        }
    }

}