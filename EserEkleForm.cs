using Npgsql;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class EserEkleForm : Form
    {

        private int kullaniciId;
        private string secilenResimYolu = "";  
        private NpgsqlConnection conn;
        private readonly Label lblAdSoyad;
        private int sanatciId;


        public EserEkleForm(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId; 
            SanatciAdiniYukle();
            



        }


        private void SanatciAdiniYukle()
        {
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT id, sanatci_adi FROM sanatcilar WHERE kullanici_id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", kullaniciId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtSanatciAdi.Text = reader["sanatci_adi"].ToString();
                            txtSanatciAdi.ReadOnly = true;

                            // 🔥 SANATÇI ID’Yİ GÖSTER
                            sanatciId = Convert.ToInt32(reader["id"]);
                            MessageBox.Show("Sanatçı ID: " + sanatciId);
                        }
                        else
                        {
                            txtSanatciAdi.Text = "Bilinmiyor";
                        }
                    }
                }
            }
        }




        private void EserEkleForm_Load(object sender, EventArgs e)
        {
            cmbKategori.Items.AddRange(new string[] { "Soyut Sanat", "Portreler", "Manzara", "Figüratif", "Fotoğraf" });
            cmbSatisDurumu.Items.AddRange(new string[] { "Satışta", "Satışta Değil" });

            cmbKategori.SelectedIndex = 0;
            cmbSatisDurumu.SelectedIndex = 0;


            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi"))
            {
                conn.Open();
                string sql = "SELECT  sanatci_adi FROM sanatcilar WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", kullaniciId);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        txtSanatciAdi.Text = result.ToString();
                          

                    }
                    else
                    {
                        txtSanatciAdi.Text = "bilinmiyor";
                    }
                }
            }
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbResim.Image = new Bitmap(ofd.FileName);
                secilenResimYolu = ofd.FileName;
            }
        }

        private void btnEserEkle_Click(object sender, EventArgs e)
        {

            

            string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";

            // Girdi kontrolleri
            if (string.IsNullOrWhiteSpace(txtEserAdi.Text) || string.IsNullOrWhiteSpace(txtSanatciAdi.Text))
            {
                MessageBox.Show("Eser adı ve sanatçı adı boş bırakılamaz.");
                return;
            }

            if (!int.TryParse(txtStokMiktari.Text, out int stokMiktari))
            {
                MessageBox.Show("Stok miktarı geçerli bir sayı olmalıdır.");
                return;
            }

            if (!decimal.TryParse(txtFiyat.Text, out decimal fiyat))
            {
                MessageBox.Show("Fiyat geçerli bir sayı olmalıdır.");
                return;
            }

            if (pbResim.Image == null || string.IsNullOrWhiteSpace(secilenResimYolu))
            {
                MessageBox.Show("Lütfen bir resim seçiniz.");
                return;
            }

            
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                
                string sanatciAdi = txtSanatciAdi.Text.Trim();
                string getSanatciIdQuery = "SELECT id FROM sanatcilar WHERE sanatci_adi = @sanatci_adi";

                int sanatciID;
                using (var cmd = new NpgsqlCommand(getSanatciIdQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@sanatci_adi", sanatciAdi);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Sanatçı adı bulunamadı. Lütfen geçerli bir sanatçı adı girin.");
                        return;
                    }

                    sanatciID = Convert.ToInt32(result);
                }

               
                string eserAdi = txtEserAdi.Text.Trim();
                string tarih = dtpTarih.Value.ToString("yyyy-MM-dd");
                string kategori = cmbKategori.SelectedItem.ToString();
                string satisDurumu = cmbSatisDurumu.SelectedItem.ToString();
                string aciklama = txtAciklama.Text;

                
                string insertEserQuery = @"
INSERT INTO eserler 
(sanatci_id, baslik, yukleme_tarihi, kategori, aciklama, resim_yolu, satis_durumu, stok_miktari, fiyat, sanatci_adi)
VALUES 
(@sanatci_id, @baslik, @yukleme_tarihi, @kategori, @aciklama, @resim_yolu, @satis_durumu, @stok_miktari, @fiyat, @sanatci_adi)";

                using (var cmd = new NpgsqlCommand(insertEserQuery, conn))
                {
                    
                    cmd.Parameters.AddWithValue("@sanatci_id", sanatciID);
                    cmd.Parameters.AddWithValue("@baslik", eserAdi); 
                    cmd.Parameters.AddWithValue("@yukleme_tarihi", DateTime.Now); 
                    cmd.Parameters.AddWithValue("@kategori", kategori);
                    cmd.Parameters.AddWithValue("@aciklama", aciklama);
                    cmd.Parameters.AddWithValue("@resim_yolu", secilenResimYolu);
                    cmd.Parameters.AddWithValue("@satis_durumu", satisDurumu);
                    cmd.Parameters.AddWithValue("@stok_miktari", stokMiktari);
                    cmd.Parameters.AddWithValue("@fiyat", fiyat);
                    cmd.Parameters.AddWithValue("@sanatci_adi", txtSanatciAdi.Text);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Eser başarıyla eklendi!");

                       
                        ProfilForm profilForm = (ProfilForm)Application.OpenForms["ProfilForm"];
                        if (profilForm != null)
                        {
                            profilForm.KullaniciEserleriniYukle();  
                        }

                       
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bir hata oluştu. Lütfen tekrar deneyin.");
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfaForm anaForm = new AnaSayfaForm(kullaniciId);
            anaForm.Show();
            this.Close();
        }

        private void txtSanatciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSanatci_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
