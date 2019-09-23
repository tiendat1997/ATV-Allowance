using ATV_Allowance.Common;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.Report
{
    public partial class ReportBroadcastForm : Form
    {
        private BindingSource bs;

        private IReportService reportService;
        private SaveFileDialog saveFileDialog;

        public ReportBroadcastForm()
        {
            InitializeComponent();
            reportService = new ReportService();

            InitValue();
            LoadReport();
        }

        public void InitValue()
        {
            dtpMonth.Value = DateTime.Now;
            dtpYear.Value = DateTime.Now;

            dtpStartdate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);
            dtpEnddate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpYear.Value.Year, dtpMonth.Value.Month));

            var positions = new List<PositionViewModel>();
            positions.Add(new PositionViewModel
            {
                Id = EmployeeRole.PV,
                Code = "PV"
            });
            positions.Add(new PositionViewModel
            {
                Id = EmployeeRole.CTV,
                Code = "CTV"
            });

            cbRole.DataSource = positions;
            cbRole.DisplayMember = "Code";
            cbRole.ValueMember = "Id";

            cbRole.SelectedValue = EmployeeRole.PV;

            InitSaveFile();
        }

        public void InitSaveFile()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Lưu báo cáo";
        }

        private void AutoSize()
        {
        }

        private void LoadReport()
        {
            IReportService reportService = null;
            try
            {

                reportService = new ReportService();
                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.THOI_SU);
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
                adgvReportBroadcast.Columns["Sum"].HeaderText = ADGVReportHeader.Cong;
                adgvReportBroadcast.Columns["Descrease"].HeaderText = ADGVReportHeader.TruChiTieu;
                adgvReportBroadcast.Columns["TotalPoint"].HeaderText = ADGVReportHeader.TotalPoint;
                adgvReportBroadcast.Columns["IncreasePercent"].HeaderText = ADGVReportHeader.TangGiam;
                adgvReportBroadcast.Columns["TotalCost"].HeaderText = ADGVReportHeader.TotalCost;
                adgvReportBroadcast.Columns["TotalCost"].DefaultCellStyle.Format = "N0";

                adgvReportBroadcast.Columns["EmployeeId"].Visible = false;

                txtPoint.Text = list.Sum(e => e.TotalPoint).ToString();
                txtCost.Text = list.Sum(e => e.TotalCost).ToString("N0") + " vnđ";

                

                AutoSize();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = $"BaoCao_TS_{cbRole.Text}_{dtpEnddate.Value.Month}{dtpEnddate.Value.Year}.xlsx";
            var data = reportService.GetReportTS(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.THOI_SU);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = Path.GetFullPath(saveFileDialog.FileName);
                File.WriteAllBytes(path, data);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            dtpStartdate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);
            dtpEnddate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpYear.Value.Year, dtpMonth.Value.Month));

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            dtpStartdate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);
            dtpEnddate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpYear.Value.Year, dtpMonth.Value.Month));

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
