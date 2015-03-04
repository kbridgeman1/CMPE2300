using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class ica08_KurtisBridgeman : System.Web.UI.Page
{
    string sRB;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ListBox1.Items.Add(new ListItem("Dates to Remember"));
        }

        sRB = "";

        if (RadioButton1.Checked)
            sRB = RadioButton1.Text;
        else if (RadioButton2.Checked)
            sRB = RadioButton2.Text;
        else if (RadioButton3.Checked)
            sRB = RadioButton3.Text;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {    
        if (sRB != "")
        {
            ListItem li  = new ListItem(Calendar1.SelectedDate.ToString("MMMM - dd - yyyy"), sRB);

            if (ListBox1.Items.Contains(li))
            {
                ListBox1.Items.Remove(li);
                lblStatus.Text = String.Format("Removed => {0} : {1}", li.Text, li.Value);
            }
            else
            {
                ListBox1.Items.Add(li);
                lblStatus.Text = String.Format("Added => {0} : {1}", li.Text, li.Value);
            }
        }

        Calendar1.SelectedDate = DateTime.Now;
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        ListItem li = ListBox1.Items.FindByText(e.Day.Date.ToString("MMMM - dd - yyyy"));

        if(li != null)
        {
            if (li.Value == RadioButton1.Text)
                e.Cell.BackColor = Color.Red;
            else if (li.Value == RadioButton2.Text)
                e.Cell.BackColor = Color.Blue;
            else if (li.Value == RadioButton3.Text)
                e.Cell.BackColor = Color.Yellow;
        }
    }
}