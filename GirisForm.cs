using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp6
{
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";

            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string kullaniciAdi = txtKullaniciAdi.Text;
                    string sifre = txtSifre.Text;

                    string query = @"SELECT * FROM kullanicilar 
                     WHERE ad_soyad = @adi AND sifre = @sifre";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@adi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@sifre", sifre);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Giriş başarılı!");

                                int girisYapanKullaniciId = Convert.ToInt32(reader["id"]);
                                string rol = reader["rol"].ToString(); // Kullanıcı rolü

                                this.Hide();
                                AnaSayfaForm ana = new AnaSayfaForm(girisYapanKullaniciId);
                                ana.Show();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            kayitol kayitForm = new kayitol();
            kayitForm.Show();
            this.Hide();
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {

        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
