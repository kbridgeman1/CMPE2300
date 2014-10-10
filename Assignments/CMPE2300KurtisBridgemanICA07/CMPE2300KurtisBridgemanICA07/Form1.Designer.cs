namespace CMPE2300KurtisBridgemanICA07
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
            this.btnPopulate = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnWidth = new System.Windows.Forms.Button();
            this.btnWidthColor = new System.Windows.Forms.Button();
            this.btnBright = new System.Windows.Forms.Button();
            this.btnLonger = new System.Windows.Forms.Button();
            this.btnWidthDesc = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(13, 11);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(259, 44);
            this.btnPopulate.TabIndex = 0;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(12, 61);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(259, 44);
            this.btnColor.TabIndex = 1;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnWidth
            // 
            this.btnWidth.Location = new System.Drawing.Point(13, 111);
            this.btnWidth.Name = "btnWidth";
            this.btnWidth.Size = new System.Drawing.Size(259, 44);
            this.btnWidth.TabIndex = 2;
            this.btnWidth.Text = "Width";
            this.btnWidth.UseVisualStyleBackColor = true;
            this.btnWidth.Click += new System.EventHandler(this.btnWidth_Click);
            // 
            // btnWidthColor
            // 
            this.btnWidthColor.Location = new System.Drawing.Point(14, 211);
            this.btnWidthColor.Name = "btnWidthColor";
            this.btnWidthColor.Size = new System.Drawing.Size(259, 44);
            this.btnWidthColor.TabIndex = 3;
            this.btnWidthColor.Text = "Width, Color";
            this.btnWidthColor.UseVisualStyleBackColor = true;
            this.btnWidthColor.Click += new System.EventHandler(this.btnWidthColor_Click);
            // 
            // btnBright
            // 
            this.btnBright.Location = new System.Drawing.Point(14, 261);
            this.btnBright.Name = "btnBright";
            this.btnBright.Size = new System.Drawing.Size(259, 44);
            this.btnBright.TabIndex = 4;
            this.btnBright.Text = "Bright";
            this.btnBright.UseVisualStyleBackColor = true;
            this.btnBright.Click += new System.EventHandler(this.btnBright_Click);
            // 
            // btnLonger
            // 
            this.btnLonger.Location = new System.Drawing.Point(14, 311);
            this.btnLonger.Name = "btnLonger";
            this.btnLonger.Size = new System.Drawing.Size(259, 44);
            this.btnLonger.TabIndex = 5;
            this.btnLonger.Text = "Longer";
            this.btnLonger.UseVisualStyleBackColor = true;
            this.btnLonger.Click += new System.EventHandler(this.btnLonger_Click);
            // 
            // btnWidthDesc
            // 
            this.btnWidthDesc.Location = new System.Drawing.Point(14, 161);
            this.btnWidthDesc.Name = "btnWidthDesc";
            this.btnWidthDesc.Size = new System.Drawing.Size(259, 44);
            this.btnWidthDesc.TabIndex = 6;
            this.btnWidthDesc.Text = "Width Desc";
            this.btnWidthDesc.UseVisualStyleBackColor = true;
            this.btnWidthDesc.Click += new System.EventHandler(this.btnWidthDesc_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(14, 362);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(259, 45);
            this.trackBar1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 419);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btnWidthDesc);
            this.Controls.Add(this.btnLonger);
            this.Controls.Add(this.btnBright);
            this.Controls.Add(this.btnWidthColor);
            this.Controls.Add(this.btnWidth);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnPopulate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnWidth;
        private System.Windows.Forms.Button btnWidthColor;
        private System.Windows.Forms.Button btnBright;
        private System.Windows.Forms.Button btnLonger;
        private System.Windows.Forms.Button btnWidthDesc;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

