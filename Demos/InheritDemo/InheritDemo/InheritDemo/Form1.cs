using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InheritDemo
{
	public partial class Form1 : Form
	{
		myDrawer _can = new myDrawer();
		public Form1()
		{
			InitializeComponent();
			myRandom rnd = new myRandom(0);
			Text = "Num = " + rnd.getDouble(10);
			Bitmap b = new Bitmap(Properties.Resources.Desert);
		}
	}
	class X { }
}
