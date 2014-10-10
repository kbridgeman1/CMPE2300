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

                Block.Canvas.Render();
            }

        }

        public void UpdateTrackBar()
        {
            if (blocksList.Count != 0)
            {
                trackBar1.Minimum = blocksList.Min(tBlock => tBlock.Width);
                trackBar1.Maximum = blocksList.Max(tBlock => tBlock.Width);

                trackBar1.Value = (trackBar1.Maximum + trackBar1.Minimum) / 2;
            }

            btnLonger.Text = "Longer than: " + trackBar1.Value.ToString();
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

            UpdateTrackBar();
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

        private void btnWidthDesc_Click(object sender, EventArgs e)
        {
            //same as below, but with a predicate
            //blocksList.Sort(Block.CompareWidthDesc);

            blocksList.Sort((tBlockA, tBlockB) => tBlockB.Width - tBlockA.Width);

            ShowBlocks();
        }

        private void btnWidthColor_Click(object sender, EventArgs e)
        {
            blocksList.Sort(Block.CompareWidthThenCol);
            ShowBlocks();
        }

        private void btnBright_Click(object sender, EventArgs e)
        {
            this.Text = "Blocks Removed: " + blocksList.RemoveAll(Block.BrightEnough).ToString();
            UpdateTrackBar();
            ShowBlocks();
        }

        private void btnLonger_Click(object sender, EventArgs e)
        {
            this.Text = "Blocks Removed: " + blocksList.RemoveAll(tBlock => tBlock.Width > trackBar1.Value).ToString();
            UpdateTrackBar();
            ShowBlocks();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //sets the static Block property to match the mouse X coords 
            //Block.HighlightWidth = e.X;

            //iterates through blocksList setting each Block's Highlight bool to false, using a lambda expression
            blocksList.ForEach(tBlock => tBlock.Highlight = false);

            //finds all blocks that at close the the width provided by Highlight width using a predicate
            //iterates through the Blocks finding remaining Blocks with Highlight == true
            blocksList.FindAll(tBlock => tBlock.Width > e.X - 10 && tBlock.Width < e.X + 10).ForEach(tBlock => tBlock.Highlight = true);

            //blocksList.FindAll(Block.CloseEnough).ForEach(tBlock => tBlock.Highlight = true);

            ShowBlocks();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            btnLonger.Text = "Longer than: " + trackBar1.Value.ToString();
        }


















    }
}
