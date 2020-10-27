using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsAppYeni
{
    public partial class HGHKargo : Form
    {
        public HGHKargo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HGHKargo.ActiveForm.Visible = false;
            Kargo_Gönder frm = new Kargo_Gönder();
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HGHKargo.ActiveForm.Visible = false;  // buton2 clicklendiğinde anasafya kapanıp Kargo_Takip sayfasının açılması
            Kargo_takip frm = new Kargo_takip(); // açılan yeni formun bu forma bağlantısı
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HGHKargo.ActiveForm.Visible = false;
            Personel frm = new Personel();
            frm.Show();
        }

    }
}
