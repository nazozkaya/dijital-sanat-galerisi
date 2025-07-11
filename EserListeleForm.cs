using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using WindowsFormsApp6;

namespace DijitalSanatGalerisi
{
    public partial class EserListeleForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";
        private int kullaniciId;

        public EserListeleForm(int girisYapanKullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = girisYapanKullaniciId;
        }

        private void EserListeleForm_Load(object sender, EventArgs e)
        {
            SanatcilariYukle();
            KategorileriYukle();
            EserleriListele();
        }

        private void SanatcilariYukle()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, sanatci_adi FROM sanatcilar ORDER BY sanatci_adi";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

              
                DataRow row = dt.NewRow();
                row["id"] = DBNull.Value;
                row["sanatci_adi"] = "Tümü";
                dt.Rows.InsertAt(row, 0);

                cmbSanatci.DisplayMember = "sanatci_adi";
                cmbSanatci.ValueMember = "id";
                cmbSanatci.DataSource = dt;
            }
        }

        private void KategorileriYukle()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DISTINCT kategori FROM eserler ORDER BY kategori";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                DataRow row = dt.NewRow();
                row["kategori"] = "Tümü";
                dt.Rows.InsertAt(row, 0);

                cmbKategori.DisplayMember = "kategori";
                cmbKategori.ValueMember = "kategori";
                cmbKategori.DataSource = dt;
            }
        }

        private void EserleriListele()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT e.id, e.baslik, e.kategori, s.sanatci_adi, e.resim_yolu FROM eserler e " +
                               "JOIN sanatcilar s ON e.sanatci_id = s.id WHERE 1=1";

                if (cmbSanatci.SelectedValue != null && cmbSanatci.SelectedValue.ToString() != "" && cmbSanatci.Text != "Tümü")
                {
                    query += " AND s.id = @sanatciId";
                }

                if (cmbKategori.SelectedValue != null && cmbKategori.Text != "Tümü")
                {
                    query += " AND e.kategori = @kategori";
                }

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                if (cmbSanatci.SelectedValue != null && cmbSanatci.Text != "Tümü")
                {
                    cmd.Parameters.AddWithValue("@sanatciId", Convert.ToInt32(cmbSanatci.SelectedValue));
                }

                if (cmbKategori.SelectedValue != null && cmbKategori.Text != "Tümü")
                {
                    cmd.Parameters.AddWithValue("@kategori", cmbKategori.SelectedValue.ToString());
                }

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvEserler.DataSource = dt;

                
                if (!dgvEserler.Columns.Contains("Resim"))
                {
                    DataGridViewImageColumn resimKolon = new DataGridViewImageColumn();
                    resimKolon.Name = "Resim";
                    resimKolon.HeaderText = "Resim";
                    resimKolon.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgvEserler.Columns.Add(resimKolon);
                }

                for (int i = 0; i < dgvEserler.Rows.Count; i++)
                {
                    string yol = dgvEserler.Rows[i].Cells["resim_yolu"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(yol) && File.Exists(yol))
                        dgvEserler.Rows[i].Cells["Resim"].Value = Image.FromFile(yol);
                    else
                        dgvEserler.Rows[i].Cells["Resim"].Value = null;
                }

                dgvEserler.Columns["resim_yolu"].Visible = false;
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            EserleriListele();
        }

        private void btnFavorilereEkle_Click(object sender, EventArgs e)
        {
            if (kullaniciId <= 0)
            {
                MessageBox.Show("Geçersiz kullanıcı. Lütfen tekrar giriş yapın.");
                return;
            }

            if (dgvEserler.SelectedRows.Count > 0)
            {
                int eserId = Convert.ToInt32(dgvEserler.SelectedRows[0].Cells["id"].Value);
                FavorilereEkle(kullaniciId, eserId);
            }
            else
            {
                MessageBox.Show("Lütfen favorilere eklemek için bir eser seçin.");
            }
        }

        private void FavorilereEkle(int kullaniciId, int eserId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO favoriler (kullanici_id, eser_id) VALUES (@kullaniciId, @eserId)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    cmd.Parameters.AddWithValue("@eserId", eserId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Eser favorilere eklendi.");
                }
            }
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            AnaSayfaForm ana = new AnaSayfaForm(kullaniciId);
            ana.Show();
            this.Hide();
        }
    }
}
