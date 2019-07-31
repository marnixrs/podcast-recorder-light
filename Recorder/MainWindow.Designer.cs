namespace Recorder
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_showfiles = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cb_micDevices = new System.Windows.Forms.ComboBox();
            this.cb_speakDevices = new System.Windows.Forms.ComboBox();
            this.lbl_mic = new System.Windows.Forms.Label();
            this.lbl_speak = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_lastRec = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(535, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 49);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start recording";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(616, 12);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 49);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "Stop recording";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.Btn_stop_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(454, 12);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 49);
            this.btn_refresh.TabIndex = 2;
            this.btn_refresh.Text = "Refresh devices";
            this.btn_refresh.UseVisualStyleBackColor = true;
            // 
            // btn_showfiles
            // 
            this.btn_showfiles.Location = new System.Drawing.Point(697, 12);
            this.btn_showfiles.Name = "btn_showfiles";
            this.btn_showfiles.Size = new System.Drawing.Size(75, 49);
            this.btn_showfiles.TabIndex = 3;
            this.btn_showfiles.Text = "Show files \r\nin explorer";
            this.btn_showfiles.UseVisualStyleBackColor = true;
            this.btn_showfiles.Click += new System.EventHandler(this.Btn_showfiles_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 67);
            this.progressBar.MarqueeAnimationSpeed = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(705, 25);
            this.progressBar.TabIndex = 4;
            // 
            // cb_micDevices
            // 
            this.cb_micDevices.FormattingEnabled = true;
            this.cb_micDevices.Location = new System.Drawing.Point(78, 12);
            this.cb_micDevices.Name = "cb_micDevices";
            this.cb_micDevices.Size = new System.Drawing.Size(370, 21);
            this.cb_micDevices.TabIndex = 5;
            // 
            // cb_speakDevices
            // 
            this.cb_speakDevices.FormattingEnabled = true;
            this.cb_speakDevices.Location = new System.Drawing.Point(78, 39);
            this.cb_speakDevices.Name = "cb_speakDevices";
            this.cb_speakDevices.Size = new System.Drawing.Size(370, 21);
            this.cb_speakDevices.TabIndex = 6;
            // 
            // lbl_mic
            // 
            this.lbl_mic.AutoSize = true;
            this.lbl_mic.Location = new System.Drawing.Point(9, 15);
            this.lbl_mic.Name = "lbl_mic";
            this.lbl_mic.Size = new System.Drawing.Size(66, 13);
            this.lbl_mic.TabIndex = 7;
            this.lbl_mic.Text = "Microphone:";
            // 
            // lbl_speak
            // 
            this.lbl_speak.AutoSize = true;
            this.lbl_speak.Location = new System.Drawing.Point(9, 42);
            this.lbl_speak.Name = "lbl_speak";
            this.lbl_speak.Size = new System.Drawing.Size(55, 13);
            this.lbl_speak.TabIndex = 8;
            this.lbl_speak.Text = "Speakers:";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(720, 74);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(49, 13);
            this.lbl_time.TabIndex = 9;
            this.lbl_time.Text = "00:00:00";
            // 
            // lbl_lastRec
            // 
            this.lbl_lastRec.AutoSize = true;
            this.lbl_lastRec.Location = new System.Drawing.Point(9, 99);
            this.lbl_lastRec.Name = "lbl_lastRec";
            this.lbl_lastRec.Size = new System.Drawing.Size(102, 13);
            this.lbl_lastRec.TabIndex = 10;
            this.lbl_lastRec.Text = "Last recorded: none";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 121);
            this.Controls.Add(this.lbl_lastRec);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_speak);
            this.Controls.Add(this.lbl_mic);
            this.Controls.Add(this.cb_speakDevices);
            this.Controls.Add(this.cb_micDevices);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btn_showfiles);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 160);
            this.MinimumSize = new System.Drawing.Size(800, 160);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Podcast Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_showfiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox cb_micDevices;
        private System.Windows.Forms.ComboBox cb_speakDevices;
        private System.Windows.Forms.Label lbl_mic;
        private System.Windows.Forms.Label lbl_speak;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_lastRec;
    }
}

