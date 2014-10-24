namespace CMPE2300KurtisBridgemanICA10
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.trackBarCutoffFreq = new System.Windows.Forms.TrackBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderKeyWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCutoffFreq)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(1, 0);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(477, 48);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "Load File";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // trackBarCutoffFreq
            // 
            this.trackBarCutoffFreq.Location = new System.Drawing.Point(1, 54);
            this.trackBarCutoffFreq.Maximum = 100;
            this.trackBarCutoffFreq.Name = "trackBarCutoffFreq";
            this.trackBarCutoffFreq.Size = new System.Drawing.Size(477, 45);
            this.trackBarCutoffFreq.TabIndex = 1;
            this.trackBarCutoffFreq.Scroll += new System.EventHandler(this.trackBarCutoffFreq_Scroll);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderKeyWord,
            this.columnHeaderFreq});
            this.listView1.Location = new System.Drawing.Point(1, 122);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(477, 404);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderKeyWord
            // 
            this.columnHeaderKeyWord.Text = "KeyWord";
            this.columnHeaderKeyWord.Width = 180;
            // 
            // columnHeaderFreq
            // 
            this.columnHeaderFreq.Text = "Frequency";
            this.columnHeaderFreq.Width = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Remove less than:  0 occurences";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 526);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.trackBarCutoffFreq);
            this.Controls.Add(this.buttonLoadFile);
            this.Name = "Form1";
            this.Text = "ICA10";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCutoffFreq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.TrackBar trackBarCutoffFreq;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderKeyWord;
        private System.Windows.Forms.ColumnHeader columnHeaderFreq;
        private System.Windows.Forms.Label label1;
    }
}

