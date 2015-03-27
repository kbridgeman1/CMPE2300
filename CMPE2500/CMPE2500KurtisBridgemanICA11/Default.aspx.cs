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
            try
            {
                foreach(string s in Directory.GetFiles(absPath))
                {
                    FileInfo fi = new FileInfo(s);

                    if (fi.Extension == ".aspx")
                    {
                        HyperLink hl = new HyperLink();
                        hl.Text = fi.Name;
                        hl.Target = fi.DirectoryName;
                        Label lbl = new Label();
                        lbl.Text = "</br>";

                        PlaceHolderHypLinks.Controls.Add(hl);
                        PlaceHolderHypLinks.Controls.Add(lbl);
                    }
                }
            }
            catch(Exception ex) { System.Diagnostics.Trace.WriteLine(ex); }

        }



    }
}