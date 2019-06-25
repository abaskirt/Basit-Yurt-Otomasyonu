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
    
    public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ARDA;Initial Catalog=YurtProje;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Close();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || comboBox1.Text=="" || textBox3.Text=="" || textBox5.Text=="" || textBox6.Text=="" || maskedTextBox1.Text=="" || maskedTextBoxTel.Text=="" || richTextBox1.Text=="")
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz.");
                return;
            }
            bool sor = true;
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select OgrenciTcNo from Veliler where OgrenciTcNo='" + comboBox1.Text + "'", baglanti);
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {

                sor = false;

            }
            dr.Close();
            if (sor)
            {
                sor = true;

            }
            else
            {
                MessageBox.Show("Öğrencinin Velisi Zaten Kayıtlı.");
                baglanti.Close();
                return;
            }
            bool sor2 = false;
            SqlCommand sorgu2 = new SqlCommand("select OgrenciTcNo from Ogrenciler where OgrenciTcNo='" + comboBox1.Text + "'", baglanti);
            SqlDataReader dr2 = sorgu2.ExecuteReader();
            while (dr2.Read())
            {
                sor2 = true;
            }
            dr2.Close();
            if (sor2==false)
            {
                MessageBox.Show("Tc Numarası Kayıtlı Değil.");
                baglanti.Close();
                return;
            }
            SqlCommand komut = new SqlCommand("sp_VeliEkle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@OgrenciTcNo", comboBox1.Text);
            komut.Parameters.AddWithValue("@VeliAd", textBox1.Text);
            komut.Parameters.AddWithValue("@VeliYAkinlik", textBox3.Text);
            komut.Parameters.AddWithValue("@VeliMeslek", textBox5.Text);
            komut.Parameters.AddWithValue("@VeliMail", textBox6.Text);
            komut.Parameters.AddWithValue("@VeliCep", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@VeliEvTelefon", maskedTextBoxTel.Text);
            komut.Parameters.AddWithValue("@VeliAdres", richTextBox1.Text);
            komut.ExecuteNonQuery();
            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            maskedTextBox1.Clear();
            maskedTextBoxTel.Clear();
            richTextBox1.Clear();
            MessageBox.Show("Kayıt Başarıyla Eklendi.");


            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Veliler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["VeliNo"].ToString();
                ekle.SubItems.Add(oku["OgrenciTcNo"].ToString());
                ekle.SubItems.Add(oku["VeliAd"].ToString());
                ekle.SubItems.Add(oku["VeliCep"].ToString());
                ekle.SubItems.Add(oku["VeliEvTelefon"].ToString());
                ekle.SubItems.Add(oku["VeliYakinlik"].ToString());
                ekle.SubItems.Add(oku["VeliMeslek"].ToString());
                ekle.SubItems.Add(oku["VeliAdres"].ToString());
                ekle.SubItems.Add(oku["VeliMail"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Ogrenciler", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["OgrenciTcNo"]);

            }
            baglanti.Close();
        }
    }
}
