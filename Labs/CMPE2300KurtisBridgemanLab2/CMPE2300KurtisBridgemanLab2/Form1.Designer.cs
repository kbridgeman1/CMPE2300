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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEnemiesDestroyed = new System.Windows.Forms.Label();
            this.lblTotalEnemies = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMisslesFired = new System.Windows.Forms.Label();
            this.lblKillPerShot = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExplRad)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(16, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblKillPerShot);
            this.groupBox2.Controls.Add(this.lblMisslesFired);
            this.groupBox2.Controls.Add(this.lblEnemiesDestroyed);
            this.groupBox2.Controls.Add(this.lblTotalEnemies);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(17, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 119);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // lblEnemiesDestroyed
            // 
            this.lblEnemiesDestroyed.AutoSize = true;
            this.lblEnemiesDestroyed.Location = new System.Drawing.Point(158, 37);
            this.lblEnemiesDestroyed.Name = "lblEnemiesDestroyed";
            this.lblEnemiesDestroyed.Size = new System.Drawing.Size(13, 13);
            this.lblEnemiesDestroyed.TabIndex = 5;
            this.lblEnemiesDestroyed.Text = "0";
            // 
            // lblTotalEnemies
            // 
            this.lblTotalEnemies.AutoSize = true;
            this.lblTotalEnemies.Location = new System.Drawing.Point(33, 37);
            this.lblTotalEnemies.Name = "lblTotalEnemies";
            this.lblTotalEnemies.Size = new System.Drawing.Size(13, 13);
            this.lblTotalEnemies.TabIndex = 4;
            this.lblTotalEnemies.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kills per Missle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Missles Fired";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enemies Destroyed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Enemies";
            // 
            // lblMisslesFired
            // 
            this.lblMisslesFired.AutoSize = true;
            this.lblMisslesFired.Location = new System.Drawing.Point(33, 89);
            this.lblMisslesFired.Name = "lblMisslesFired";
            this.lblMisslesFired.Size = new System.Drawing.Size(13, 13);
            this.lblMisslesFired.TabIndex = 6;
            this.lblMisslesFired.Text = "0";
            // 
            // lblKillPerShot
            // 
            this.lblKillPerShot.AutoSize = true;
            this.lblKillPerShot.Location = new System.Drawing.Point(158, 89);
            this.lblKillPerShot.Name = "lblKillPerShot";
            this.lblKillPerShot.Size = new System.Drawing.Size(13, 13);
            this.lblKillPerShot.TabIndex = 7;
            this.lblKillPerShot.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEnemiesDestroyed;
        private System.Windows.Forms.Label lblTotalEnemies;
        private System.Windows.Forms.Label lblKillPerShot;
        private System.Windows.Forms.Label lblMisslesFired;
    }
}

