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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Close();
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin" && textBox2.Text=="1234")
            {
                Form12 f12 = new Form12();
                f12.Close();
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }
    }
}
