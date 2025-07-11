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
    public partial class EserDuzenlemeFormu : Form
    {
        private int eserId;
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";
        private dynamic dynamic1;
        private dynamic dynamic2;
        private dynamic dynamic3;
        private dynamic dynamic4;

        public EserDuzenlemeFormu()
        {
            InitializeComponent(); 

            cmbSatisDurumu.Items.Clear();
            cmbSatisDurumu.Items.Add("Satışta");
            cmbSatisDurumu.Items.Add("Satışta Değil");

            btnGuncelle.Click += BtnGuncelle_Click;
        }

        public EserDuzenlemeFormu( int eserId, string eserAdi, string resimYolu, int stokMiktari, string satisDurumu, decimal fiyat)
        {
            InitializeComponent();
         
            this.eserId = eserId;
            cmbSatisDurumu.Items.Clear();
            cmbSatisDurumu.Items.Add("Satışta");
            cmbSatisDurumu.Items.Add("Satışta Değil");

            txtEserAdi.Text = eserAdi;
            txtStokMiktari.Text = stokMiktari.ToString();
            cmbSatisDurumu.SelectedItem = satisDurumu;

            btnGuncelle.Click += BtnGuncelle_Click;
        }

        public EserDuzenlemeFormu(int eserId, dynamic dynamic1, dynamic dynamic2, dynamic dynamic3, dynamic dynamic4)
        {
            this.eserId = eserId;
            this.dynamic1 = dynamic1;
            this.dynamic2 = dynamic2;
            this.dynamic3 = dynamic3;
            this.dynamic4 = dynamic4;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            string yeniStok = txtStokMiktari.Text?.Trim();
            string yeniSatisDurumu = cmbSatisDurumu.SelectedItem != null ? cmbSatisDurumu.SelectedItem.ToString() : "";

            if (string.IsNullOrWhiteSpace(yeniStok) || string.IsNullOrWhiteSpace(yeniSatisDurumu))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            decimal yeniFiyat;
            if (!decimal.TryParse(txtFiyat.Text.Trim(), out yeniFiyat))
            {
                MessageBox.Show("Geçerli bir fiyat giriniz.");
                return;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string query = "UPDATE eserler SET stok_miktari = @stokMiktari, satis_durumu = @satisDurumu, fiyat = @fiyat WHERE id = @eserId";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@stokMiktari", Convert.ToInt32(yeniStok));
                    cmd.Parameters.AddWithValue("@satisDurumu", yeniSatisDurumu);
                    cmd.Parameters.AddWithValue("@fiyat", yeniFiyat);
                    cmd.Parameters.AddWithValue("@eserId", eserId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Eser başarıyla güncellendi!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız.");
                    }
                }
            }
        }



        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            string eserAdi = txtEserAdi.Text.Trim();
            string stokText = txtStokMiktari.Text.Trim();
            string satisDurumu = cmbSatisDurumu.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(eserAdi) || string.IsNullOrEmpty(stokText) || string.IsNullOrEmpty(satisDurumu))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (!int.TryParse(stokText, out int stokMiktari))
            {
                MessageBox.Show("Stok miktarı sayısal olmalı.");
                return;
            }

            string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi;";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string query = "UPDATE eserler SET stok_miktari = @stok, satis_durumu = @durum WHERE baslik = @adi";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@stok", stokMiktari);
                    cmd.Parameters.AddWithValue("@durum", satisDurumu);
                    cmd.Parameters.AddWithValue("@adi", eserAdi);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("Eser başarıyla güncellendi!");
                    else
                        MessageBox.Show("Eser adı bulunamadı, güncelleme başarısız.");
                }
            }
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
