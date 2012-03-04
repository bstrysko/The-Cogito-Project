using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.IO.Ports;
using System.Timers;
using System.Runtime.InteropServices;

using CogitoProject.Communication.Electronics;
using CogitoProject.Communication;
using CogitoProject.Communication.Electronics.Microcontroller;
using CogitoProject.Graphics;

namespace CogitoProject
{
    public partial class FireFly : Form
    {
        //private Insight insight;
        private WebCamera webCamera;
        private AlarmSettings alarmSettings;
        private  Picaxe40X2 microcontrollerDriver;
        private System.Media.SoundPlayer mediaPlayer;
        private Voice voice;
        private bool alarmOn;

        [DllImport("winmm.dll", EntryPoint = "PlaySound")]
        public static extern long PlaySound(String lpszName, long hModule, long dwFlags);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new CogitoSettings().ShowDialog();
        }

        public FireFly(String comPort)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.InitializeComponent();

            //this.insight = new Insight(new Point(5, 132), new Size(740, 630));
            //this.Controls.Add(insight);

            this.webCamera = new WebCamera(this.webcamFeed1.Width,this.webcamFeed1.Height);
            this.webCamera.ImageCaptured += new WebCamera.WebCamEventHandler(WebCameraImage);
            this.webCamera.Start(0);

            this.alarmSettings = new AlarmSettings();
            this.mediaPlayer = new System.Media.SoundPlayer();
            this.mediaPlayer.SoundLocation = "";

            this.voice = new Voice();

            this.voice.addCommand("Lights On");
            this.voice.addCommand("Lights Off");
            this.voice.addCommand("Strobe");
            this.voice.addCommand("I am awake");

            this.voice.finalizeCommands();

            microcontrollerDriver = new Picaxe40X2(comPort);

            this.clockTimer.Start();
            //this.insightTimer.Start();
            this.alarmOn = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label5.Text = DateTime.Now.ToString("hh:mm tt");

            if (alarmSettings.remoteTime.ToLongTimeString().Equals(DateTime.Now.ToLongTimeString()))
            {
                microcontrollerDriver.sendCommand(4);
            }

            if (alarmSettings.time.ToLongTimeString().Equals(DateTime.Now.ToLongTimeString()))
            {
                microcontrollerDriver.sendCommand(2);
                this.alarmOn = true;
                mediaPlayer.PlayLooping();
            }

            if (voice.availableCommand())
            {
                String temp = voice.getCommand();

                if (temp.Equals("Lights On"))
                {
                    microcontrollerDriver.sendCommand(1);
                }
                else if (temp.Equals("Lights Off"))
                {
                    microcontrollerDriver.sendCommand(2);
                }
                else if (temp.Equals("Strobe"))
                {
                    microcontrollerDriver.sendCommand(3);
                }
                else if (temp.Equals("I am awake") && alarmOn)
                {
                    button2_Click(null, null);
                }
            }
        }

        private void WebCameraImage(object sender, WebCameraEvent e)
        {
            this.webcamFeed1.Image = e.image;
        }

        private void alaramSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stop();

            for (int t = 0; t < 2; t++)
            {
                String filename = alarmSettings.soundFilename;
                if(t==0)
                {
                    alarmSettings.ShowDialog();
                }
                if (!filename.Equals(mediaPlayer.SoundLocation))
                {
                    mediaPlayer.SoundLocation = alarmSettings.soundFilename;

                    String temp = alarmSettings.soundFilename;
                    char[] buffer = temp.ToCharArray();

                    for (int i = buffer.Length - 1; i >= 0; i--)
                    {
                        if (buffer[i].Equals('\\'))
                        {
                            temp = alarmSettings.soundFilename.Substring(i + 1);
                            break;
                        }
                    }

                    this.label7.Text = temp;
                }

                this.label6.Text = alarmSettings.time.ToString("hh:mm tt");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.brentstrysko.com/projects/the-cogito-project/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (alarmOn == true)
            {
                mediaPlayer.Stop();
                String temp = "Good Morning Brent.  Today is " + DateTime.Now.ToString();
                voice.speak(temp);
                alarmOn = false;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void insightTimer_Tick(object sender, EventArgs e)
        {
            //insight._render();
        }

        private void light1Switch_Click(object sender, EventArgs e)
        {
            microcontrollerDriver.sendCommand(1);
            microcontrollerDriver.sendCommand(1);
            microcontrollerDriver.sendCommand(1);
        }

        private void light2Switch_Click(object sender, EventArgs e)
        {
            microcontrollerDriver.sendCommand(2);
            microcontrollerDriver.sendCommand(2);
            microcontrollerDriver.sendCommand(2);
        }

        private void strobeSwitch_Click(object sender, EventArgs e)
        {
            microcontrollerDriver.sendCommand(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            microcontrollerDriver.sendCommand(4);
        }
    }
}
