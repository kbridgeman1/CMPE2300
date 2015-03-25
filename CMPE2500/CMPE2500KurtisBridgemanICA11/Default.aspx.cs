using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string absPath = MapPath("~/");
            string[] filePaths;
            try
            {
                filePaths = Directory.GetFiles(absPath);
                foreach(string s in filePaths)
                {
                    FileInfo fi = new FileInfo(s);
                    string ss = fi.Extension;
                }


            }
            catch { }

        }



    }
}