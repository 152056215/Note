using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NOTE
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void newnote(object sender, EventArgs e)
        {
            NewNote n1 = new NewNote();
            n1.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Classify c = new Classify();
            c.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            notemanage n = new notemanage();
            n.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
