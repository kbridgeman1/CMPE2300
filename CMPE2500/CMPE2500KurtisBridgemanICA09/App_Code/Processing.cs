using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Processing
{

    public static bool IsJPG(this string filePath)
    {
        string fExten = "";
        string imgFileName = filePath;
        int fNameLen = imgFileName.Length;

        for (int i = 3; i > 0; i--)
            fExten += imgFileName[fNameLen - i];

        if (fExten == "jpg")
            return true;

        return false;
    }





}