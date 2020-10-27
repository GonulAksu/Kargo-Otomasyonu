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

namespace WindowsFormsAppYeni
{
    public partial class Kargo_Gönder : Form
    {
        public Kargo_Gönder()
        {
            InitializeComponent(); 
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HUMEYRAA\SQLEXPRESS01;Initial Catalog=HGH_Kargo;Integrated Security=True");
        Double agirlik;
        Double adet;

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in this.groupBox1.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            foreach (TextBox txt in this.groupBox2.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            foreach (TextBox txt in this.groupBox3.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            foreach (TextBox txt in this.groupBox5.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            foreach (TextBox txt in this.groupBox6.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kargo_Gönder.ActiveForm.Visible = false; 
            HGHKargo frm = new HGHKargo(); //tekrar anasayfaya dönmek için 
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    
                    baglanti.Open();
                    string kayit = "INSERT INTO Fatura(takip_no,gtc,atc,gisim,aisim,gsoyad,asoyad,gtel,atel,gposta,aposta,gadres,aadres,tarih,notlar,ucret,kargo_durum) VALUES(@takip_no,@gtc,@atc,@gisim,@aisim,@gsoyad,@asoyad,@gtel,@atel,@gposta,@aposta,@gadres,@aadres,@tarih,@notlar,@ucret,@kargo_durum)";
                    SqlCommand cmd = new SqlCommand(kayit, baglanti);
                    cmd.Parameters.AddWithValue("@takip_no", textBox15.Text);
                    cmd.Parameters.AddWithValue("@gtc", textBox2.Text);
                    cmd.Parameters.AddWithValue("@atc", textBox8.Text);
                    cmd.Parameters.AddWithValue("@gisim", textBox1.Text);
                    cmd.Parameters.AddWithValue("@aisim", textBox9.Text);
                    cmd.Parameters.AddWithValue("@gsoyad", textBox3.Text);
                    cmd.Parameters.AddWithValue("@asoyad", textBox10.Text);
                    cmd.Parameters.AddWithValue("@gtel", textBox4.Text);
                    cmd.Parameters.AddWithValue("@atel", textBox11.Text);
                    cmd.Parameters.AddWithValue("@gposta", textBox5.Text);
                    cmd.Parameters.AddWithValue("@aposta", textBox12.Text);
                    cmd.Parameters.AddWithValue("@gadres", textBox6.Text);
                    cmd.Parameters.AddWithValue("@aadres", textBox14.Text);
                    cmd.Parameters.AddWithValue("@tarih", textBox7.Text);
                    cmd.Parameters.AddWithValue("@notlar", textBox13.Text);
                    cmd.Parameters.AddWithValue("@ucret", textBox19.Text);
                    cmd.Parameters.AddWithValue("@kargo_durum", "Kargo Hazırlanıyor");
                  

                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt Başarılı");

                    foreach (Control item in this.Controls)
                    {

                        if (item is TextBox)
                        {
                            TextBox tbox = (TextBox)item;
                            tbox.Clear();
                        }
                     }
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem sırasında hata oluştu." + hata.Message);
            }
        }

  
        double fiyat;
        private void button2_Click(object sender, EventArgs e)
        {

            adet = Int32.Parse(textBox17.Text);
            agirlik = double.Parse(textBox17.Text); 
            fiyat = agirlik * adet + 5;
            textBox19.Text = fiyat.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            Random rastgele = new Random();  //rastgele sayı üretmek için
            int faturano = rastgele.Next(11111, 99999);
            textBox15.Text = faturano.ToString();
        }


        private void radioButton_Dosya_CheckedChanged(object sender, EventArgs e)
        {
            int D_fiyat = 12;

            if ((radioButton_Dosya.Checked == true))
            {
                groupBox6.Visible = false;  
                textBox19.Text = D_fiyat.ToString();


            }
        }
     
        private void radioButton_Paket_CheckedChanged(object sender, EventArgs e)
        {
            if ((radioButton_Paket.Checked == true))
            {
                groupBox6.Visible = true;
             
            }
        }
    }
}
