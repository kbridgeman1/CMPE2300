namespace CMPE2300KurtisBridgemanICA11
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
            this.btnNewRectDrawer = new System.Windows.Forms.Button();
            this.btnNewPicDrawer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewRectDrawer
            // 
            this.btnNewRectDrawer.Location = new System.Drawing.Point(12, 12);
            this.btnNewRectDrawer.Name = "btnNewRectDrawer";
            this.btnNewRectDrawer.Size = new System.Drawing.Size(197, 42);
            this.btnNewRectDrawer.TabIndex = 0;
            this.btnNewRectDrawer.Text = "New RectDrawer";
            this.btnNewRectDrawer.UseVisualStyleBackColor = true;
            this.btnNewRectDrawer.Click += new System.EventHandler(this.btnNewRectDrawer_Click);
            // 
            // btnNewPicDrawer
            // 
            this.btnNewPicDrawer.Location = new System.Drawing.Point(12, 60);
            this.btnNewPicDrawer.Name = "btnNewPicDrawer";
            this.btnNewPicDrawer.Size = new System.Drawing.Size(197, 42);
            this.btnNewPicDrawer.TabIndex = 1;
            this.btnNewPicDrawer.Text = "New PicDrawer";
            this.btnNewPicDrawer.UseVisualStyleBackColor = true;
            this.btnNewPicDrawer.Click += new System.EventHandler(this.btnNewPicDrawer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 120);
            this.Controls.Add(this.btnNewPicDrawer);
            this.Controls.Add(this.btnNewRectDrawer);
            this.Name = "Form1";
            this.Text = "ICA11";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewRectDrawer;
        private System.Windows.Forms.Button btnNewPicDrawer;
    }
}

