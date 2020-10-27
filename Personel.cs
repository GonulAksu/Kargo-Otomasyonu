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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=HUMEYRAA\SQLEXPRESS01;Initial Catalog=HGH_Kargo;Integrated Security=True");
    

        private void button1_Ekle (object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand kayitekle = new SqlCommand("insert into Personel(ad,soyad,tc,tel,d_tarih,maas,gorev,durum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                kayitekle.Parameters.AddWithValue("@p1", textBox1.Text);
                kayitekle.Parameters.AddWithValue("@p2", textBox2.Text);
                kayitekle.Parameters.AddWithValue("@p3", textBox5.Text);
                kayitekle.Parameters.AddWithValue("@p4", textBox3.Text);
                kayitekle.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
                kayitekle.Parameters.AddWithValue("@p6", textBox4.Text);
                kayitekle.Parameters.AddWithValue("@p7", textBox6.Text);
                kayitekle.Parameters.AddWithValue("@p8", textBox7.Text);

                kayitekle.ExecuteNonQuery(); //Parametreler üzerinde değişiklik yapmak için kullanılan bağlantı komutudur.
                baglanti.Close();
                MessageBox.Show("Personel Ekleme Başarılı");


            }
        }

        private void button2_Sil(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand kayitsil = new SqlCommand("Delete from Personel WHERE ad = @adi", baglanti);
            kayitsil.Parameters.AddWithValue("@adi", textBox1.Text);
            kayitsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme Başarılı");
            
        }

        private void button3_Güncelle(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutgüncelle = new SqlCommand("UPDATE Personel SET tc='" + textBox5.Text + "',ad='" + textBox1.Text + "',soyad='" +textBox2.Text+"',d_tarih='" + maskedTextBox1.Text + "',tel='" + textBox3.Text + "',maas='" + textBox4.Text + "',gorev='" + textBox6.Text + "',durum='" + textBox7.Text + "'where tc='" + textBox5.Text + "'", baglanti);
            komutgüncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı");
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string tc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string d_tarih = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string tel = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string maas = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            string gorev = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            string durum = dataGridView1.Rows[secilen].Cells[8].Value.ToString();

            textBox5.Text = tc;
            textBox1.Text = ad;
            textBox2.Text = soyad;
            maskedTextBox1.Text = d_tarih;
            textBox3.Text = tel;
            textBox4.Text = maas;
            textBox6.Text = gorev;
            textBox7.Text = durum;
           
        }



        private void button6_Listele(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Personel", baglanti);   //DataSet ile veritabanı arasında köprü.DataSet sanal toblodur.
            DataSet ds = new DataSet(); // sanal toblosu nesnesi oluşturduk
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            

        }

        private void button4_Ara(object sender, EventArgs e)
        {
            
            SqlDataAdapter da= new SqlDataAdapter("select * from Personel where ad='" + textBox8.Text + "'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            MessageBox.Show("Arama Başarılı");

        }

        private void button5_Anasayfa(object sender, EventArgs e)
        {
            Personel.ActiveForm.Visible = false;
            HGHKargo frm = new HGHKargo();
            frm.Show();
        }
    }
}
