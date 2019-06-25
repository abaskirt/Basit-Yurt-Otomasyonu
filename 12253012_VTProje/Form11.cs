using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12253012_VTProje
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(1) + textBox1.Text.Substring(0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Close();
            Form12 f12 = new Form12();
            f12.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form11 f11 = new Form11();
            f11.Close();
            Form13 f13 = new Form13();
            f13.Show();
            this.Hide();
        }
    }
}
