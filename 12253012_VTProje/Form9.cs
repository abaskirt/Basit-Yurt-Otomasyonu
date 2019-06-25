using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _12253012_VTProje
{
    public partial class Form9 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ARDA;Initial Catalog=YurtProje;Integrated Security=True");
        public Form9()
        {
            InitializeComponent();
        }
        public void VerileriGoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
            
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            VerileriGoster("SELECT * from Ogrenciler");

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Tc = dataGridView1.CurrentRow.Cells["OgrenciTcNo"].Value.ToString();
            textBox1.Text = Tc;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Delete from Ogrenciler where OgrenciTcNo='" + textBox1.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                VerileriGoster("SELECT * from Ogrenciler");
                MessageBox.Show("Silme İşlemi Başarılı.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Close();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
