using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Demo03Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            _multV.SetActiveView(_mvFirst);
        

    }

    protected void _btnNext_Click(object sender, EventArgs e)
    {
        _multV.ActiveViewIndex = 1;
        _hidden.Value = "I am random";
    }


    protected void _btnUpload_Click(object sender, EventArgs e)
    {
        if(_fileUpload.HasFile)
        {
            if(_fileUpload.PostedFile.ContentType == @"image/jpeg")
            {
                string imgPath = MapPath(@"~/Images") + @"\" + _fileUpload.FileName;


                try
                {
                    _fileUpload.SaveAs(imgPath);
                }
                catch { }

            }

        }


    }
}