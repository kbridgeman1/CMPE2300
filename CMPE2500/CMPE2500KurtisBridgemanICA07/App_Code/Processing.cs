using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public static class Processing
{

    public static Color GenerateColor(byte r, byte g, byte b, bool grey)
    {
        if (grey)
            return Color.FromArgb(r, r, r);

        return Color.FromArgb(r, g, b);
    }


    public static bool NameAvailable(string name, ListBox colList)
    {
        foreach (ListItem li in colList.Items)
            if (li.Text == name)
                return false;

        return true;
    }

}