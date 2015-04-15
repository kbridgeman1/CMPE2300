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
}