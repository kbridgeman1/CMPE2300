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
        
    }

    protected void lbSavedColors_SelectedIndexChanged(object sender, EventArgs e)
    {
        Color genCol = Color.FromArgb(byte.Parse(tBxRed.Text), byte.Parse(rblGreen.SelectedValue), byte.Parse(ddlBlue.SelectedValue));

        previewColor.ForeColor = genCol;
        previewColor.BackColor = genCol;
        lblStatus.Text = String.Format("Color => {0} : Successfully Loaded", tbName.Text);
        lblStatus.ForeColor = Color.Green;
    }

    protected void btnPreviewCol_Click(object sender, EventArgs e)
    {
        byte b = new byte();

        if (byte.TryParse(tBxRed.Text, out b))
        {
            Color col = Processing.GenerateColor(b, byte.Parse(rblGreen.SelectedValue), byte.Parse(ddlBlue.SelectedValue), chbGreyScale.Checked);
            previewColor.ForeColor = col;
            previewColor.BackColor = col;
            lblStatus.Text = "";
        }

    }

    protected void btnSaveColor_Click(object sender, EventArgs e)
    {
        byte b = new byte();

        if (byte.TryParse(tBxRed.Text, out b))
        {
            if (tbName.Text.Length < 1)
            {
                lblStatus.Text = "Enter a name for your color.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            else if(!Processing.NameAvailable(tbName.Text, lbSavedColors))
            {
                lblStatus.Text = "That name is already taken.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            lbSavedColors.Items.Add(new ListItem(tbName.Text, Processing.GenerateColor(byte.Parse(tBxRed.Text), byte.Parse(rblGreen.SelectedValue), byte.Parse(ddlBlue.SelectedValue), chbGreyScale.Checked).ToArgb().ToString()));
        }

    }

    private bool CanMakeColor()
    {
        byte b = new byte();

        if (!byte.TryParse(tBxRed.Text, out b))
            return false;

        else if (tbName.Text.Length < 1)
            return false;

        return true;
    }

}