using ATV_Allowance.Common;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.Report
{
    public partial class ReportBroadcastForm : Form
    {
        private BindingSource bs;

        private IReportService reportService;

        public ReportBroadcastForm()
        {
            InitializeComponent();
            reportService = new ReportService();

            loadReport();
        }

        private void loadReport()
        {
            IReportService reportService = null;
            try
            {

                reportService = new ReportService();
                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(new DateTime(2019,9,1), new DateTime(2019, 9, 30), EmployeeRole.PV, 3000, ArticleType.THOI_SU);
                SortableBindingList<EmployeePointViewModel> sbl = new SortableBindingList<EmployeePointViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvReportBroadcast.DataSource = bs;
                adgvReportBroadcast.Columns["EmployeeName"].HeaderText = ADGVReportHeader.Name;
                adgvReportBroadcast.Columns["Organization"].HeaderText = ADGVReportHeader.Organization;
                adgvReportBroadcast.Columns["SoTin"].HeaderText = ADGVReportHeader.SoTin;
                adgvReportBroadcast.Columns["DiemTin"].HeaderText = ADGVReportHeader.DiemTin;
                adgvReportBroadcast.Columns["SoPsu"].HeaderText = ADGVReportHeader.SoPsu;
                adgvReportBroadcast.Columns["DiemPsu"].HeaderText = ADGVReportHeader.DiemPsu;
                adgvReportBroadcast.Columns["DiemQtin"].HeaderText = ADGVReportHeader.DiemQTin;
                adgvReportBroadcast.Columns["DiemQPsu"].HeaderText = ADGVReportHeader.DiemQPsu;
                adgvReportBroadcast.Columns["TotalPoint"].HeaderText = ADGVReportHeader.TotalPoint;
                adgvReportBroadcast.Columns["IncreasePercent"].HeaderText = ADGVReportHeader.IncreasePercent;
                adgvReportBroadcast.Columns["TotalCost"].HeaderText = ADGVReportHeader.TotalCost;

                adgvReportBroadcast.Columns["EmployeeId"].Visible = false;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reportService = null;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            reportService.GetReportTS(new DateTime(2019, 9, 1), new DateTime(2019, 9, 30), EmployeeRole.PV, 3000, ArticleType.THOI_SU);
        }
    }
}
