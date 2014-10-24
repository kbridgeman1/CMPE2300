using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2300KurtisBridgemanICA10
{
    public partial class Form1 : Form
    {
        OpenFileDialog opnFileDlg;

        SortedDictionary<string, int> sDicKeyWords = new SortedDictionary<string, int>();
        List<string> lString = new List<string>(System.IO.File.ReadLines(@"..\..\..\KeyWords.txt"));
        List<string> tLString = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //splits the contents of the keywords.txt file into a list of strings, representing each work (tLString)
            foreach (string s in lString)
                foreach (string ss in s.Split(' '))
                    tLString.Add(ss);
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            List<string> csString = new List<string>();
            sDicKeyWords.Clear();

            //new open file dialog to recieve a .cs file 
            if (opnFileDlg != null)
                opnFileDlg = null;

            opnFileDlg = new OpenFileDialog();

            opnFileDlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            opnFileDlg.Filter = "Class Files|*.cs";

            if (opnFileDlg.ShowDialog() == DialogResult.OK)
            {
                List<string> tcsLString = new List<string>(System.IO.File.ReadLines(opnFileDlg.FileName));

                //splits the text contents of selected .cs file into a list of strings, representing each word (csString)
                foreach (string s in tcsLString)
                    foreach (string ss in s.Split(' ', '(', ')', ';', '=', ',', '.', '{', '}'))
                    {
                        if(!String.IsNullOrWhiteSpace(ss))
                        csString.Add(ss);
                    }
            }

            foreach ( string s in csString)
            {
                if(tLString.Contains(s))
                {
                    if (sDicKeyWords.ContainsKey(s))
                        sDicKeyWords[s] += 1;
                    else
                        sDicKeyWords[s] = 1;
                }

            }

            ShowDictionary();
        }

        private void ShowDictionary() 
        {
            //clears the items from the ListView, then adds then contents of the sorted dictionary ( sDicKeyWords)
            listView1.Items.Clear();

            foreach (KeyValuePair<string, int> kvp in sDicKeyWords)
            {
                ListViewItem lvi = listView1.Items.Add(kvp.Key);
                lvi.SubItems.Add(kvp.Value.ToString());
            }
        }

        private void trackBarCutoffFreq_Scroll(object sender, EventArgs e)
        {
            label1.Text = String.Format("Remove less than: {0} occurences", trackBarCutoffFreq.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, int> tDic = new SortedDictionary<string, int>(sDicKeyWords);
            foreach (KeyValuePair<string, int> kvp in tDic.Where(entry => entry.Value < trackBarCutoffFreq.Value))
                sDicKeyWords.Remove(kvp.Key);

            ShowDictionary();
        }



    }
}
