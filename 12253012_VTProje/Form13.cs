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
    public partial class Form13 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ARDA;Initial Catalog=YurtProje;Integrated Security=True");
        public Form13()
        {
            InitializeComponent();
            baglanti.Open();
            SqlCommand renk = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button1.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(renk.ExecuteScalar());
            if (KisiSayisi > 0)
            {
                button1.BackColor = Color.Red;
            }
            SqlCommand renk2 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button2.Text + "'", baglanti);
            int KisiSayisi2 = Convert.ToInt32(renk2.ExecuteScalar());
            if (KisiSayisi2 > 0)
            {
                button2.BackColor = Color.Red;
            }
            SqlCommand renk3 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button3.Text + "'", baglanti);
            int KisiSayisi3 = Convert.ToInt32(renk3.ExecuteScalar());
            if (KisiSayisi3 > 0)
            {
                button3.BackColor = Color.Red;
            }
            SqlCommand renk4 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button4.Text + "'", baglanti);
            int KisiSayisi4 = Convert.ToInt32(renk4.ExecuteScalar());
            if (KisiSayisi4 > 1)
            {
                button4.BackColor = Color.Red;
            }
            SqlCommand renk5 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button5.Text + "'", baglanti);
            int KisiSayisi5 = Convert.ToInt32(renk5.ExecuteScalar());
            if (KisiSayisi5 > 1)
            {
                button5.BackColor = Color.Red;
            }
            SqlCommand renk6 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button6.Text + "'", baglanti);
            int KisiSayisi6 = Convert.ToInt32(renk6.ExecuteScalar());
            if (KisiSayisi6 > 1)
            {
                button6.BackColor = Color.Red;
            }
            SqlCommand renk7 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button7.Text + "'", baglanti);
            int KisiSayisi7 = Convert.ToInt32(renk7.ExecuteScalar());
            if (KisiSayisi7 > 2)
            {
                button7.BackColor = Color.Red;
            }
            SqlCommand renk8 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button8.Text + "'", baglanti);
            int KisiSayisi8 = Convert.ToInt32(renk8.ExecuteScalar());
            if (KisiSayisi8 > 2)
            {
                button8.BackColor = Color.Red;
            }
            SqlCommand renk9 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button9.Text + "'", baglanti);
            int KisiSayisi9 = Convert.ToInt32(renk9.ExecuteScalar());
            if (KisiSayisi9 > 2)
            {
                button9.BackColor = Color.Red;
            }
            baglanti.Close();
        }
        public void VerileriGoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form13_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button1.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 101");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button2.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 102");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button3.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 103");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button4.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 201");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button5.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 202");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button6.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 203");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button7.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 301");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button8.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 302");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button9.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi <= 0)
            {
                MessageBox.Show("Oda Boş");
            }
            baglanti.Close();
            VerileriGoster("SELECT Ogrenciler.Isim,Ogrenciler.Soyisim,Ogrenciler.OgrenciTcNo,Ogrenciler.DogumTarihi,Ogrenciler.Telefon,Kayitlar.KayitTarihi,Kayitlar.KayitBitisTarihi FROM Ogrenciler INNER JOIN Kayitlar ON Kayitlar.OgrenciTcNo = Ogrenciler.OgrenciTcNo WHERE Kayitlar.OdaNo LIKE 303");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Close();
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Tc = dataGridView1.CurrentRow.Cells["OgrenciTcNo"].Value.ToString();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select OdaNo from Kayitlar where OgrenciTcNo='" + Tc + "'", baglanti);
            cmd.Parameters.AddWithValue("Tc", "string");
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["OdaNo"].ToString();
            }
            baglanti.Close();
        }

        
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Öğrencinin Şimdiki Oda Numarası Seçiniz.");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Öğrencinin Yeni Oda Numarası Seçiniz.");
                return;
            }
            if (textBox2.Text != "101" && textBox2.Text != "102" && textBox2.Text != "103" && textBox2.Text != "201" && textBox2.Text != "202" && textBox2.Text != "203" && textBox2.Text != "301" && textBox2.Text != "302" && textBox2.Text != "303")
            {
                MessageBox.Show("Bu Oda Numarası Yurtta Bulunmamaktadır.");
                return;
            }
            baglanti.Open();
            int bolum = (int.Parse(textBox2.Text) / 100) - 1;
            SqlCommand sayi = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + textBox2.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayi.ExecuteScalar());
            if (KisiSayisi > bolum)
            {
                MessageBox.Show("Oda Dolu");
                baglanti.Close();
                return;
            }
            baglanti.Close();
            string Tc = dataGridView1.CurrentRow.Cells["OgrenciTcNo"].Value.ToString();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Update Kayitlar Set OdaNo='" + textBox2.Text + "' where OgrenciTcNo='" + Tc + "'", baglanti);
            cmd.ExecuteNonQuery();
            SqlCommand renk = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button1.Text + "'", baglanti);
            int KisiSayi = Convert.ToInt32(renk.ExecuteScalar());
            if (KisiSayi > 0)
            {
                button1.BackColor = Color.Red;
            }
            else
            {
                button1.BackColor = Color.Lime;
            }
            SqlCommand renk2 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button2.Text + "'", baglanti);
            int KisiSayi2 = Convert.ToInt32(renk2.ExecuteScalar());
            if (KisiSayi2 > 0)
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button2.BackColor = Color.Lime;
            }
            SqlCommand renk3 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button3.Text + "'", baglanti);
            int KisiSayi3 = Convert.ToInt32(renk3.ExecuteScalar());
            if (KisiSayi3 > 0)
            {
                button3.BackColor = Color.Red;
            }
            else
            {
                button3.BackColor = Color.Lime;
            }
            SqlCommand renk4 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button4.Text + "'", baglanti);
            int KisiSayi4 = Convert.ToInt32(renk4.ExecuteScalar());
            if (KisiSayi4 > 1)
            {
                button4.BackColor = Color.Red;
            }
            else
            {
                button4.BackColor = Color.Lime;
            }
            SqlCommand renk5 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button5.Text + "'", baglanti);
            int KisiSayi5 = Convert.ToInt32(renk5.ExecuteScalar());
            if (KisiSayi5 > 1)
            {
                button5.BackColor = Color.Red;
            }
            else
            {
                button5.BackColor = Color.Lime;
            }
            SqlCommand renk6 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button6.Text + "'", baglanti);
            int KisiSayi6 = Convert.ToInt32(renk6.ExecuteScalar());
            if (KisiSayi6 > 1)
            {
                button6.BackColor = Color.Red;
            }
            else
            {
                button6.BackColor = Color.Lime;
            }
            SqlCommand renk7 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button7.Text + "'", baglanti);
            int KisiSayi7 = Convert.ToInt32(renk7.ExecuteScalar());
            if (KisiSayi7 > 2)
            {
                button7.BackColor = Color.Red;
            }
            else
            {
                button7.BackColor = Color.Lime;
            }
            SqlCommand renk8 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button8.Text + "'", baglanti);
            int KisiSayi8 = Convert.ToInt32(renk8.ExecuteScalar());
            if (KisiSayi8 > 2)
            {
                button8.BackColor = Color.Red;
            }
            else
            {
                button8.BackColor = Color.Lime;
            }
            SqlCommand renk9 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button9.Text + "'", baglanti);
            int KisiSayi9 = Convert.ToInt32(renk9.ExecuteScalar());
            if (KisiSayi9 > 2)
            {
                button9.BackColor = Color.Red;
            }
            else
            {
                button9.BackColor = Color.Lime;
            }

            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
