using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UKM_Sejahtera.Forms;

namespace UKM_Sejahtera
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan penjualan = new Penjualan();
            penjualan.Show();
            this.Hide();
        }

        private void pendapatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendapatanReports pendapatanReport = new PendapatanReports();
            pendapatanReport.Show();
            this.Hide();
        }
    }
}
