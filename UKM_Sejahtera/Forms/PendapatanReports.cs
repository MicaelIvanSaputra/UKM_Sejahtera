using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UKM_Sejahtera.Reports;

namespace UKM_Sejahtera.Forms
{
    public partial class PendapatanReports : Form
    {
        public PendapatanReports()
        {
            InitializeComponent();
        }

        private void PendapatanReport_Load(object sender, EventArgs e)
        {
            ukm_sejahteraDataSet1 dataset = new ukm_sejahteraDataSet1();

            var kategoriAdapter = new ukm_sejahteraDataSet1TableAdapters.KategoriTableAdapter();
            kategoriAdapter.Fill(dataset.Kategori);

            var transaksiAdapter = new ukm_sejahteraDataSet1TableAdapters.TransaksiTableAdapter();
            transaksiAdapter.Fill(dataset.Transaksi);

            var report = new PendapatanReport();
            report.SetDataSource(dataset);

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
