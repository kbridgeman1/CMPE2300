using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica12_BridgemanKurtis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DropDownListSuppliers.AppendDataBoundItems = true;
            DropDownListSuppliers.AutoPostBack = true;

            FillDropList(txBxFilter.Text);
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        FillDropList(txBxFilter.Text);
    }

    protected void FillDropList(string filt)
    {
        DropDownListSuppliers.DataSource = NorthwindAccess.GetSuppliersSDS(filt);
        DropDownListSuppliers.DataTextField = "CompanyName";
        DropDownListSuppliers.DataValueField = "SupplierID";

        DropDownListSuppliers.Items.Clear();
        DropDownListSuppliers.DataBind();
        DropDownListSuppliers.Items.Insert(0, new ListItem(String.Format("Select a Company from {0}", DropDownListSuppliers.Items.Count), "-1"));
    }
}