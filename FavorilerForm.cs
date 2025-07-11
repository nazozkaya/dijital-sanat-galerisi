using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp6
{
    public partial class FavorilerForm : Form
    {
        private int kullaniciId;
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";

        public FavorilerForm(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
        }

        private void FavorilerForm_Load(object sender, EventArgs e)
        {
            FavorileriYukle();
        }

        private void FavorileriYukle()
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = @"
            SELECT e.id, e.baslik, e.aciklama, e.fiyat, e.resim_yolu, f.added_at
            FROM favoriler f
            JOIN eserler e ON f.eser_id = e.id
            WHERE f.kullanici_id = @kullanici_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kullanici_id", kullaniciId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dgvFavoriler.Columns.Clear();  
                        dgvFavoriler.DataSource = dt;

                        
                        if (!dgvFavoriler.Columns.Contains("Resim"))
                        {
                            DataGridViewImageColumn resimKolon = new DataGridViewImageColumn();
                            resimKolon.Name = "Resim";
                            resimKolon.HeaderText = "Eser Görseli";
                            resimKolon.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            dgvFavoriler.Columns.Add(resimKolon);
                        }

                        
                        dgvFavoriler.Columns["resim_yolu"].Visible = false; 

                        
                        for (int i = 0; i < dgvFavoriler.Rows.Count; i++)
                        {
                            string yol = dgvFavoriler.Rows[i].Cells["resim_yolu"].Value?.ToString();
                            if (!string.IsNullOrEmpty(yol) && File.Exists(yol))
                            {
                                dgvFavoriler.Rows[i].Cells["Resim"].Value = Image.FromFile(yol);
                            }
                            else
                            {
                                dgvFavoriler.Rows[i].Cells["Resim"].Value = null; 
                            }
                        }

                        dgvFavoriler.RowTemplate.Height = 100; 
                        dgvFavoriler.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; 
                    }
                }
            }
        }

        
        private void FavorilerdenKaldir(int eserId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = @"DELETE FROM favoriler WHERE kullanici_id = @kullanici_id AND eser_id = @eser_id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kullanici_id", kullaniciId);
                        cmd.Parameters.AddWithValue("@eser_id", eserId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Eser favorilerden kaldırıldı!");
                        FavorileriYukle(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        
        private void btnFavorilerdenKaldir_Click(object sender, EventArgs e)
        {
            if (dgvFavoriler.SelectedRows.Count > 0)
            {
                int eserId = Convert.ToInt32(dgvFavoriler.SelectedRows[0].Cells["id"].Value);

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "DELETE FROM favoriler WHERE kullanici_id = @kullaniciId AND eser_id = @eserId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        cmd.Parameters.AddWithValue("@eserId", eserId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Eser favorilerden kaldırıldı.");
                FavorileriYukle(); 
            }
            else
            {
                MessageBox.Show("Lütfen favorilerden kaldırmak için bir eser seçin.");
            }
        }

        
        private void dgvFavoriler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
