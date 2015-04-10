using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica11_BridgemanKurtis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            dropDownListCustomers.AppendDataBoundItems = true;
            dropDownListCustomers.Items.Add(new ListItem("Select a customer...", "0"));
        }
        

    }
    protected void dropDownListCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        listViewOrders.EditIndex = -1;
        listViewOrders.SelectedIndex = -1;
    }

}