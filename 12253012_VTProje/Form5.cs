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
    public partial class Form5 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ARDA;Initial Catalog=YurtProje;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From OgrenciOdeme", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["OdemeNo"].ToString();
                ekle.SubItems.Add(oku["OgrenciTcNo"].ToString());
                ekle.SubItems.Add(oku["OdenenTutar"].ToString());
                ekle.SubItems.Add(oku["KalanTutar"].ToString());
                ekle.SubItems.Add(oku["OdemeTarihi"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerileriGoster("Select * from Ogrenciler");
        }
        public void VerileriGoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool sor=true;
            int sayi1, sayi2,toplam;
            string Tc = dataGridView1.CurrentRow.Cells["OgrenciTcNo"].Value.ToString();
            textBox2.Text = Tc;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select KalanTutar from OgrenciOdeme where OgrenciTcNo='" + Tc + "'", baglanti);
            cmd.Parameters.AddWithValue("Tc", "string");
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sor = false;
            }
            dr.Close();
            if (sor)
            {
                SqlCommand atama=new SqlCommand("Select OdaYillikFiyat from Kayitlar where OgrenciTcNo = '" + Tc + "'", baglanti);
                sayi1 = Convert.ToInt32(atama.ExecuteScalar());
                SqlCommand atama2 = new SqlCommand("Select OdaEkstraFiyat from Kayitlar where OgrenciTcNo = '" + Tc + "'", baglanti);
                sayi2 = Convert.ToInt32(atama2.ExecuteScalar());
                toplam = sayi1 + sayi2;
                textBox1.Text = toplam.ToString();
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("Select min(KalanTutar) from OgrenciOdeme where OgrenciTcNo='" + Tc + "'", baglanti);
                cmd2.Parameters.AddWithValue("Tc", "string");
                int sayac= Convert.ToInt32(cmd2.ExecuteScalar());
                 textBox1.Text = sayac.ToString();
            }
            baglanti.Close();
            dataGridView1.Refresh();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Lütfen Öğrenci Seçiniz.");
                return;
            }
            if(textBox3.Text=="")
            {
                MessageBox.Show("Lütfen Ödenecek Tutar Giriniz.");
                return;
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("sp_OgrenciOde", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@OgrenciTcNo", textBox2.Text);
            komut.Parameters.AddWithValue("@OdenenTutar", textBox3.Text);
            komut.Parameters.AddWithValue("@OdemeTarihi", kayitTarih.Value.ToString("M/d/y"));
            int kalan = Convert.ToInt32(textBox1.Text) - Convert.ToInt32(textBox3.Text);
            komut.Parameters.AddWithValue("@KalanTutar", kalan);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * From OgrenciOdeme", baglanti);
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["OdemeNo"].ToString();
                ekle.SubItems.Add(oku["OgrenciTcNo"].ToString());
                ekle.SubItems.Add(oku["OdenenTutar"].ToString());
                ekle.SubItems.Add(oku["KalanTutar"].ToString());
                ekle.SubItems.Add(oku["OdemeTarihi"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Close();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
