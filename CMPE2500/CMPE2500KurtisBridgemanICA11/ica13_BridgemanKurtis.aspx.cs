using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class ica13_BridgemanKurtis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCustomers.AppendDataBoundItems = true;
            ddlCustomers.AutoPostBack = true;

            NorthwindAccess.FillCustomersDDL(txbxFilter.Text, ddlCustomers);
        }
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        NorthwindAccess.FillCustomersDDL(txbxFilter.Text, ddlCustomers);
    }
    protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCustomers.SelectedIndex == 0) return;

        string CustomerID = ddlCustomers.SelectedValue;

        gridViewCategories.DataSource = NorthwindAccess.CustomerCategorySummary(CustomerID);
        gridViewCategories.DataBind();
    }
    protected void gridViewCategories_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header)
        {
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            
            double d = 0;

            if(double.TryParse(e.Row.Cells[2].Text, out d))
                e.Row.Cells[2].Text = String.Format("{0:C}", d);
                                  
            foreach (DataControlFieldCell cell in e.Row.Cells)
                cell.BorderColor = Color.White;
        }
    }
}