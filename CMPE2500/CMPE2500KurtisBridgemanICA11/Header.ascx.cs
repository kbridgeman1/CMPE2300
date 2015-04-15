using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
            string absPath = MapPath("~/");
            try
            {
                int i = 0;
                foreach (string s in Directory.GetFiles(absPath))
                {
                    FileInfo fi = new FileInfo(s);

                    if (fi.Extension == ".aspx")
                    {
                        HyperLink hl = new HyperLink();
                        hl.Enabled = true;
                        hl.Text = fi.Name;
                   //     hl.Target = "_blank";
                        hl.NavigateUrl = fi.Name;
                        Label lbl = new Label();
                        lbl.Text = "&nbsp&nbsp&nbsp";
                        PlaceHolderHypLinks.Controls.Add(hl);
                        PlaceHolderHypLinks.Controls.Add(lbl);
                        
                        i++;
                        if (i == 4)
                        {
                            Label lb = new Label();
                            lb.Text = "<br />";
                            PlaceHolderHypLinks.Controls.Add(lb);
                            i = 0;
                        }
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Trace.WriteLine(ex); }

    }
}