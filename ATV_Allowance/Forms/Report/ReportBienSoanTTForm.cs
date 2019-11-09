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
    public partial class ReportBienSoanTTForm : Form
    {
        private BindingSource bs;

        private IReportService reportService;
        private SaveFileDialog saveFileDialog;
        public ReportBienSoanTTForm()
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
                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.BIENSOAN_TTNM);
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
                adgvReportBroadcast.Columns["SoBs_TTN"].HeaderText = ADGVReportHeader.SoBs_TTN;
                adgvReportBroadcast.Columns["DiemBs_TTN"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoBs_Sapo"].HeaderText = ADGVReportHeader.SoBs_Sapo;
                adgvReportBroadcast.Columns["DiemBs_Sapo"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoKThinh"].HeaderText = ADGVReportHeader.SoKThinh;
                adgvReportBroadcast.Columns["DiemKThinh"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoTFile"].HeaderText = ADGVReportHeader.SoTFile;
                adgvReportBroadcast.Columns["DiemTFile"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoBt_Duyet"].HeaderText = ADGVReportHeader.SoBt_Duyet;
                adgvReportBroadcast.Columns["DiemBt_Duyet"].HeaderText = ADGVReportHeader.Diem;


                adgvReportBroadcast.Columns["EmployeeId"].Visible = false;
                adgvReportBroadcast.Columns["Descrease"].Visible = false;
                adgvReportBroadcast.Columns["TotalPoint"].Visible = false;

                adgvReportBroadcast.Columns["SoBai"].Visible = false;
                adgvReportBroadcast.Columns["DiemBai"].Visible = false;
                adgvReportBroadcast.Columns["SoCd"].Visible = false;
                adgvReportBroadcast.Columns["DiemCd"].Visible = false;
                adgvReportBroadcast.Columns["SoPv"].Visible = false;
                adgvReportBroadcast.Columns["DiemPv"].Visible = false;
                adgvReportBroadcast.Columns["SoSD"].Visible = false;
                adgvReportBroadcast.Columns["DiemSD"].Visible = false;

                adgvReportBroadcast.Columns["SoTTh_Gnh"].Visible = false;
                adgvReportBroadcast.Columns["DiemTTh_Gnh"].Visible = false;
                adgvReportBroadcast.Columns["SoCde"].Visible = false;
                adgvReportBroadcast.Columns["DiemCde"].Visible = false;
                adgvReportBroadcast.Columns["SoBs_DCT"].Visible = false;
                adgvReportBroadcast.Columns["DiemBs_DCT"].Visible = false;
                adgvReportBroadcast.Columns["SoBt_Dd"].Visible = false;
                adgvReportBroadcast.Columns["DiemBt_Dd"].Visible = false;

                adgvReportBroadcast.Columns["SoTin"].Visible = false;
                adgvReportBroadcast.Columns["DiemTin"].Visible = false;
                adgvReportBroadcast.Columns["SoPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemPsu"].Visible = false;
                adgvReportBroadcast.Columns["SoQtin"].Visible = false;
                adgvReportBroadcast.Columns["DiemQtin"].Visible = false;
                adgvReportBroadcast.Columns["SoQPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemQPsu"].Visible = false;
                adgvReportBroadcast.Columns["SoTLT"].Visible = false;
                adgvReportBroadcast.Columns["DiemTLT"].Visible = false;
                adgvReportBroadcast.Columns["SoThop"].Visible = false;
                adgvReportBroadcast.Columns["DiemThop"].Visible = false;

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
            saveFileDialog.FileName = $"BaoCao_BS_TTNM_{cbRole.Text}_{dtpEnddate.Value.Month}{dtpEnddate.Value.Year}.xlsx";
            reportService = new ReportService();
            var data = reportService.GetReportBSTTNM(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.BIENSOAN_TTNM);

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
            ListEmployeeDeduction deductionForm = new ListEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, ArticleType.BIENSOAN_TTNM, (int)cbRole.SelectedValue);
            deductionForm.ShowDialog();
        }
    }
}
