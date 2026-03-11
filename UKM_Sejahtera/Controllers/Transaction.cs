using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UKM_Sejahtera.DB;
using UKM_Sejahtera.Models;

namespace UKM_Sejahtera.Controllers
{
    internal class Transaction
    {
        Connection_DB koneksiDatabase = new Connection_DB();

        public List<Transaksi> AmbilTransaksi(DateTime tanggalMulai, DateTime tanggalAkhir)
        {
            List<Transaksi> daftarTransaksi = new List<Transaksi>();

            string perintahSql = @"
                SELECT 
                    t.TransaksiID, 
                    t.Tanggal, 
                    t.KategoriID, 
                    t.Deskripsi, 
                    t.Jumlah, 
                    k.NamaKategori, 
                    k.Tipe AS TipeKategori
                FROM Transaksi t
                INNER JOIN Kategori k ON t.KategoriID = k.KategoriID
                WHERE t.Tanggal >= @StartDate AND t.Tanggal <= @EndDate
                ORDER BY t.Tanggal";

            using (SqlConnection koneksi = new SqlConnection(koneksiDatabase.getterConnection()))
            {
                SqlCommand perintah = new SqlCommand(perintahSql, koneksi);
                perintah.Parameters.AddWithValue("@StartDate", tanggalMulai);
                perintah.Parameters.AddWithValue("@EndDate", tanggalAkhir);

                try
                {
                    koneksi.Open();
                    SqlDataReader pembaca = perintah.ExecuteReader();

                    while (pembaca.Read())
                    {
                        daftarTransaksi.Add(new Transaksi
                        {
                            TransaksiID = (int)pembaca["TransaksiID"],
                            Tanggal = (DateTime)pembaca["Tanggal"],
                            KategoriID = (int)pembaca["KategoriID"],
                            Deskripsi = (string)pembaca["Deskripsi"],
                            Jumlah = (decimal)pembaca["Jumlah"],
                            NamaKategori = (string)pembaca["NamaKategori"],
                            TipeKategori = (string)pembaca["TipeKategori"]
                        });
                    }

                    pembaca.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat mengambil data transaksi: " + ex.Message);
                }
            }

            return daftarTransaksi;
        }
    }
}
