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
    public partial class Form8 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ARDA;Initial Catalog=YurtProje;Integrated Security=True");
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Personeller", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["PersonelNo"]);

            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * From PersonelIzin", baglanti);
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["IzinId"].ToString();
                ekle.SubItems.Add(oku["PersonelNo"].ToString());
                ekle.SubItems.Add(oku["IzinSebebi"].ToString());
                ekle.SubItems.Add(oku["IzinCikisTarihi"].ToString());
                ekle.SubItems.Add(oku["IzinDonusTarihi"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Close();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string No = comboBox1.Text;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select Ad from Personeller where PersonelNo='" + No + "'", baglanti);
            cmd.Parameters.AddWithValue("Ad", "string");
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Ad"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("Select Soyad from Personeller where PersonelNo='" + No + "'", baglanti);
            cmd2.Parameters.AddWithValue("Soyad", "string");
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                textBox2.Text = dr2["Soyad"].ToString();
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("sp_IzinPersonel", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@PersonelNo", comboBox1.Text);
            komut.Parameters.AddWithValue("@IzinSebebi", textBox3.Text);
            komut.Parameters.AddWithValue("@IzinCikisTarihi", kayitTarih.Value.ToString("M/d/y"));
            komut.Parameters.AddWithValue("@IzinDonusTarihi", dateTimePicker1.Value.ToString("M/d/y"));
            komut.ExecuteNonQuery();
            listView1.Items.Clear();
            SqlCommand komut2 = new SqlCommand("Select * From PersonelIzin", baglanti);
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["IzinId"].ToString();
                ekle.SubItems.Add(oku["PersonelNo"].ToString());
                ekle.SubItems.Add(oku["IzinSebebi"].ToString());
                ekle.SubItems.Add(oku["IzinCikisTarihi"].ToString());
                ekle.SubItems.Add(oku["IzinDonusTarihi"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("İzin Verildi");
        }
    }
}
