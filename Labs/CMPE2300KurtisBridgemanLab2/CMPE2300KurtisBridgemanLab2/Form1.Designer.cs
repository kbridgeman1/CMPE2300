namespace CMPE2300KurtisBridgemanLab2
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnNewGame = new System.Windows.Forms.Button();
            this.chkBoxEnemysAim = new System.Windows.Forms.CheckBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.trackBarExplRad = new System.Windows.Forms.TrackBar();
            this.labelExpl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExplRad)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(12, 12);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(176, 33);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // chkBoxEnemysAim
            // 
            this.chkBoxEnemysAim.AutoSize = true;
            this.chkBoxEnemysAim.Location = new System.Drawing.Point(12, 51);
            this.chkBoxEnemysAim.Name = "chkBoxEnemysAim";
            this.chkBoxEnemysAim.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBoxEnemysAim.Size = new System.Drawing.Size(104, 17);
            this.chkBoxEnemysAim.TabIndex = 2;
            this.chkBoxEnemysAim.Text = "      :Enemys Aim";
            this.chkBoxEnemysAim.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(194, 12);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(77, 25);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(194, 43);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 25);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // trackBarExplRad
            // 
            this.trackBarExplRad.Location = new System.Drawing.Point(96, 74);
            this.trackBarExplRad.Maximum = 80;
            this.trackBarExplRad.Minimum = 5;
            this.trackBarExplRad.Name = "trackBarExplRad";
            this.trackBarExplRad.Size = new System.Drawing.Size(176, 45);
            this.trackBarExplRad.TabIndex = 5;
            this.trackBarExplRad.TickFrequency = 5;
            this.trackBarExplRad.Value = 40;
            // 
            // labelExpl
            // 
            this.labelExpl.AutoSize = true;
            this.labelExpl.Location = new System.Drawing.Point(13, 75);
            this.labelExpl.Name = "labelExpl";
            this.labelExpl.Size = new System.Drawing.Size(78, 13);
            this.labelExpl.TabIndex = 6;
            this.labelExpl.Text = "Explosion Size:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.labelExpl);
            this.Controls.Add(this.trackBarExplRad);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.chkBoxEnemysAim);
            this.Controls.Add(this.btnNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExplRad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.CheckBox chkBoxEnemysAim;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar trackBarExplRad;
        private System.Windows.Forms.Label labelExpl;
    }
}

