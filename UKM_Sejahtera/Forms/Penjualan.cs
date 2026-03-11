using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UKM_Sejahtera.Controllers;

namespace UKM_Sejahtera.Forms
{
    public partial class Penjualan : Form
    {
        public Penjualan()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Event handler ini belum digunakan
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 dashboard = new Form1();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime tanggalMulai = dateTimePicker1.Value.Date;
            DateTime tanggalSelesai = dateTimePicker2.Value.Date;

            Transaction transaksiController = new Transaction();
            var hasilTransaksi = transaksiController.getTransaksi(tanggalMulai, tanggalSelesai);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = hasilTransaksi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak tersedia untuk diekspor.",
                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog simpanDialog = new SaveFileDialog
            {
                Filter = "Text File (*.txt)|*.txt",
                FileName = "LaporanPenjualan.txt"
            };

            if (simpanDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter penulis = new StreamWriter(simpanDialog.FileName))
                    {
                        // Tulis header kolom
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            penulis.Write(dataGridView1.Columns[i].HeaderText);
                            if (i < dataGridView1.Columns.Count - 1)
                                penulis.Write("\t");
                        }
                        penulis.WriteLine();

                        // Tulis isi data baris
                        foreach (DataGridViewRow baris in dataGridView1.Rows)
                        {
                            if (!baris.IsNewRow)
                            {
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    penulis.Write(baris.Cells[i].Value?.ToString());
                                    if (i < dataGridView1.Columns.Count - 1)
                                        penulis.Write("\t");
                                }
                                penulis.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show("Data berhasil diekspor ke file TXT.",
                        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
