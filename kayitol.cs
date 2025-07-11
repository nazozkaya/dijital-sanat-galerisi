using Npgsql;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class kayitol : Form
    {
        public kayitol()
        {
            InitializeComponent();
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";

            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                   
                    string adSoyad = txtAd.Text;  
                    string sifre = txtSifre.Text;
                    string rol = cmbRol.SelectedItem.ToString(); 
                    DateTime kayitTarihi = DateTime.Now;
                    DateTime sonGiris = DateTime.Now;

                   
                    string query = @"INSERT INTO kullanicilar 
                             (ad_soyad, sifre, rol, kayit_tarihi, son_giris) 
                             VALUES 
                             (@adSoyad, @sifre, @rol, @kayitTarihi, @sonGiris) 
                             RETURNING id";

                    int kullaniciID = 0;  

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@adSoyad", adSoyad);  
                        cmd.Parameters.AddWithValue("@sifre", sifre);
                        cmd.Parameters.AddWithValue("@rol", rol);
                        cmd.Parameters.AddWithValue("@kayitTarihi", kayitTarihi);
                        cmd.Parameters.AddWithValue("@sonGiris", sonGiris);

                        
                        try
                        {
                            kullaniciID = (int)cmd.ExecuteScalar();  
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kullanıcı kaydı sırasında hata oluştu: " + ex.Message);
                            return;
                        }
                    }

                    
                    if (rol == "Sanatçı")  
                    {
                        string sanatciAdi = txtAd.Text.Trim(); 

                        if (string.IsNullOrEmpty(sanatciAdi))
                        {
                            MessageBox.Show("Sanatçı adı boş olamaz!");
                            return;
                        }

                        string insertSanatciQuery = "INSERT INTO sanatcilar (sanatci_adi, kullanici_id) VALUES (@sanatci_adi, @kullanici_id)";

                        using (var cmd = new NpgsqlCommand(insertSanatciQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@sanatci_adi", sanatciAdi);
                            cmd.Parameters.AddWithValue("@kullanici_id", kullaniciID); 
                            try
                            {
                                cmd.ExecuteNonQuery(); 
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Sanatçı kaydı sırasında hata oluştu: " + ex.Message);
                            }
                        }
                    }

                   
                    MessageBox.Show("Kayıt başarılı!");
                    GirisForm giris = new GirisForm();
                    giris.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void kayitol_Load(object sender, EventArgs e)
        {
            
            cmbRol.Items.Add("Kullanıcı");
            cmbRol.Items.Add("Sanatçı");
            cmbRol.Items.Add("Admin");
            cmbRol.SelectedIndex = 0; 
        }
    }
}
