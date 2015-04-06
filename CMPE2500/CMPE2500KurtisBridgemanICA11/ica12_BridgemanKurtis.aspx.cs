using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica12_BridgemanKurtis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownListSuppliers.AppendDataBoundItems = true;
            DropDownListSuppliers.AutoPostBack = true;

            FillDropList(txBxFilter.Text);
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        FillDropList(txBxFilter.Text);
    }

    protected void FillDropList(string filt)
    {
        DropDownListSuppliers.DataSource = NorthwindAccess.GetSuppliersSDS(filt);
        DropDownListSuppliers.DataTextField = "CompanyName";
        DropDownListSuppliers.DataValueField = "SupplierID";

        DropDownListSuppliers.Items.Clear();
        DropDownListSuppliers.DataBind();
        DropDownListSuppliers.Items.Insert(0, new ListItem(String.Format("Select a Company from {0}", DropDownListSuppliers.Items.Count), "-1"));
    }

    protected void DropDownListSuppliers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListSuppliers.SelectedIndex == 0) return;

        List<List<string>> lProd = NorthwindAccess.GetProducts(DropDownListSuppliers.SelectedValue);

        TableHeaderRow thr = new TableHeaderRow();
        for (int i = 0; i < lProd[0].Count; i++)
        {
            TableHeaderCell thc = new TableHeaderCell();
            thc.Text = lProd[0][i];
            thr.Cells.Add(thc);
        }

        tableProducts.Rows.Add(thr);

        for (int i = 1; i < lProd.Count; i++)
        {
            TableRow tr = new TableRow();
            for (int ii = 0; ii < lProd[i].Count; ii++)
            {
                TableCell tc = new TableCell();
                tc.Text = lProd[i][ii];
                tr.Cells.Add(tc);
            }
            tableProducts.Rows.Add(tr);
        }


    }
}