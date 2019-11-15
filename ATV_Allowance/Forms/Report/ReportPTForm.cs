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
    public partial class ReportPTForm : Form
    {

        private BindingSource bs;

        private IReportService reportService;
        private ICriteriaService criteriaService;
        private SaveFileDialog saveFileDialog;

        public ReportPTForm()
        {
            InitializeComponent();
            reportService = new ReportService();
            criteriaService = new CriteriaService();

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

                var percent = criteriaService.GetCriteriaValue(dtpStartdate.Value.Month, dtpStartdate.Value.Year, (int)cbRole.SelectedValue == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
                reportService = new ReportService();
                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.PHAT_THANH);
                SortableBindingList<EmployeePointViewModel> sbl = new SortableBindingList<EmployeePointViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvReportBroadcast.DataSource = bs;
                adgvReportBroadcast.Columns["EmployeeName"].HeaderText = ADGVReportHeader.Name;
                adgvReportBroadcast.Columns["Organization"].HeaderText = ADGVReportHeader.Organization;
                adgvReportBroadcast.Columns["Sum"].HeaderText = ADGVReportHeader.TongCong;
                adgvReportBroadcast.Columns["IncreasePercent"].HeaderText = "Tăng " + percent + "%";
                adgvReportBroadcast.Columns["IncreasePercent"].DefaultCellStyle.Format = "F1";
                adgvReportBroadcast.Columns["TotalCost"].HeaderText = ADGVReportHeader.TotalCost;
                adgvReportBroadcast.Columns["TotalCost"].DefaultCellStyle.Format = "N0";
                adgvReportBroadcast.Columns["SoTin"].HeaderText = ADGVReportHeader.SoTin;
                adgvReportBroadcast.Columns["DiemTin"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoBai"].HeaderText = ADGVReportHeader.SoBai;
                adgvReportBroadcast.Columns["DiemBai"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoCd"].HeaderText = ADGVReportHeader.SL_CD;
                adgvReportBroadcast.Columns["DiemCd"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoPv"].HeaderText = ADGVReportHeader.SL_PV;
                adgvReportBroadcast.Columns["DiemPv"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoTLT"].HeaderText = ADGVReportHeader.SL_TLT;
                adgvReportBroadcast.Columns["DiemTLT"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoSD"].HeaderText = ADGVReportHeader.SL_SD;
                adgvReportBroadcast.Columns["DiemSD"].HeaderText = ADGVReportHeader.Diem;

                adgvReportBroadcast.Columns["EmployeeId"].Visible = false;
                adgvReportBroadcast.Columns["SoPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemQtin"].Visible = false;
                adgvReportBroadcast.Columns["DiemQPsu"].Visible = false;
                adgvReportBroadcast.Columns["Descrease"].Visible = false;
                adgvReportBroadcast.Columns["TotalPoint"].Visible = false;

                adgvReportBroadcast.Columns["SoTTh_Gnh"].Visible = false;
                adgvReportBroadcast.Columns["DiemTTh_Gnh"].Visible = false;
                adgvReportBroadcast.Columns["SoCde"].Visible = false;
                adgvReportBroadcast.Columns["DiemCde"].Visible = false;
                adgvReportBroadcast.Columns["SoBs_DCT"].Visible = false;
                adgvReportBroadcast.Columns["DiemBs_DCT"].Visible = false;
                adgvReportBroadcast.Columns["SoBt_Dd"].Visible = false;
                adgvReportBroadcast.Columns["DiemBt_Dd"].Visible = false;

                adgvReportBroadcast.Columns["SoQtin"].Visible = false;
                adgvReportBroadcast.Columns["DiemQtin"].Visible = false;
                adgvReportBroadcast.Columns["SoQPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemQPsu"].Visible = false;
                //adgvReportBroadcast.Columns["SoTLT"].Visible = false;
                //adgvReportBroadcast.Columns["DiemTLT"].Visible = false;
                adgvReportBroadcast.Columns["SoThop"].Visible = false;
                adgvReportBroadcast.Columns["DiemThop"].Visible = false;

                adgvReportBroadcast.Columns["SoBs_TTN"].Visible = false;
                adgvReportBroadcast.Columns["DiemBs_TTN"].Visible = false;
                adgvReportBroadcast.Columns["SoBs_Sapo"].Visible = false;
                adgvReportBroadcast.Columns["DiemBs_Sapo"].Visible = false;
                adgvReportBroadcast.Columns["SoKThinh"].Visible = false;
                adgvReportBroadcast.Columns["DiemKThinh"].Visible = false;
                adgvReportBroadcast.Columns["SoTFile"].Visible = false;
                adgvReportBroadcast.Columns["DiemTFile"].Visible = false;
                adgvReportBroadcast.Columns["SoBt_Duyet"].Visible = false;
                adgvReportBroadcast.Columns["DiemBt_Duyet"].Visible = false;

                adgvReportBroadcast.Columns["SoDCT"].Visible = false;
                adgvReportBroadcast.Columns["DiemDCT"].Visible = false;
                adgvReportBroadcast.Columns["SoKTD"].Visible = false;
                adgvReportBroadcast.Columns["DiemKTD"].Visible = false;
                adgvReportBroadcast.Columns["SoTCT"].Visible = false;
                adgvReportBroadcast.Columns["DiemTCT"].Visible = false;
                adgvReportBroadcast.Columns["SoKT_TH"].Visible = false;
                adgvReportBroadcast.Columns["DiemKT_TH"].Visible = false;

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
            saveFileDialog.FileName = $"BaoCao_PT_{cbRole.Text}_{dtpEnddate.Value.Month}{dtpEnddate.Value.Year}.xlsx";
            reportService = new ReportService();
            var data = reportService.GetReportPT(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.PHAT_THANH);

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
            //ListEmployeeDeduction deductionForm = new ListEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, ArticleType.PHAT_THANH, (int)cbRole.SelectedValue);
            ListEmployeeDeduction deductionForm = new ListEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, ArticleType.BIENSOAN_TTNM, EmployeeRole.PV);
            deductionForm.ShowDialog();
        }
    }
}
