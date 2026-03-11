using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKM_Sejahtera.Models
{
    internal class Kategori
    {
        // ID unik untuk setiap kategori
        public int KategoriID { get; set; }

        // Nama kategori, seperti "Makanan", "Transportasi", dll.
        public string NamaKategori { get; set; }

        // Tipe kategori, misalnya "Pemasukan" atau "Pengeluaran"
        public string Tipe { get; set; }
    }
}
