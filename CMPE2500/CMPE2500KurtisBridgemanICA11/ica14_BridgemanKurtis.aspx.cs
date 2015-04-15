using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica14_BridgemanKurtis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetOrderDetails_Click(object sender, EventArgs e)
    {
        int ordID = 0;
        if (int.TryParse(txbxOrderID.Text, out ordID))
        {
            GridViewOrderDetails.DataSource = NorthwindAccess.GetOrderDetails(ordID);
            GridViewOrderDetails.DataBind();
        }
    }
    protected void btnDeleteSelected_Click(object sender, EventArgs e)
    {
        var a = GridViewOrderDetails.SelectedRow.Cells[2].Text.ToString();
        int prodID = NorthwindAccess.GetProductID(GridViewOrderDetails.SelectedRow.Cells[2].Text);
        lblStatusPartI.Text = NorthwindAccess.DeleteOrderDetails(int.Parse(GridViewOrderDetails.SelectedRow.Cells[1].Text), prodID);

        GridViewOrderDetails.DataSource = NorthwindAccess.GetOrderDetails(int.Parse(GridViewOrderDetails.SelectedRow.Cells[1].Text));
        GridViewOrderDetails.DataBind();
        GridViewOrderDetails.SelectedIndex = -1;
    }
}