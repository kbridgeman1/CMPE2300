using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

public partial class KurtisBridgemanICA09 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            lblStatus.Text = "Lets Begin";
            lblStatus.Width = Unit.Percentage(100);
            lblStatus.BorderStyle = BorderStyle.Inset;
            lblStatus.BackColor = Color.LightGreen;

            MultViewMain.ActiveViewIndex = 0;
        }

    }
    protected void v1btnNext_Click(object sender, EventArgs e)
    {

        if (v1tbxUsername.Text.Length < 1)
        {
            lblStatus.Text = "Please enter a username.";
            lblStatus.BackColor = Color.Red;
            SetFocus(v1tbxUsername);
        }

        else if (v1tBxPassword.Text.Length < 1)
        {
            lblStatus.Text = "Please enter a password.";
            lblStatus.BackColor = Color.Red;
            SetFocus(v1tBxPassword);
        }

        else
        {
            MultViewMain.ActiveViewIndex = 1;
            lblStatus.Text = "Add pictures.";
            lblStatus.BackColor = Color.LightGreen;
            v2lblMessage.Text = String.Format("Thanks {0}, Now add to your album:", v1tbxUsername.Text);
        }
    }
    protected void v2btnNext_Click(object sender, EventArgs e)
    {
        string absolutePath;
        absolutePath = MapPath(String.Format("~/Uploads/{0}", v1tbxUsername.Text));

        if(v2FileUploadAddImage.HasFile)
        {
            lblStatus.Text = "";

            if(!Directory.Exists(absolutePath))
                try
                {
                    Directory.CreateDirectory(absolutePath);
                    lblStatus.Text += String.Format("Directory: {0} has been created.<br/>", absolutePath);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex);
                }

            string filePath = v2FileUploadAddImage.FileName;

            if (!filePath.IsJPG())
            {
                lblStatus.Text += "Only .png file types are allowed.";
                lblStatus.BackColor = Color.Red;
                return;
            }

            string picPath = absolutePath + "\\" + filePath;

            if (File.Exists(picPath))
                try
                {
                    File.Delete(picPath);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex);
                }

            try
            {
                v2FileUploadAddImage.SaveAs(picPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }

            MultViewMain.ActiveViewIndex = 2;
            lblStatus.Text += String.Format("Image: {0} has been successfully added to the album.", filePath);
            lblStatus.BackColor = Color.LightGreen;
        }


    }
}