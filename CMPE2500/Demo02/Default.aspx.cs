using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Calendar1.SelectedDate = new DateTime(2015, 2, 2);
            Calendar1.VisibleDate = DateTime.Today;
        }
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if(e.Day.Date.Day % 2 == 0 && !e.Day.IsWeekend)
        {
            e.Cell.BackColor = Color.BlanchedAlmond;
        }
    }
}