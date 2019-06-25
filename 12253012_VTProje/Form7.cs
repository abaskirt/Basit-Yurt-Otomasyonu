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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ARDA;Initial Catalog=YurtProje;Integrated Security=True");
        private void Form7_Load(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from Veliler",baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["VeliNo"]);
                    
                }
                baglanti.Close();
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("Select * From IzinTablo", baglanti);
                SqlDataReader oku = komut2.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["IzinNo"].ToString();
                    ekle.SubItems.Add(oku["VeliNo"].ToString());
                    ekle.SubItems.Add(oku["IzinSebebi"].ToString());
                    ekle.SubItems.Add(oku["IzinCikisTarihi"].ToString());
                    ekle.SubItems.Add(oku["IzinDonusTarihi"].ToString());
                    ekle.SubItems.Add(oku["GittigiYer"].ToString());
                    listView1.Items.Add(ekle);

                }
                baglanti.Close();
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Close();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string No = comboBox1.Text;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select VeliAd from Veliler where VeliNo='" + No + "'", baglanti);
            cmd.Parameters.AddWithValue("VeliAd", "string");
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["VeliAd"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("Select OgrenciTcNo from Veliler where VeliNo='" + No + "'", baglanti);
            cmd2.Parameters.AddWithValue("OgrenciTcNo", "string");
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                textBox2.Text = dr2["OgrenciTcNo"].ToString();
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("sp_OgrenciIzin", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@VeliNo", comboBox1.Text);
            komut.Parameters.AddWithValue("@IzinSebebi", textBox3.Text);
            komut.Parameters.AddWithValue("@GittigiYer", textBox4.Text);
            komut.Parameters.AddWithValue("@IzinCikisTarihi", kayitTarih.Value.ToString("M/d/y"));
            komut.Parameters.AddWithValue("@IzinDonusTarihi", dateTimePicker1.Value.ToString("M/d/y"));
            komut.ExecuteNonQuery();
            listView1.Items.Clear();
            SqlCommand komut2 = new SqlCommand("Select * From IzinTablo", baglanti);
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["IzinNo"].ToString();
                ekle.SubItems.Add(oku["VeliNo"].ToString());
                ekle.SubItems.Add(oku["IzinSebebi"].ToString());
                ekle.SubItems.Add(oku["IzinCikisTarihi"].ToString());
                ekle.SubItems.Add(oku["IzinDonusTarihi"].ToString());
                ekle.SubItems.Add(oku["GittigiYer"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            MessageBox.Show("İzin Verildi");

        }
    }
}
