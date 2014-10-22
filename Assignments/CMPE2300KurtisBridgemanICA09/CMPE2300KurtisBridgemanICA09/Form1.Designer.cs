namespace CMPE2300KurtisBridgemanICA09
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
            this.btnMakeList = new System.Windows.Forms.Button();
            this.btnPopulateList = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMakeList
            // 
            this.btnMakeList.Location = new System.Drawing.Point(13, 40);
            this.btnMakeList.Name = "btnMakeList";
            this.btnMakeList.Size = new System.Drawing.Size(283, 40);
            this.btnMakeList.TabIndex = 0;
            this.btnMakeList.Text = "Make List";
            this.btnMakeList.UseVisualStyleBackColor = true;
            this.btnMakeList.Click += new System.EventHandler(this.btnMakeList_Click);
            // 
            // btnPopulateList
            // 
            this.btnPopulateList.Location = new System.Drawing.Point(13, 86);
            this.btnPopulateList.Name = "btnPopulateList";
            this.btnPopulateList.Size = new System.Drawing.Size(283, 40);
            this.btnPopulateList.TabIndex = 1;
            this.btnPopulateList.Text = "Populate Linked List";
            this.btnPopulateList.UseVisualStyleBackColor = true;
            this.btnPopulateList.Click += new System.EventHandler(this.btnPopulateList_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(13, 14);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(283, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 140);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnPopulateList);
            this.Controls.Add(this.btnMakeList);
            this.Name = "Form1";
            this.Text = "ICA09";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMakeList;
        private System.Windows.Forms.Button btnPopulateList;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

