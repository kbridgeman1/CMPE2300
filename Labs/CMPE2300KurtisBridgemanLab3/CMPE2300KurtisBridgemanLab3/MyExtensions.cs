using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//********************************************************************************
//Program:  MyExtensions.cs
//Author:   Kurtis Bridgeman
//Class:    CMPE2300
//********************************************************************************

namespace CMPE2300KurtisBridgemanLab3
{
    static class MyExtensions
    {
        //Function:     FisherYatesShuffle
        //Desctiption:  Extention method to List<Point>, shuffles a list of points.
        //Return:       tpList - a new list of shuffled points
        //Parameters:   List<Point> pLst - the list to be shuffled
        //              Random rnd - a random object inialized elsewhere, to prevent seeding issues
        public static List<Point> FisherYatesShuffle(this List<Point> pLst, Random rnd)
        {
            List<Point> tpList = new List<Point>(pLst);

            for (int i = tpList.Count; i > 1; i--)
            {
                int j = rnd.Next(i);
                Point tmp = tpList[j];
                tpList[j] = tpList[i-1];
                tpList[i-1] = tmp;
            }

            return tpList;
        }
    }
}
