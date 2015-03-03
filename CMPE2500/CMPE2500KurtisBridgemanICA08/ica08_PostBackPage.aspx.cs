using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica08_PostBackPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListBox li;

        if (!Page.PreviousPage.IsCrossPagePostBack)
        {
            Label1.Text = "Not a CrossPagePostBack.";
            return;
        }


        Control frmCtrl = FindControl("ListBox1");

        if (frmCtrl is ListBox)
            li = frmCtrl as ListBox;

        else
        {
            Label1.Text = "No ListBox exists.";
            return;
        }

        Response.Clear();
        Response.Write("<table>");

        int i = 1;

        foreach(ListItem l in li.Items)
        {
            Response.Write(String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", i, l.Text, l.Value));
            i++;
        }

        Response.Write("</table");
        Response.End();
    }
}