using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Alternate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            HiddenField hf = (HiddenField)PreviousPage.FindControl("_hidden");

            if (hf != null)
            {
                for (int i = 1; i < 3; i++)
                {
                    Image img = new Image();
                    img.ImageUrl = String.Format(@"~/Images/image0{0}.jpg", i);
                    img.Height = 300;
                    img.BorderColor = System.Drawing.Color.LightBlue;
                    img.BorderWidth = 5;

                    _placeholder.Controls.Add(img);
                }
            }
            
        }

    }
}