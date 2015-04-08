using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo07
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            
            ListBox1.AutoPostBack = true;
            ListBox1.AppendDataBoundItems = true;

            ListBox1.DataSource = Class1.GetTitles("");
            ListBox1.DataTextField = "title";
            ListBox1.DataValueField = "title_id";
            ListBox1.DataBind();

            ListBox1.Items.Insert(0, new ListItem("Pick ME!!11!!11!!", ""));
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedValue == "") return;

            string titleID = ListBox1.SelectedValue;
            
            GridView1.DataSource = Class1.GetSummary(titleID);
            
            GridView1.DataBind();
        }
    }
}