namespace CMPE2300KurtisBridgemanICA04
{
    partial class FormICA04
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelSizeValue = new System.Windows.Forms.Label();
            this.bttnAddBalls = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(22, 25);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Minimum = -50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(375, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(179, 78);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(39, 13);
            this.labelSize.TabIndex = 1;
            this.labelSize.Text = "Size  =";
            // 
            // labelSizeValue
            // 
            this.labelSizeValue.AutoSize = true;
            this.labelSizeValue.Location = new System.Drawing.Point(221, 78);
            this.labelSizeValue.Name = "labelSizeValue";
            this.labelSizeValue.Size = new System.Drawing.Size(13, 13);
            this.labelSizeValue.TabIndex = 2;
            this.labelSizeValue.Text = "0";
            // 
            // bttnAddBalls
            // 
            this.bttnAddBalls.Location = new System.Drawing.Point(22, 99);
            this.bttnAddBalls.Name = "bttnAddBalls";
            this.bttnAddBalls.Size = new System.Drawing.Size(375, 33);
            this.bttnAddBalls.TabIndex = 3;
            this.bttnAddBalls.Text = "Add Balls";
            this.bttnAddBalls.UseVisualStyleBackColor = true;
            this.bttnAddBalls.Click += new System.EventHandler(this.bttnAddBalls_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 139);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(417, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // FormICA04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 157);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bttnAddBalls);
            this.Controls.Add(this.labelSizeValue);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.trackBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormICA04";
            this.Text = "CMPE2300 - ICA04";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelSizeValue;
        private System.Windows.Forms.Button bttnAddBalls;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

