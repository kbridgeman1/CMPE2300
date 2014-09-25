namespace CMPE2300KurtisBridgemanICA05
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelSizeValue = new System.Windows.Forms.Label();
            this.bttnAddBalls = new System.Windows.Forms.Button();
            this.buttonClearBalls = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonColor = new System.Windows.Forms.RadioButton();
            this.radioButtonDistance = new System.Windows.Forms.RadioButton();
            this.radioButtonRadius = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(27, 25);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Minimum = -50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(381, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(179, 86);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(36, 13);
            this.labelSize.TabIndex = 1;
            this.labelSize.Text = "Size =";
            // 
            // labelSizeValue
            // 
            this.labelSizeValue.AutoSize = true;
            this.labelSizeValue.Location = new System.Drawing.Point(220, 86);
            this.labelSizeValue.Name = "labelSizeValue";
            this.labelSizeValue.Size = new System.Drawing.Size(13, 13);
            this.labelSizeValue.TabIndex = 2;
            this.labelSizeValue.Text = "0";
            // 
            // bttnAddBalls
            // 
            this.bttnAddBalls.Location = new System.Drawing.Point(27, 116);
            this.bttnAddBalls.Name = "bttnAddBalls";
            this.bttnAddBalls.Size = new System.Drawing.Size(187, 36);
            this.bttnAddBalls.TabIndex = 3;
            this.bttnAddBalls.Text = "Add Balls";
            this.bttnAddBalls.UseVisualStyleBackColor = true;
            this.bttnAddBalls.Click += new System.EventHandler(this.bttnAddBalls_Click_1);
            // 
            // buttonClearBalls
            // 
            this.buttonClearBalls.Location = new System.Drawing.Point(223, 116);
            this.buttonClearBalls.Name = "buttonClearBalls";
            this.buttonClearBalls.Size = new System.Drawing.Size(185, 36);
            this.buttonClearBalls.TabIndex = 4;
            this.buttonClearBalls.Text = "Clear Balls";
            this.buttonClearBalls.UseVisualStyleBackColor = true;
            this.buttonClearBalls.Click += new System.EventHandler(this.buttonClearBalls_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 232);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(433, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonColor);
            this.groupBox1.Controls.Add(this.radioButtonDistance);
            this.groupBox1.Controls.Add(this.radioButtonRadius);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(27, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 47);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort Type";
            // 
            // radioButtonColor
            // 
            this.radioButtonColor.AutoSize = true;
            this.radioButtonColor.Location = new System.Drawing.Point(268, 19);
            this.radioButtonColor.Name = "radioButtonColor";
            this.radioButtonColor.Size = new System.Drawing.Size(49, 17);
            this.radioButtonColor.TabIndex = 2;
            this.radioButtonColor.TabStop = true;
            this.radioButtonColor.Text = "Color";
            this.radioButtonColor.UseVisualStyleBackColor = true;
            this.radioButtonColor.Click += new System.EventHandler(this.radioButtonRadius_Click);
            // 
            // radioButtonDistance
            // 
            this.radioButtonDistance.AutoSize = true;
            this.radioButtonDistance.Location = new System.Drawing.Point(148, 19);
            this.radioButtonDistance.Name = "radioButtonDistance";
            this.radioButtonDistance.Size = new System.Drawing.Size(67, 17);
            this.radioButtonDistance.TabIndex = 1;
            this.radioButtonDistance.TabStop = true;
            this.radioButtonDistance.Text = "Distance";
            this.radioButtonDistance.UseVisualStyleBackColor = true;
            this.radioButtonDistance.Click += new System.EventHandler(this.radioButtonRadius_Click);
            // 
            // radioButtonRadius
            // 
            this.radioButtonRadius.AutoSize = true;
            this.radioButtonRadius.Location = new System.Drawing.Point(28, 20);
            this.radioButtonRadius.Name = "radioButtonRadius";
            this.radioButtonRadius.Size = new System.Drawing.Size(58, 17);
            this.radioButtonRadius.TabIndex = 0;
            this.radioButtonRadius.TabStop = true;
            this.radioButtonRadius.Text = "Radius";
            this.radioButtonRadius.UseVisualStyleBackColor = true;
            this.radioButtonRadius.Click += new System.EventHandler(this.radioButtonRadius_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 255);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonClearBalls);
            this.Controls.Add(this.bttnAddBalls);
            this.Controls.Add(this.labelSizeValue);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelSizeValue;
        private System.Windows.Forms.Button bttnAddBalls;
        private System.Windows.Forms.Button buttonClearBalls;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonColor;
        private System.Windows.Forms.RadioButton radioButtonDistance;
        private System.Windows.Forms.RadioButton radioButtonRadius;
    }
}

