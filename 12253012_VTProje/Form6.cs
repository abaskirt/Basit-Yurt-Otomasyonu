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
    public partial class Form6 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ARDA;Initial Catalog=YurtProje;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * From Personeller", baglanti);
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["PersonelNo"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Gorev"].ToString());
                ekle.SubItems.Add(oku["MaasYillik"].ToString());
                ekle.SubItems.Add(oku["IseGirisTarihi"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text =="" ||textBox3.Text=="" || textBox4.Text=="")
            {
                MessageBox.Show("Boşlukları Doldurunuz.");
                return;
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("sp_PersonelEkle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Ad", textBox1.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@Gorev", textBox3.Text);
            komut.Parameters.AddWithValue("@MaasYillik", textBox4.Text);
            komut.Parameters.AddWithValue("@IseGirisTarihi", kayitTarih.Value.ToString("M/d/y"));
            komut.ExecuteNonQuery();
            listView1.Items.Clear();
            SqlCommand komut2 = new SqlCommand("Select * From Personeller", baglanti);
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["PersonelNo"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Gorev"].ToString());
                ekle.SubItems.Add(oku["MaasYillik"].ToString());
                ekle.SubItems.Add(oku["IseGirisTarihi"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Close();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
