using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica11_BridgemanKurtis_NEW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.AppendDataBoundItems = true;
            DropDownList1.Items.Add(new ListItem("Select a customer...", "0"));
        }
    }
}