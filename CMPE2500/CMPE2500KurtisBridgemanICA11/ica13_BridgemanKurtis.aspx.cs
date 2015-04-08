using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
}