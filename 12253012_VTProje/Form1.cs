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
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ARDA;Initial Catalog=YurtProje;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            baglanti.Open();
            SqlCommand renk = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button1.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(renk.ExecuteScalar());
            if(KisiSayisi>0)
            {
                button1.BackColor = Color.Red;
            }
            SqlCommand renk2 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button2.Text + "'", baglanti);
            int KisiSayisi2 = Convert.ToInt32(renk2.ExecuteScalar());
            if (KisiSayisi2 >0)
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
            int KisiSayisi6= Convert.ToInt32(renk6.ExecuteScalar());
            if (KisiSayisi6 > 1)
            {
                button6.BackColor = Color.Red;
            }
            SqlCommand renk7 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button7.Text + "'", baglanti);
            int KisiSayisi7= Convert.ToInt32(renk7.ExecuteScalar());
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
            kayitBitisTarihi.Value = kayitTarih.Value.AddYears(1);
            radioButton2.Checked = true;
            baglanti.Close();

        }
        
        
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("sp_OgrenciEkleme",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Isim", textBoxAd.Text);
            komut.Parameters.AddWithValue("@Soyisim", textBoxSoyad.Text);
            bool sor = true;
            SqlCommand sorgu = new SqlCommand("select OgrenciTcNo from Ogrenciler where OgrenciTcNo='" + textBoxTc.Text + "'", baglanti);
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
                MessageBox.Show("Tc No Zaten Kayıtlı");
                baglanti.Close();
                return;
            }
            if (textBoxOdaNo.Text == "" || textBoxTc.Text=="" || textBoxAd.Text==""||textBoxSoyad.Text==""|| maskedTextBoxTel.MaskFull==false)
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurun");
                baglanti.Close();
                return;
            }
            SqlCommand sayac = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + textBoxOdaNo.Text + "'", baglanti);
            int KisiSayisi = Convert.ToInt32(sayac.ExecuteScalar());
            int kapasite = Convert.ToInt32(textBoxOdaNo.Text) / 100;
            if (kapasite == 1)
            {
                if (KisiSayisi >= kapasite)
                {
                    sor = false;
                }
            }
            if (kapasite == 2)
            {
                if (KisiSayisi >= kapasite)
                {
                    sor = false;
                }
            }
            if (kapasite == 3)
            {
                if (KisiSayisi >= kapasite)
                {
                    sor = false;
                }
            }
            if (sor == false)
            {
                MessageBox.Show("Seçtiğiniz Odada Boş Yer Bulunmamaktadır.");
                baglanti.Close();
                return;
            }
            if (sor)
            {
                int ekstra = 0;
                komut.Parameters.AddWithValue("@OgrenciTcNo", textBoxTc.Text);
                komut.Parameters.AddWithValue("@Telefon", maskedTextBoxTel.Text);
                komut.Parameters.AddWithValue("@OdaNo", textBoxOdaNo.Text);
                komut.Parameters.AddWithValue("@DogumTarihi", dogumTarih.Value.ToString("M/d/y"));
                komut.Parameters.AddWithValue("@KayitTarihi", kayitTarih.Value.ToString("M/d/y"));
                komut.Parameters.AddWithValue("@KayitBitisTarihi", kayitBitisTarihi.Value.ToString("M/d/y"));
                int mod = Convert.ToInt32(textBoxOdaNo.Text) / 100;
                if (mod == 1)
                {
                    komut.Parameters.AddWithValue("@OdaKapasitesi", 1);
                    komut.Parameters.AddWithValue("@OdaYillikFiyat", 5000);
                }
                if (mod == 2)
                {
                    komut.Parameters.AddWithValue("@OdaKapasitesi", 2);
                    komut.Parameters.AddWithValue("@OdaYillikFiyat", 4500);
                }
                if (mod == 3)
                {
                    komut.Parameters.AddWithValue("@OdaKapasitesi", 3);
                    komut.Parameters.AddWithValue("@OdaYillikFiyat", 4000);
                }

                if (radioButton1.Checked == true)
                {
                    ekstra = 500;
                }
                komut.Parameters.AddWithValue("@OdaEkstraFiyat", ekstra);
                komut.ExecuteNonQuery();
                textBoxTc.Clear();
                maskedTextBoxTel.Clear();
                textBoxOdaNo.Clear();
                textBoxAd.Clear();
                textBoxSoyad.Clear();
                textBoxOdaNo.Clear();
                dogumTarih.Value = DateTime.Today;
                kayitBitisTarihi.Value = DateTime.Today;
                kayitTarih.Value = DateTime.Today;
                MessageBox.Show("Kayıt Başarıyla Eklendi.");
            }
            SqlCommand renk = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button1.Text + "'", baglanti);
            int KisiSayi = Convert.ToInt32(renk.ExecuteScalar());
            if (KisiSayi > 0)
            {
                button1.BackColor = Color.Red;
            }
            SqlCommand renk2 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button2.Text + "'", baglanti);
            int KisiSayi2 = Convert.ToInt32(renk2.ExecuteScalar());
            if (KisiSayi2 > 0)
            {
                button2.BackColor = Color.Red;
            }
            SqlCommand renk3 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button3.Text + "'", baglanti);
            int KisiSayi3 = Convert.ToInt32(renk3.ExecuteScalar());
            if (KisiSayi3 > 0)
            {
                button3.BackColor = Color.Red;
            }
            SqlCommand renk4 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button4.Text + "'", baglanti);
            int KisiSayi4 = Convert.ToInt32(renk4.ExecuteScalar());
            if (KisiSayi4 > 1)
            {
                button4.BackColor = Color.Red;
            }
            SqlCommand renk5 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button5.Text + "'", baglanti);
            int KisiSayi5 = Convert.ToInt32(renk5.ExecuteScalar());
            if (KisiSayi5 > 1)
            {
                button5.BackColor = Color.Red;
            }
            SqlCommand renk6 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button6.Text + "'", baglanti);
            int KisiSayi6 = Convert.ToInt32(renk6.ExecuteScalar());
            if (KisiSayi6 > 1)
            {
                button6.BackColor = Color.Red;
            }
            SqlCommand renk7 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button7.Text + "'", baglanti);
            int KisiSayi7 = Convert.ToInt32(renk7.ExecuteScalar());
            if (KisiSayi7 > 2)
            {
                button7.BackColor = Color.Red;
            }
            SqlCommand renk8 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button8.Text + "'", baglanti);
            int KisiSayi8 = Convert.ToInt32(renk8.ExecuteScalar());
            if (KisiSayi8 > 2)
            {
                button8.BackColor = Color.Red;
            }
            SqlCommand renk9 = new SqlCommand("Select Count(OdaNo) from Kayitlar where OdaNo='" + button9.Text + "'", baglanti);
            int KisiSayi9 = Convert.ToInt32(renk9.ExecuteScalar());
            if (KisiSayi9 > 2)
            {
                button9.BackColor = Color.Red;
            }
            baglanti.Close();
            
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxOdaNo.Text = button9.Text;
        }

        private void textBoxAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBoxSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBoxTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kayitTarih_ValueChanged(object sender, EventArgs e)
        {
            kayitBitisTarihi.Value = kayitTarih.Value.AddYears(1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Close();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
