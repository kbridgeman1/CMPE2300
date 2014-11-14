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
            this.radioButtonMarathon = new System.Windows.Forms.RadioButton();
            this.radioButtonClassic = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblKillPerShot = new System.Windows.Forms.Label();
            this.lblMisslesFired = new System.Windows.Forms.Label();
            this.lblEnemiesDestroyed = new System.Windows.Forms.Label();
            this.lblTotalEnemies = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExplRad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(12, 13);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(175, 35);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // chkBoxEnemysAim
            // 
            this.chkBoxEnemysAim.AutoSize = true;
            this.chkBoxEnemysAim.Location = new System.Drawing.Point(12, 55);
            this.chkBoxEnemysAim.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkBoxEnemysAim.Name = "chkBoxEnemysAim";
            this.chkBoxEnemysAim.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBoxEnemysAim.Size = new System.Drawing.Size(105, 18);
            this.chkBoxEnemysAim.TabIndex = 2;
            this.chkBoxEnemysAim.Text = "      :Enemys Aim";
            this.chkBoxEnemysAim.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(193, 13);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(77, 27);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(193, 47);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 27);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // trackBarExplRad
            // 
            this.trackBarExplRad.Location = new System.Drawing.Point(101, 90);
            this.trackBarExplRad.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.trackBarExplRad.Maximum = 85;
            this.trackBarExplRad.Minimum = 5;
            this.trackBarExplRad.Name = "trackBarExplRad";
            this.trackBarExplRad.Size = new System.Drawing.Size(169, 45);
            this.trackBarExplRad.TabIndex = 5;
            this.trackBarExplRad.TickFrequency = 5;
            this.trackBarExplRad.Value = 45;
            // 
            // labelExpl
            // 
            this.labelExpl.AutoSize = true;
            this.labelExpl.Location = new System.Drawing.Point(13, 90);
            this.labelExpl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExpl.Name = "labelExpl";
            this.labelExpl.Size = new System.Drawing.Size(80, 14);
            this.labelExpl.TabIndex = 6;
            this.labelExpl.Text = "Explosion Size:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonMarathon);
            this.groupBox1.Controls.Add(this.radioButtonClassic);
            this.groupBox1.Location = new System.Drawing.Point(14, 143);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Size = new System.Drawing.Size(254, 53);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Mode";
            // 
            // radioButtonMarathon
            // 
            this.radioButtonMarathon.AutoSize = true;
            this.radioButtonMarathon.Location = new System.Drawing.Point(100, 20);
            this.radioButtonMarathon.Name = "radioButtonMarathon";
            this.radioButtonMarathon.Size = new System.Drawing.Size(70, 18);
            this.radioButtonMarathon.TabIndex = 1;
            this.radioButtonMarathon.TabStop = true;
            this.radioButtonMarathon.Text = "Marathon";
            this.radioButtonMarathon.UseVisualStyleBackColor = true;
            // 
            // radioButtonClassic
            // 
            this.radioButtonClassic.AutoSize = true;
            this.radioButtonClassic.Checked = true;
            this.radioButtonClassic.Location = new System.Drawing.Point(9, 20);
            this.radioButtonClassic.Name = "radioButtonClassic";
            this.radioButtonClassic.Size = new System.Drawing.Size(60, 18);
            this.radioButtonClassic.TabIndex = 0;
            this.radioButtonClassic.TabStop = true;
            this.radioButtonClassic.Text = "Classic";
            this.radioButtonClassic.UseVisualStyleBackColor = true;
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
            this.groupBox2.Location = new System.Drawing.Point(14, 203);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox2.Size = new System.Drawing.Size(254, 129);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // lblKillPerShot
            // 
            this.lblKillPerShot.AutoSize = true;
            this.lblKillPerShot.Location = new System.Drawing.Point(157, 95);
            this.lblKillPerShot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKillPerShot.Name = "lblKillPerShot";
            this.lblKillPerShot.Size = new System.Drawing.Size(13, 14);
            this.lblKillPerShot.TabIndex = 7;
            this.lblKillPerShot.Text = "0";
            // 
            // lblMisslesFired
            // 
            this.lblMisslesFired.AutoSize = true;
            this.lblMisslesFired.Location = new System.Drawing.Point(32, 95);
            this.lblMisslesFired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMisslesFired.Name = "lblMisslesFired";
            this.lblMisslesFired.Size = new System.Drawing.Size(13, 14);
            this.lblMisslesFired.TabIndex = 6;
            this.lblMisslesFired.Text = "0";
            // 
            // lblEnemiesDestroyed
            // 
            this.lblEnemiesDestroyed.AutoSize = true;
            this.lblEnemiesDestroyed.Location = new System.Drawing.Point(157, 39);
            this.lblEnemiesDestroyed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEnemiesDestroyed.Name = "lblEnemiesDestroyed";
            this.lblEnemiesDestroyed.Size = new System.Drawing.Size(13, 14);
            this.lblEnemiesDestroyed.TabIndex = 5;
            this.lblEnemiesDestroyed.Text = "0";
            // 
            // lblTotalEnemies
            // 
            this.lblTotalEnemies.AutoSize = true;
            this.lblTotalEnemies.Location = new System.Drawing.Point(32, 39);
            this.lblTotalEnemies.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalEnemies.Name = "lblTotalEnemies";
            this.lblTotalEnemies.Size = new System.Drawing.Size(13, 14);
            this.lblTotalEnemies.TabIndex = 4;
            this.lblTotalEnemies.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kills per Missle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Missles Fired";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enemies Destroyed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enemy Missiles";
            // 
            // timer2
            // 
            this.timer2.Interval = 150;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelExpl);
            this.Controls.Add(this.trackBarExplRad);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.chkBoxEnemysAim);
            this.Controls.Add(this.btnNewGame);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Missile Command";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExplRad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.RadioButton radioButtonMarathon;
        private System.Windows.Forms.RadioButton radioButtonClassic;
        private System.Windows.Forms.Timer timer2;
    }
}

