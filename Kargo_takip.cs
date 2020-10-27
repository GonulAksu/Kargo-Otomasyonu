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
    public partial class Kargo_takip : Form
    {
        public Kargo_takip()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=HUMEYRAA\SQLEXPRESS01;Initial Catalog=HGH_Kargo;Integrated Security=True");
      

        private void button3_Click(object sender, EventArgs e)
        {

        SqlCommand cmd = new SqlCommand();
        baglanti.Open();
        cmd.Connection = baglanti;
        cmd.CommandText = "SELECT * FROM Fatura where takip_no='" + comboBox1.Text + "'";

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox1.Text = dr["gtc"].ToString();
                textBox3.Text = dr["atc"].ToString();
                textBox2.Text = dr["gadres"].ToString();
                textBox4.Text = dr["aadres"].ToString();
                textBox5.Text = dr["notlar"].ToString();
                textBox6.Text = dr["yer"].ToString();
                textBox7.Text = dr["tarih"].ToString();
                textBox8.Text = dr["kargo_durum"].ToString();
                        }

            baglanti.Close();
        }

        private void Kargo_takip_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT * FROM Fatura";
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {

                comboBox1.Items.Add(dr["takip_no"]);

            }



            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Fatura SET yer='" + comboBox2.Text + "',kargo_durum='" + comboBox3.Text + "'where takip_no='" + comboBox1.Text + "'", baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox6.Text = comboBox2.Text;
           
            MessageBox.Show("Müşteri Bilgileri Güncellendi.");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

            baglanti.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT * FROM Yer", baglanti);
            da.Fill(dt);
            comboBox2.Items.Clear();
            comboBox2.Items.Add("---SELECT---");
            foreach (DataRow row in dt.Rows)
            {
                comboBox2.Items.Add(row["sehir"].ToString());
            }
            baglanti.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

            baglanti.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT * FROM Kargo_Durum", baglanti);
            da.Fill(dt);
            comboBox3.Items.Clear();
            comboBox3.Items.Add("---SELECT---");
            foreach (DataRow row in dt.Rows)
            {
                comboBox3.Items.Add(row["kargo_durum"].ToString());
            }
            baglanti.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Kargo_takip.ActiveForm.Visible = false;
            HGHKargo frm = new HGHKargo();
            frm.Show();
        }
    }
}
