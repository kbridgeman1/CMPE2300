using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritDemo
{
	class myRandom : Random
	{
		public myRandom(int iSeed) : base(iSeed) { }
		public double getDouble( double dMax )
		{
			//Random r = Random(); IS A !!!!!
			return NextDouble() * dMax;
		}
	}
	class myDrawer : GDIDrawer.CDrawer
	{

	}
}
