using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKM_Sejahtera.Models
{
    internal class Transaksi
    {
        // Properti untuk menyimpan ID transaksi
        public int TransaksiID { get; set; }

        // Tanggal transaksi dilakukan
        public DateTime Tanggal { get; set; }

        // ID kategori dari transaksi
        public int KategoriID { get; set; }

        // Deskripsi atau keterangan transaksi
        public string Deskripsi { get; set; }

        // Jumlah nominal transaksi
        public decimal Jumlah { get; set; }

        // Nama kategori dari transaksi (join dari tabel Kategori)
        public string NamaKategori { get; set; }

        // Tipe kategori, bisa "Pemasukan" atau "Pengeluaran"
        public string TipeKategori { get; set; }
    }
}
