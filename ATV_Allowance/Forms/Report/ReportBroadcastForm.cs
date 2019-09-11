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
        public ReportBroadcastForm()
        {
            InitializeComponent();
            loadReport();
        }

        private void loadReport()
        {
            IReportService reportService = null;
            try
            {

                reportService = new ReportService();
                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(DateTime.Now, DateTime.Now, EmployeeRole.PV, 3000);
                SortableBindingList<EmployeePointViewModel> sbl = new SortableBindingList<EmployeePointViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvReportBroadcast.DataSource = bs;
                adgvReportBroadcast.Columns["EmployeeName"].HeaderText = ADGVReportHeader.Name;
                adgvReportBroadcast.Columns["Organization"].HeaderText = ADGVReportHeader.Organization;
                adgvReportBroadcast.Columns["ArticleAmount"].HeaderText = ADGVReportHeader.ArticleAmount;
                adgvReportBroadcast.Columns["ArticlePoint"].HeaderText = ADGVReportHeader.ArticlePoint;
                adgvReportBroadcast.Columns["SpeechAmount"].HeaderText = ADGVReportHeader.SpeechAmount;
                adgvReportBroadcast.Columns["SpeechPoint"].HeaderText = ADGVReportHeader.SpeechPoint;
                adgvReportBroadcast.Columns["MajorAmount"].HeaderText = ADGVReportHeader.MajorAmount;
                adgvReportBroadcast.Columns["MajorPoint"].HeaderText = ADGVReportHeader.MajorPoint;
                adgvReportBroadcast.Columns["PVAmount"].HeaderText = ADGVReportHeader.PVAmount;
                adgvReportBroadcast.Columns["PVPoint"].HeaderText = ADGVReportHeader.PVPoint;
                adgvReportBroadcast.Columns["BSAmount"].HeaderText = ADGVReportHeader.BSAmount;
                adgvReportBroadcast.Columns["BSPoint"].HeaderText = ADGVReportHeader.BSPoint;
                adgvReportBroadcast.Columns["BTAmount"].HeaderText = ADGVReportHeader.BTAmount;
                adgvReportBroadcast.Columns["BTPoint"].HeaderText = ADGVReportHeader.BTPoint;
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
    }
}
