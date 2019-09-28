using ATV_Allowance.Common;
using ATV_Allowance.Forms.DeductionForms;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
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
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.Report
{
    public partial class ReportPTTTForm : Form
    {
        private BindingSource bs;

        private IReportService reportService;
        private SaveFileDialog saveFileDialog;
        public ReportPTTTForm()
        {
            InitializeComponent();
            reportService = new ReportService();

            InitValue();
            LoadReport();
        }

        public void InitValue()
        {
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

            dtpMonth.Value = DateTime.Now;
            dtpYear.Value = DateTime.Now;

            dtpStartdate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);
            dtpEnddate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpYear.Value.Year, dtpMonth.Value.Month));

            InitSaveFile();
        }

        public void InitSaveFile()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Lưu báo cáo";
        }

        private void LoadReport()
        {

            if (cbRole.SelectedValue.GetType() != typeof(int))
            {
                return;
            }

            try
            {

                reportService = new ReportService();
                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.PHAT_THANH_TT);
                SortableBindingList<EmployeePointViewModel> sbl = new SortableBindingList<EmployeePointViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvReportBroadcast.DataSource = bs;
                adgvReportBroadcast.Columns["EmployeeName"].HeaderText = ADGVReportHeader.Name;
                adgvReportBroadcast.Columns["Organization"].HeaderText = ADGVReportHeader.Organization;
                adgvReportBroadcast.Columns["Sum"].HeaderText = ADGVReportHeader.TongCong;
                adgvReportBroadcast.Columns["IncreasePercent"].HeaderText = ADGVReportHeader.TangGiam;
                adgvReportBroadcast.Columns["IncreasePercent"].DefaultCellStyle.Format = "F1";
                adgvReportBroadcast.Columns["TotalCost"].HeaderText = ADGVReportHeader.TotalCost;
                adgvReportBroadcast.Columns["TotalCost"].DefaultCellStyle.Format = "N0";

                adgvReportBroadcast.Columns["EmployeeId"].Visible = false;
                adgvReportBroadcast.Columns["SoPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemQtin"].Visible = false;
                adgvReportBroadcast.Columns["DiemQPsu"].Visible = false;
                adgvReportBroadcast.Columns["Descrease"].Visible = false;
                adgvReportBroadcast.Columns["TotalPoint"].Visible = false;
                adgvReportBroadcast.Columns["SoBai"].Visible = false;
                adgvReportBroadcast.Columns["DiemBai"].Visible = false;
                adgvReportBroadcast.Columns["SoCd"].Visible = false;
                adgvReportBroadcast.Columns["DiemCd"].Visible = false;
                adgvReportBroadcast.Columns["SoPv"].Visible = false;
                adgvReportBroadcast.Columns["DiemPv"].Visible = false;
                adgvReportBroadcast.Columns["SoTLT"].Visible = false;
                adgvReportBroadcast.Columns["DiemTLT"].Visible = false;
                adgvReportBroadcast.Columns["SoSD"].Visible = false;
                adgvReportBroadcast.Columns["DiemSD"].Visible = false;

                txtPoint.Text = list.Sum(e => e.TotalPoint).ToString();
                txtCost.Text = list.Sum(e => e.TotalCost).ToString("N0") + " vnđ";

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

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = $"BaoCao_PTTT_{cbRole.Text}_{dtpEnddate.Value.Month}{dtpEnddate.Value.Year}.xlsx";
            reportService = new ReportService();
            var data = reportService.GetReportPTTT(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.PHAT_THANH_TT);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = Path.GetFullPath(saveFileDialog.FileName);
                File.WriteAllBytes(path, data);
            }
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            dtpStartdate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);
            dtpEnddate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpYear.Value.Year, dtpMonth.Value.Month));
            LoadReport();

        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            dtpStartdate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);
            dtpEnddate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpYear.Value.Year, dtpMonth.Value.Month));
            LoadReport();

        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void dtpStartdate_ValueChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void dtpEnddate_ValueChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void edtPrice_ValueChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnDeduction_Click(object sender, EventArgs e)
        {
            ListEmployeeDeduction deductionForm = new ListEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, ArticleType.PHAT_THANH, (int)cbRole.SelectedValue);
            deductionForm.ShowDialog();
        }
    }
}
