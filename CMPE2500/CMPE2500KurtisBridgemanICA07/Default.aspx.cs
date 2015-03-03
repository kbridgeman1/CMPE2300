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
            rblGreen.Items.Add(new ListItem("0%", "0"));
            rblGreen.Items.Add(new ListItem("50%", "128"));
            rblGreen.Items.Add(new ListItem("100%", "255"));

            rblGreen.SelectedIndex = 0;
        }
    }

    protected void lbSavedColors_SelectedIndexChanged(object sender, EventArgs e)
    {
        Color genCol = Color.FromArgb(int.Parse(lbSavedColors.SelectedItem.Value));

        previewColor.ForeColor = genCol;
        previewColor.BackColor = genCol;
        lblStatus.Text = String.Format("Color => {0} : Successfully Loaded", lbSavedColors.SelectedItem.Text);
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
        else
        {
            lblStatus.Text = "Enter byte value for red between 1 and 255.";
            lblStatus.ForeColor = Color.Red;
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

            else if (!Processing.NameAvailable(tbName.Text, lbSavedColors, Processing.GenerateColor(byte.Parse(tBxRed.Text), byte.Parse(rblGreen.SelectedValue), byte.Parse(ddlBlue.SelectedValue), chbGreyScale.Checked)))
            {
                lblStatus.Text = "That name/color is already taken.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            if (lbSavedColors.Items.Count < 6)
            {
                Color col = Processing.GenerateColor(byte.Parse(tBxRed.Text), byte.Parse(rblGreen.SelectedValue), byte.Parse(ddlBlue.SelectedValue), chbGreyScale.Checked);
                lbSavedColors.Items.Add(new ListItem(tbName.Text, col.ToArgb().ToString()));
                previewColor.ForeColor = col;
                previewColor.BackColor = col;
                lblStatus.Text = String.Format("Color => {0} : Successfully Saved", tbName.Text);
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Only 6 colors may be saved.";
                lblStatus.ForeColor = Color.Red;
            }

        }

        else
        {
            lblStatus.Text = "You must enter a byte value for red between 1 and 255.";
            lblStatus.ForeColor = Color.Red;
            return;
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