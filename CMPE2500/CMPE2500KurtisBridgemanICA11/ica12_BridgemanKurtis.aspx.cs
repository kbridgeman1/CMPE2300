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

            DropDownListSuppliers.DataSource = NorthwindAccess.GetSuppliersSDS("").;
            DropDownListSuppliers.DataTextField = "CompanyName";
            DropDownListSuppliers.DataValueField = "SupplierID";
            
            DropDownListSuppliers.Items.Clear();
            DropDownListSuppliers.Items.Add(new ListItem("Select a Company from {0}", ""));
            DropDownListSuppliers.DataBind();
        }
    }
}