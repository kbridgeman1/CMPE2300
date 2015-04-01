using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo06 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            DropDownList1.AppendDataBoundItems = true;
            DropDownList1.AutoPostBack = true;

            DropDownList1.Items.Add(new ListItem("Please Choose...", "-1"));

            DropDownList1.DataSource = ADODataOp.GetTitles("filter");
            DropDownList1.DataTextField = "title";
            DropDownList1.DataValueField = "title_id";
            DropDownList1.DataBind();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<string> sList = ADODataOp.GetTitleInfo(DropDownList1.SelectedValue);

        Label1.Text = "";
        foreach (string s in sList)
            Label1.Text += s + "<br />";
    }
}