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
        if(!IsPostBack)
        {
            ddlInseSelectProdID.DataSource = NorthwindAccess.GetProducts();
            ddlInseSelectProdID.DataTextField = "ProductName";
            ddlInseSelectProdID.DataValueField = "ProductID";
            ddlInseSelectProdID.DataBind();
        }
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
        a = a.Replace("&#39;", "''");

        int prodID = NorthwindAccess.GetProductID(a);
        lblStatusPartI.Text = NorthwindAccess.DeleteOrderDetails(int.Parse(GridViewOrderDetails.SelectedRow.Cells[1].Text), prodID);

        GridViewOrderDetails.DataSource = NorthwindAccess.GetOrderDetails(int.Parse(GridViewOrderDetails.SelectedRow.Cells[1].Text));
        GridViewOrderDetails.DataBind();
        GridViewOrderDetails.SelectedIndex = -1;
    }
    protected void btnInsRecord_Click(object sender, EventArgs e)
    {
        int ordID = 0;
        int prodID = 0;
        short quant = 0;

        int.TryParse(txbxInsOrderID.Text, out ordID);
        int.TryParse(ddlInseSelectProdID.SelectedValue, out prodID);
        short.TryParse(txbxInsEntQuantity.Text, out quant);

        lblStatusPartII.Text = NorthwindAccess.InsertOrderDetails(ordID, prodID, quant);

        GridViewOrderDetails.DataSource = NorthwindAccess.GetOrderDetails(ordID);
        GridViewOrderDetails.DataBind();
    }
    protected void GridViewOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header)
        {
            double d = 0;

            if (double.TryParse(e.Row.Cells[3].Text, out d))
                e.Row.Cells[3].Text = String.Format("{0:C}", d);

            if (double.TryParse(e.Row.Cells[6].Text, out d))
                e.Row.Cells[6].Text = String.Format("{0:C}", d);

        }
    }
}