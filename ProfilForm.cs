using Npgsql;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class ProfilForm : Form
    {
        public int GirisYapanSanatciId { get; set; }
        private int sanatciId;
        private string connectionString = "Host=localhost;Port=5432;Database=dijitalsntgalerisi;Username=postgres;Password=1234";
        private int girisYapanKullaniciId;

       
        public ProfilForm(int girisYapanKullaniciId)
        {
            InitializeComponent();
            this.girisYapanKullaniciId = girisYapanKullaniciId;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT id FROM sanatcilar WHERE kullanici_id = @kullaniciId";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", this.girisYapanKullaniciId);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        this.sanatciId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Sanatçı ID'si bulunamadı.");
                        this.sanatciId = 0;
                    }
                }
            }
        }
        private void ProfilForm_Load(object sender, EventArgs e)
        {
            panelAdSoyadGuncelle.Visible = false; 
            panelSifreGuncelle.Visible=false;
            KullaniciBilgileriniYukle();
            KullaniciEserleriniYukle();
        }

        private void KullaniciBilgileriniYukle()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT sanatci_adi FROM sanatcilar WHERE id = @kullaniciId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", sanatciId);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblAdSoyad.Text = reader["sanatci_adi"].ToString();
                            txtAdSoyad.Text = reader["sanatci_adi"].ToString();
                        }
                    }
                }
            }
        }

       public void KullaniciEserleriniYukle()
        {
            flwEserGaleri.Controls.Clear();  

           
            

            int sanatciId = this.sanatciId;

            MessageBox.Show("Sanatçı ID'si: " + sanatciId.ToString());

          
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id, baslik, resim_yolu, stok_miktari, satis_durumu, fiyat FROM eserler WHERE sanatci_id = @sanatciId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sanatciId", sanatciId);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Hiç eser bulunamadı.");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string resimYolu = reader["resim_yolu"].ToString();
                                string baslik = reader["baslik"].ToString();
                                int stokMiktari = Convert.ToInt32(reader["stok_miktari"]);
                                string satisDurumu = reader["satis_durumu"].ToString();

                                if (!File.Exists(resimYolu))
                                {
                                    resimYolu = "path_to_placeholder_image"; 
                                }

                                Panel eserPanel = new Panel
                                {
                                    Width = 200,
                                    Height = 300,
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Margin = new Padding(10),
                                    Dock = DockStyle.Top
                                };

                                PictureBox pictureBox = new PictureBox
                                {
                                    Width = 180,
                                    Height = 200,
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Image = Image.FromFile(resimYolu),
                                    Dock = DockStyle.Top
                                };

                                Label lblEserAdi = new Label
                                {
                                    Text = baslik,
                                    Width = 180,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.Top
                                };

                                Button btnDuzenle = new Button
                                {
                                    Text = "Düzenle",
                                    Width = 180,
                                    Height = 30,
                                    Dock = DockStyle.Bottom,
                                    Tag = new
                                    {
                                        EserId = reader["id"],
                                        EserAdi = baslik,
                                        ResimYolu = resimYolu,
                                        StokMiktari = stokMiktari,
                                        SatisDurumu = satisDurumu,
                                        Fiyat = reader["fiyat"] != DBNull.Value ? Convert.ToDecimal(reader["fiyat"]) : 0
                                    }
                                };
                                btnDuzenle.Click += BtnDuzenle_Click;

                                eserPanel.Controls.Add(pictureBox);
                                eserPanel.Controls.Add(lblEserAdi);
                                eserPanel.Controls.Add(btnDuzenle);

                                flwEserGaleri.Controls.Add(eserPanel);
                            }
                        }
                    }
                }
            }
        }
        


        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                dynamic eserBilgi = btn.Tag;
                EserDuzenlemeFormu eserForm = new EserDuzenlemeFormu(
                    (int)eserBilgi.EserId,
                    eserBilgi.EserAdi.ToString(),
                    eserBilgi.ResimYolu.ToString(),
                    Convert.ToInt32(eserBilgi.StokMiktari),
                    eserBilgi.SatisDurumu.ToString(),
                        Convert.ToDecimal(eserBilgi.Fiyat) 

                );
                eserForm.ShowDialog();
                KullaniciEserleriniYukle(); 
            }
        }

        private void BtnBilgilerimiGuncelle_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnAdGuncelle_Click(object sender, EventArgs e)
        {
            string yeniAdSoyad = txtAdSoyad.Text.Trim();
            if (string.IsNullOrEmpty(yeniAdSoyad))
            {
                MessageBox.Show("Ad soyad boş olamaz.");
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE sanatcilar SET sanatci_adi = @adSoyad WHERE kullanici_id = @kullaniciId";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@adSoyad", yeniAdSoyad);
                    cmd.Parameters.AddWithValue("@kullaniciId", girisYapanKullaniciId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Ad Soyad güncellendi.");
            lblAdSoyad.Text = yeniAdSoyad;
        }

        private void BtnSifreGuncelle_Click(object sender, EventArgs e)
        {
            string eskiSifre = txtEskiSifre.Text.Trim();
            string yeniSifre = txtYeniSifre.Text.Trim();

            if (string.IsNullOrEmpty(eskiSifre) || string.IsNullOrEmpty(yeniSifre))
            {
                MessageBox.Show("Şifre alanları boş olamaz.");
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

               
                string sql = "SELECT sifre FROM kullanicilar WHERE id = @kullaniciId";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", girisYapanKullaniciId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string mevcutSifre = reader.GetString(0);

                            if (mevcutSifre == eskiSifre)
                            {
                                reader.Close(); 

                                
                                string updateSql = "UPDATE kullanicilar SET sifre = @yeniSifre WHERE id = @kullaniciId";
                                using (var updateCmd = new NpgsqlCommand(updateSql, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                                    updateCmd.Parameters.AddWithValue("@kullaniciId", girisYapanKullaniciId);
                                    updateCmd.ExecuteNonQuery();
                                }

                                MessageBox.Show("Şifre başarıyla güncellendi.");
                            }
                            else
                            {
                                MessageBox.Show("Eski şifre yanlış.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bulunamadı.");
                        }
                    }
                }
            }
        }

        private void btnBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            panelSifreGuncelle.Visible = !panelSifreGuncelle.Visible;
            panelAdSoyadGuncelle.Visible = !panelAdSoyadGuncelle.Visible;
        }

        private void flwEserGaleri_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EserDuzenlemeFormu eserDuzenlemeForm = new EserDuzenlemeFormu();
            eserDuzenlemeForm.Show();
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {

            AnaSayfaForm anaForm = new AnaSayfaForm(girisYapanKullaniciId);
            anaForm.Show();
            this.Close();
        }

        private void bindingNavigatorCountItem_Click(object sender, EventArgs e)
        {

        }
    }
}