using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WindowsFormsApp6;


namespace WindowsFormsApp6 // ← burası senin proje adın olmalı
{
    public static class DbConnection
    {
        public static NpgsqlConnection GetConnection()
        {
            // PostgreSQL bağlantı dizesi
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dijitalsntgalerisi;";

            // NpgsqlConnection ile bağlantıyı döndür
            return new NpgsqlConnection(connString);
        }
    }
}
