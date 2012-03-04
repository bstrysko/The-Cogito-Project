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
    public partial class CogitoSettings : Form
    {
        public CogitoSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String comPort = comSelector.SelectedItem.ToString();
            Close();

            new FireFly(comPort).ShowDialog();
        }
    }
}
