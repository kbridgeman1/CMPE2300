using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.PreviousPage != null && Page.PreviousPage.IsCrossPagePostBack)
        {
            object obj = Page.PreviousPage.FindControl("Calendar1");

            if (obj == null || !(obj is Calendar)) return;

            Calendar cal = obj as Calendar;

            string date = cal.SelectedDate.ToShortDateString();

            Response.Clear();
            Response.Write("<h1>The selected date was : " + date + " </h1>");
            Response.End();
        }

    }

    
}