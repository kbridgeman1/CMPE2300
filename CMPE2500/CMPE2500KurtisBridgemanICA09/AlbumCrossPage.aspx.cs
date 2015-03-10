using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


public partial class AlbumCrossPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            _hiddenFieldUName.Value = ((TextBox)PreviousPage.FindControl("v1tbxUsername")).Text;

            string absolutePath = MapPath(String.Format("~/Uploads/{0}", _hiddenFieldUName.Value));           

            _placeholderAlbum.Controls.Clear();

            
            
            foreach (string s in Directory.GetFiles(absolutePath))
            {
                FileInfo fi = new FileInfo(s); //keep working on this...
                
                Image img = new Image();
                img.ImageUrl = String.Format("~/Uploads/{0}/{1}", _hiddenFieldUName.Value ,fi.Name);
                img.Height = 100;
                img.BorderColor = System.Drawing.Color.LightBlue;
                img.BorderWidth = 5;
                _placeholderAlbum.Controls.Add(img);
            }
             
        }
    }
    protected void _btnAddAgain_Click(object sender, EventArgs e)
    {

    }
}