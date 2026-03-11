using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UKM_Sejahtera
{
    internal static class Program
    {
        // Titik masuk utama aplikasi
        [STAThread]
        static void Main()
        {
            // Mengaktifkan gaya visual Windows untuk kontrol
            Application.EnableVisualStyles();

            // Mengatur agar teks dirender menggunakan metode default yang kompatibel
            Application.SetCompatibleTextRenderingDefault(false);

            // Menjalankan form utama aplikasi (Form1)
            Application.Run(new Form1());
        }
    }
}
