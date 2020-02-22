using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
using ATV_Allowance.Forms.DeductionForms;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
using DataService.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.Report
{
    public partial class ReportBienSoanTTForm : Form
    {
        private BindingSource bs;

        private IReportService reportService;
        private ICriteriaService criteriaService;
        private SaveFileDialog saveFileDialog;
        private IAppLogger _logger;
        public ReportBienSoanTTForm()
        {
            _logger = new AppLogger();
            InitializeComponent();
            reportService = new ReportService();
            criteriaService = new CriteriaService();

            InitValue();
            LoadReport();
            adgvReportBroadcast.ReadOnly = true;
            adgvKHK.ReadOnly = true;
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

        private void LoadBSReport()
        {

            if (cbRole.SelectedValue.GetType() != typeof(int))
            {
                return;
            }

            try
            {
                var percent = criteriaService.GetCriteriaValue(dtpStartdate.Value.Month, dtpStartdate.Value.Year, (int)cbRole.SelectedValue == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
                reportService = new ReportService();
                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, Constants.ArticleType.BIENSOAN_TTNM);
                SortableBindingList<EmployeePointViewModel> sbl = new SortableBindingList<EmployeePointViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvReportBroadcast.DataSource = bs;
                adgvReportBroadcast.Columns["EmployeeName"].HeaderText = ADGVReportHeader.Name;
                adgvReportBroadcast.Columns["Organization"].HeaderText = ADGVReportHeader.Organization;
                adgvReportBroadcast.Columns["SumPoint"].HeaderText = ADGVReportHeader.TongCong;
                adgvReportBroadcast.Columns["IncreasePercent"].HeaderText = "Tăng " + percent +"%";
                adgvReportBroadcast.Columns["IncreasePercent"].DefaultCellStyle.Format = "F1";
                adgvReportBroadcast.Columns["Descrease"].HeaderText = ADGVReportHeader.TruChiTieu;
                adgvReportBroadcast.Columns["Descrease"].DefaultCellStyle.Format = "F1";
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
            }
        }

        private void LoadKHKReport()
        {

            if (cbRole.SelectedValue.GetType() != typeof(int))
            {
                return;
            }

            try
            {

                reportService = new ReportService();
                var percent = criteriaService.GetCriteriaValue(dtpStartdate.Value.Month, dtpStartdate.Value.Year, (int)cbRole.SelectedValue == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);

                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, Constants.ArticleType.KHOIHK_TTNM);
                SortableBindingList<EmployeePointViewModel> sbl = new SortableBindingList<EmployeePointViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvKHK.DataSource = bs;
                adgvKHK.Columns["EmployeeName"].HeaderText = ADGVReportHeader.Name;
                adgvKHK.Columns["Organization"].HeaderText = ADGVReportHeader.Organization;
                adgvKHK.Columns["SumPoint"].HeaderText = ADGVReportHeader.TongCong;
                adgvKHK.Columns["IncreasePercent"].HeaderText = "Tăng " + percent + "%";
                adgvKHK.Columns["IncreasePercent"].DefaultCellStyle.Format = "F1";
                adgvKHK.Columns["Descrease"].HeaderText = ADGVReportHeader.TruChiTieu;
                adgvKHK.Columns["Descrease"].DefaultCellStyle.Format = "F1";
                adgvKHK.Columns["TotalCost"].HeaderText = ADGVReportHeader.TotalCost;
                adgvKHK.Columns["TotalCost"].DefaultCellStyle.Format = "N0";
                adgvKHK.Columns["SoDCT"].HeaderText = ADGVReportHeader.SoDCT;
                adgvKHK.Columns["DiemDCT"].HeaderText = ADGVReportHeader.Diem;
                adgvKHK.Columns["SoKTD"].HeaderText = ADGVReportHeader.SoKTD;
                adgvKHK.Columns["DiemKTD"].HeaderText = ADGVReportHeader.Diem;
                adgvKHK.Columns["SoTCT"].HeaderText = ADGVReportHeader.SoTCT;
                adgvKHK.Columns["DiemTCT"].HeaderText = ADGVReportHeader.Diem;
                adgvKHK.Columns["SoKT_TH"].HeaderText = ADGVReportHeader.SoKT_TH;
                adgvKHK.Columns["DiemKT_TH"].HeaderText = ADGVReportHeader.Diem;


                adgvKHK.Columns["EmployeeId"].Visible = false;
                adgvKHK.Columns["TotalPoint"].Visible = false;

                adgvKHK.Columns["SoBai"].Visible = false;
                adgvKHK.Columns["DiemBai"].Visible = false;
                adgvKHK.Columns["SoCd"].Visible = false;
                adgvKHK.Columns["DiemCd"].Visible = false;
                adgvKHK.Columns["SoPv"].Visible = false;
                adgvKHK.Columns["DiemPv"].Visible = false;
                adgvKHK.Columns["SoSD"].Visible = false;
                adgvKHK.Columns["DiemSD"].Visible = false;

                adgvKHK.Columns["SoTTh_Gnh"].Visible = false;
                adgvKHK.Columns["DiemTTh_Gnh"].Visible = false;
                adgvKHK.Columns["SoCde"].Visible = false;
                adgvKHK.Columns["DiemCde"].Visible = false;
                adgvKHK.Columns["SoBs_DCT"].Visible = false;
                adgvKHK.Columns["DiemBs_DCT"].Visible = false;
                adgvKHK.Columns["SoBt_Dd"].Visible = false;
                adgvKHK.Columns["DiemBt_Dd"].Visible = false;

                adgvKHK.Columns["SoTin"].Visible = false;
                adgvKHK.Columns["DiemTin"].Visible = false;
                adgvKHK.Columns["SoPsu"].Visible = false;
                adgvKHK.Columns["DiemPsu"].Visible = false;
                adgvKHK.Columns["SoQtin"].Visible = false;
                adgvKHK.Columns["DiemQtin"].Visible = false;
                adgvKHK.Columns["SoQPsu"].Visible = false;
                adgvKHK.Columns["DiemQPsu"].Visible = false;
                adgvKHK.Columns["SoTLT"].Visible = false;
                adgvKHK.Columns["DiemTLT"].Visible = false;
                adgvKHK.Columns["SoThop"].Visible = false;
                adgvKHK.Columns["DiemThop"].Visible = false;

                adgvKHK.Columns["SoBs_TTN"].Visible = false;
                adgvKHK.Columns["DiemBs_TTN"].Visible = false;
                adgvKHK.Columns["SoBs_Sapo"].Visible = false;
                adgvKHK.Columns["DiemBs_Sapo"].Visible = false;
                adgvKHK.Columns["SoKThinh"].Visible = false;
                adgvKHK.Columns["DiemKThinh"].Visible = false;
                adgvKHK.Columns["SoTFile"].Visible = false;
                adgvKHK.Columns["DiemTFile"].Visible = false;
                adgvKHK.Columns["SoBt_Duyet"].Visible = false;
                adgvKHK.Columns["DiemBt_Duyet"].Visible = false;

                txtPoint.Text = list.Sum(e => e.TotalPoint).ToString();
                txtCost.Text = list.Sum(e => e.TotalCost).ToString("N0") + " vnđ";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        private void LoadReport()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                LoadBSReport();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                LoadKHKReport();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //saveFileDialog.FileName = $"BaoCao_BS_TTNM_{cbRole.Text}_{dtpEnddate.Value.Month}{dtpEnddate.Value.Year}.xlsx";
            //reportService = new ReportService();
            //var data = reportService.GetReportBSTTNM(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.BIENSOAN_TTNM);

            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    var path = Path.GetFullPath(saveFileDialog.FileName);
            //    File.WriteAllBytes(path, data);
            //}
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };

            try
            {
                reportService.InteropPreviewReportBSTTNM(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
                int month = this.dtpMonth.Value.Month;
                int year = this.dtpYear.Value.Year;
                actionLog.Message = string.Format(AppActions.Export_BienSoanTTNM, month, year);
            }
            catch (Exception ex)
            {
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                _logger.LogSystem(ex, string.Empty);
            }
            finally
            {
                _logger.LogBusiness(actionLog);
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
            //ListEmployeeDeduction deductionForm = new ListEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, ArticleType.BIENSOAN_TTNM, (int)cbRole.SelectedValue);
            ListEmployeeDeduction deductionForm = new ListEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.BIENSOAN_TTNM, EmployeeRole.PV);
            deductionForm.ShowDialog();
        }

        private void ReportBienSoanTTForm_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            reportService.InteropPreviewReportBSTTNM(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
        }
    }
}
