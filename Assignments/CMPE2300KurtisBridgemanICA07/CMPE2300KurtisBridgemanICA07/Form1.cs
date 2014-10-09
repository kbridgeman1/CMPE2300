using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2300KurtisBridgemanICA07
{
    public partial class Form1 : Form
    {
        List<Block> blocksList = new List<Block>();

        public Form1()
        {
            InitializeComponent();
        }

        public void ShowBlocks()
        {
            Block.Canvas.Clear();

            Point p = new Point(0, 0);

            foreach (Block bl in blocksList)
            {
                if (p.X + bl.Width > Block.Canvas.ScaledWidth)
                {
                    p.X = 0;
                    p.Y += Block.Height;
                }

                bl.ShowBlock(p);

                p.X += bl.Width;
            }

            Block.Canvas.Render();
        }


        private void btnPopulate_Click(object sender, EventArgs e)
        {
            blocksList.Clear();

            int blockArea = 0;

            while (blockArea < Block.Canvas.ScaledWidth * Block.Canvas.ScaledHeight * 0.8)
            {
                Block tBlock = new Block();

                if (!blocksList.Equals(tBlock))
                {
                    blocksList.Add(tBlock);
                    blockArea += tBlock.Width * Block.Height;
                }
            }

            ShowBlocks();

        }


        private void btnColor_Click(object sender, EventArgs e)
        {

            blocksList.Sort();
            ShowBlocks();

        }

        private void btnWidth_Click(object sender, EventArgs e)
        {
            blocksList.Sort(Block.CompareWidth);
            ShowBlocks();
        }

        private void btnWidthColor_Click(object sender, EventArgs e)
        {


            ShowBlocks();
        }

        private void btnBright_Click(object sender, EventArgs e)
        {
            this.Text = "Blocks Removed: " + blocksList.RemoveAll(Block.BrightEnough).ToString();
            ShowBlocks();
        }

        private void btnLonger_Click(object sender, EventArgs e)
        {
            this.Text = "Blocks Removed: " + blocksList.RemoveAll(Block.LongEnough).ToString();
            ShowBlocks();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Block bl in blocksList)
                bl.Highlight = false;

            Block.HighlightWidth = e.X;
            

            List<Block> tempblList = blocksList.FindAll(Block.CloseEnough);

            foreach (Block bl in tempblList)
                bl.Highlight = true;

            ShowBlocks();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                blocksList.Add(new Block());
            }

            ShowBlocks();


        }

        

        

        

        







    }
}
