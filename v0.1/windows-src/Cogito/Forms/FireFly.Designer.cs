using System.Windows.Forms;

namespace CogitoProject
{
    partial class FireFly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FireFly));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alaramSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clockTimer = new System.Windows.Forms.Timer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.blindL2 = new System.Windows.Forms.Label();
            this.blindL1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.strobeSwitch = new System.Windows.Forms.Button();
            this.lightsOff = new System.Windows.Forms.Button();
            this.lightsOn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.webcamFeed3 = new System.Windows.Forms.PictureBox();
            this.webcamFeed2 = new System.Windows.Forms.PictureBox();
            this.webcamFeed1 = new System.Windows.Forms.PictureBox();
            this.insightTimer = new System.Windows.Forms.Timer();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alaramSettingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.settingsToolStripMenuItem.Text = "File";
            // 
            // alaramSettingsToolStripMenuItem
            // 
            this.alaramSettingsToolStripMenuItem.Name = "alaramSettingsToolStripMenuItem";
            this.alaramSettingsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.alaramSettingsToolStripMenuItem.Text = "Alarm Settings";
            this.alaramSettingsToolStripMenuItem.Click += new System.EventHandler(this.alaramSettingsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem,
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // clockTimer
            // 
            this.clockTimer.Interval = 1000;
            this.clockTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(473, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 94);
            this.panel2.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 24);
            this.button2.TabIndex = 6;
            this.button2.Text = "Snooze";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Acquiring Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Alarm Music File:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Alarm Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Time: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.progressBar2);
            this.panel1.Controls.Add(this.blindL2);
            this.panel1.Controls.Add(this.blindL1);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 94);
            this.panel1.TabIndex = 8;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(86, 63);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(275, 18);
            this.progressBar2.TabIndex = 7;
            // 
            // blindL2
            // 
            this.blindL2.AutoSize = true;
            this.blindL2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.blindL2.Location = new System.Drawing.Point(3, 63);
            this.blindL2.Name = "blindL2";
            this.blindL2.Size = new System.Drawing.Size(75, 13);
            this.blindL2.TabIndex = 6;
            this.blindL2.Text = "Blind 2 Status:";
            // 
            // blindL1
            // 
            this.blindL1.AutoSize = true;
            this.blindL1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.blindL1.Location = new System.Drawing.Point(5, 19);
            this.blindL1.Name = "blindL1";
            this.blindL1.Size = new System.Drawing.Size(75, 13);
            this.blindL1.TabIndex = 5;
            this.blindL1.Text = "Blind 1 Status:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(86, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(275, 18);
            this.progressBar1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.strobeSwitch);
            this.panel4.Controls.Add(this.lightsOff);
            this.panel4.Controls.Add(this.lightsOn);
            this.panel4.Location = new System.Drawing.Point(367, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(108, 93);
            this.panel4.TabIndex = 7;
            // 
            // strobeSwitch
            // 
            this.strobeSwitch.Location = new System.Drawing.Point(14, 63);
            this.strobeSwitch.Name = "strobeSwitch";
            this.strobeSwitch.Size = new System.Drawing.Size(63, 23);
            this.strobeSwitch.TabIndex = 2;
            this.strobeSwitch.Text = "STROBE!";
            this.strobeSwitch.UseVisualStyleBackColor = true;
            this.strobeSwitch.Click += new System.EventHandler(this.strobeSwitch_Click);
            // 
            // lightsOff
            // 
            this.lightsOff.Location = new System.Drawing.Point(2, 30);
            this.lightsOff.Name = "lightsOff";
            this.lightsOff.Size = new System.Drawing.Size(76, 23);
            this.lightsOff.TabIndex = 1;
            this.lightsOff.Text = "Lights Off";
            this.lightsOff.UseVisualStyleBackColor = true;
            this.lightsOff.Click += new System.EventHandler(this.light2Switch_Click);
            // 
            // lightsOn
            // 
            this.lightsOn.Location = new System.Drawing.Point(3, 0);
            this.lightsOn.Name = "lightsOn";
            this.lightsOn.Size = new System.Drawing.Size(75, 24);
            this.lightsOn.TabIndex = 0;
            this.lightsOn.Text = "Lights On";
            this.lightsOn.UseVisualStyleBackColor = true;
            this.lightsOn.Click += new System.EventHandler(this.light1Switch_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.webcamFeed3);
            this.panel3.Controls.Add(this.webcamFeed2);
            this.panel3.Controls.Add(this.webcamFeed1);
            this.panel3.Location = new System.Drawing.Point(748, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 742);
            this.panel3.TabIndex = 11;
            // 
            // webcamFeed3
            // 
            this.webcamFeed3.BackColor = System.Drawing.Color.White;
            this.webcamFeed3.Image = ((System.Drawing.Image)(resources.GetObject("webcamFeed3.Image")));
            this.webcamFeed3.InitialImage = null;
            this.webcamFeed3.Location = new System.Drawing.Point(3, 464);
            this.webcamFeed3.Name = "webcamFeed3";
            this.webcamFeed3.Size = new System.Drawing.Size(269, 182);
            this.webcamFeed3.TabIndex = 14;
            this.webcamFeed3.TabStop = false;
            // 
            // webcamFeed2
            // 
            this.webcamFeed2.BackColor = System.Drawing.Color.White;
            this.webcamFeed2.Image = ((System.Drawing.Image)(resources.GetObject("webcamFeed2.Image")));
            this.webcamFeed2.Location = new System.Drawing.Point(3, 232);
            this.webcamFeed2.Name = "webcamFeed2";
            this.webcamFeed2.Size = new System.Drawing.Size(269, 182);
            this.webcamFeed2.TabIndex = 13;
            this.webcamFeed2.TabStop = false;
            // 
            // webcamFeed1
            // 
            this.webcamFeed1.BackColor = System.Drawing.Color.White;
            this.webcamFeed1.Image = ((System.Drawing.Image)(resources.GetObject("webcamFeed1.Image")));
            this.webcamFeed1.Location = new System.Drawing.Point(3, 0);
            this.webcamFeed1.Name = "webcamFeed1";
            this.webcamFeed1.Size = new System.Drawing.Size(269, 182);
            this.webcamFeed1.TabIndex = 12;
            this.webcamFeed1.TabStop = false;
            // 
            // insightTimer
            // 
            this.insightTimer.Tick += new System.EventHandler(this.insightTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FireFly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FireFly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FireFly";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.ToolStripMenuItem alaramSettingsToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Panel panel1;
        private ProgressBar progressBar2;
        private Label blindL2;
        private Label blindL1;
        private ProgressBar progressBar1;
        private Panel panel3;
        private PictureBox webcamFeed1;
        private PictureBox webcamFeed3;
        private PictureBox webcamFeed2;
        private Timer insightTimer;
        private Panel panel4;
        private Button lightsOff;
        private Button lightsOn;
        private Button strobeSwitch;
        private Button button1;
    }
}

