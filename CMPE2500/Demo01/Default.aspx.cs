using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DropDownList1.Items.Add("Choose one...");
            DropDownList1.Items.Add(new ListItem("0", "a"));
            DropDownList1.Items.Add(new ListItem("1", "b"));
            DropDownList1.Items.Add(new ListItem("2", "c"));
            DropDownList1.Items.Add(new ListItem("3", "d"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Text += testclass.AddText(TextBox1.Text);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = DropDownList1.SelectedValue;
    }
}