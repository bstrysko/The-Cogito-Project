using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CogitoProject
{
    public partial class AlarmSettings : Form
    {
        private DateTime _time;
        private DateTime _remoteTime;
        private String _soundFilename;

        public AlarmSettings()
        {
            this.soundFilename = "";
            InitializeComponent();
        }

        public DateTime time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
            }
        }

        public DateTime remoteTime
        {
            get
            {
                return _remoteTime;
            }

            set
            {
                _remoteTime = value;
            }
        }

        public String soundFilename
        {
            get
            {
                return _soundFilename;
            }

            set
            {
                _soundFilename = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.time = timePicker.Value;

            this._remoteTime = timePicker.Value.AddMinutes(-1);

            Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Wav Files(*.wav)|*.wav";
            openFile.ShowDialog();
            String filename=openFile.FileName;
            if (!filename.Equals(""))
            {
                String temp=filename;
                char[] buffer = filename.ToCharArray();

                for (int i = buffer.Length-1; i >= 0; i--)
                {
                    if (buffer[i].Equals('\\'))
                    {
                        temp = filename.Substring(i+1);
                        break;
                    }
                }
                label3.Text = temp;
                this.soundFilename=filename;
            }
        }
    }
}
