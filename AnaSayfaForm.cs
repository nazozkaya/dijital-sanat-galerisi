using DijitalSanatGalerisi;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class AnaSayfaForm : Form
    {
        private int girisYapanKullaniciId; 
        private int sanatciId;
        private string kullaniciId;

       
        public AnaSayfaForm(int girisYapanKullaniciId)
        {
            InitializeComponent();
            this.girisYapanKullaniciId = girisYapanKullaniciId;

            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi"))
            {
                conn.Open();

                string sql = "SELECT id FROM sanatcilar WHERE kullanici_id = @kullaniciId";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", girisYapanKullaniciId);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        sanatciId = Convert.ToInt32(result);
                       
                    }
                    else
                    {
                        MessageBox.Show("Sanatçı ID'si bulunamadı.");
                    }
                }
            }
        }

        public AnaSayfaForm(string kullaniciId)
        {
            this.kullaniciId = kullaniciId;
        }

        private void AnaSayfaForm_Load(object sender, EventArgs e)
        {
            lblhosgeldin.Text = "Hoş geldiniz! Giriş başarılı.";
        }

        private void btnEserEkle_Click(object sender, EventArgs e)
        {
            EserEkleForm eserEkle = new EserEkleForm(sanatciId); 
            eserEkle.ShowDialog();
        }

        private void btnEserListele_Click(object sender, EventArgs e)
        {
            
            EserListeleForm eserListeleForm = new EserListeleForm(girisYapanKullaniciId);
            eserListeleForm.Show();
        }

        private void btnFavoriler_Click(object sender, EventArgs e)
        {
            FavorilerForm favorilerForm = new FavorilerForm(girisYapanKullaniciId);
            favorilerForm.Show();
        }

        private void  btnProfilClick_1(object sender, EventArgs e)
        {
            ProfilForm profilForm = new ProfilForm(girisYapanKullaniciId); 
            profilForm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnCikis_Click_1(object sender, EventArgs e)
        {

        }
    }
}
