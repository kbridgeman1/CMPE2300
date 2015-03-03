using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica08_KurtisBridgeman : System.Web.UI.Page
{
    string sRB;

    protected void Page_Load(object sender, EventArgs e)
    {
        sRB = "";

        if (RadioButton1.Checked)
            sRB = RadioButton1.Text;
        else if (RadioButton2.Checked)
            sRB = RadioButton2.Text;
        else if (RadioButton3.Checked)
            sRB = RadioButton3.Text;

        foreach (ListItem li in ListBox1.Items)
        {
            

        }
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {        
        if (sRB != "")
        {
            string d = "";
            d += Calendar1.SelectedDate.Month.ToString();
            d += Calendar1.SelectedDate.Day.ToString();
            d += Calendar1.SelectedDate.Year.ToString();
            d = Calendar1.SelectedDate.ToString("MMM - s - yyyy");

            ListBox1.Items.Add(new ListItem(d, sRB));
        }
    }

    protected string MonthString(int iM)
    {

        

        return "";
    }
}