using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CMPE2300KurtisBridgemanLab3
{
    static class MyExtensions
    {
        public static List<Point> FisherYatesShuffle(this List<Point> pLst, Random rnd)
        {
         //   Random rnd = new Random();
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
