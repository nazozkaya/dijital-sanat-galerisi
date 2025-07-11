using System;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Bağlantı cümlesi (bilgileri kendi veritabanına göre değiştir)
        string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Bağlantı başarılı!");

                    string query = "SELECT eser_adi FROM eserler";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBox1.Items.Clear();
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetString(0));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnbaglan_Click_1(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi";

            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("PostgreSQL bağlantısı başarılı!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bağlantı hatası: " + ex.Message);
                }
            }
        }
    }
}

