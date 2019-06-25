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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonKayitEkle_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form1 fr1 = new Form1();
            fr1.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonOdalar_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form3 fr3 = new Form3();
            fr3.Show();
            this.Hide();
        }

        private void buttonVeliEkle_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form4 fr4 = new Form4();
            fr4.Show();
            this.Hide();
        }

        private void OgrenciOdeme_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form5 fr5 = new Form5();
            fr5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form6 fr6 = new Form6();
            fr6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form7 fr7 = new Form7();
            fr7.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form8 fr8 = new Form8();
            fr8.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form9 fr9= new Form9();
            fr9.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Close();
            Form10 fr10 = new Form10();
            fr10.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
