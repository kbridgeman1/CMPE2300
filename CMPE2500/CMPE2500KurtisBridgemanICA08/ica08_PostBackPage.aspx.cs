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
        if (!Page.PreviousPage.IsCrossPagePostBack)
        {
            Label1.Text = "Not a CrossPagePostBack.";
            return;
        }

        object frmCtrl = Page.PreviousPage.FindControl("ListBox1");
        ListBox lb;

        if (!(frmCtrl is ListBox))
        {
            Label1.Text = "No ListBox exists.";
            return;
        }

        lb = frmCtrl as ListBox;

        Response.Clear();
        Response.Write("<table>");
        Response.Write(String.Format("<tr><td colspan='3'>{0}</td></tr>", lb.Items[0].Text));

        for (int i = 1; i < lb.Items.Count; i++)
        {
            Response.Write(String.Format("<tr><td>[{0}] -</td><td>{1} :</td><td> {2}</td></tr>", i, lb.Items[i].Text, lb.Items[i].Value));
        }
        Response.Write("</table");
        Response.End();
    }
}