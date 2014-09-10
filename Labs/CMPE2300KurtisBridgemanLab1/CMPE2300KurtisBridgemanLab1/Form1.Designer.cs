namespace CMPE2300KurtisBridgemanLab1
{
    partial class FormImageSecrets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageSecrets));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoadImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecodeImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelResults = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadImage,
            this.toolStripButtonDecode,
            this.toolStripButtonDecodeImage,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(523, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLoadImage
            // 
            this.toolStripButtonLoadImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLoadImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadImage.Image")));
            this.toolStripButtonLoadImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadImage.Name = "toolStripButtonLoadImage";
            this.toolStripButtonLoadImage.Size = new System.Drawing.Size(73, 22);
            this.toolStripButtonLoadImage.Text = "Load Image";
            this.toolStripButtonLoadImage.Click += new System.EventHandler(this.toolStripButtonLoadImage_Click);
            // 
            // toolStripButtonDecode
            // 
            this.toolStripButtonDecode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDecode.Enabled = false;
            this.toolStripButtonDecode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecode.Image")));
            this.toolStripButtonDecode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecode.Name = "toolStripButtonDecode";
            this.toolStripButtonDecode.Size = new System.Drawing.Size(87, 22);
            this.toolStripButtonDecode.Text = "Decode Image";
            this.toolStripButtonDecode.Click += new System.EventHandler(this.toolStripButtonDecode_Click);
            // 
            // toolStripButtonDecodeImage
            // 
            this.toolStripButtonDecodeImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDecodeImage.Enabled = false;
            this.toolStripButtonDecodeImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecodeImage.Image")));
            this.toolStripButtonDecodeImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecodeImage.Name = "toolStripButtonDecodeImage";
            this.toolStripButtonDecodeImage.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonDecodeImage.Text = "Decode Text";
            this.toolStripButtonDecodeImage.Click += new System.EventHandler(this.toolStripButtonDecodeImage_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "All"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.Text = "Color";
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(499, 288);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelResults
            // 
            this.labelResults.AllowDrop = true;
            this.labelResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResults.Location = new System.Drawing.Point(13, 335);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(498, 54);
            this.labelResults.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 322);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(498, 10);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 3;
            // 
            // FormImageSecrets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 398);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormImageSecrets";
            this.Text = "Image Secrets";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadImage;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecode;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecodeImage;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.ProgressBar progressBar1;

    }
}

