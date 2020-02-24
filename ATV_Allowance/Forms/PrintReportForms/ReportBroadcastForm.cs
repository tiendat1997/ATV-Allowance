using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Forms.CriteriaForms;
using ATV_Allowance.Forms.DeductionForms;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
using DataService.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.PrintReportForms
{
    public partial class ReportBroadcastForm : CommonForm
    {
        private BindingSource bs;

        private IReportService reportService;
        private ICriteriaService criteriaService;
        private SaveFileDialog saveFileDialog;
        private StreamReader streamToPrint;
        private Font printFont;
        private readonly IAppLogger _logger;

        public ReportBroadcastForm()
        {
            _logger = new AppLogger();
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

            //cbRole.DataSource = positions;
            //cbRole.DisplayMember = "Code";
            //cbRole.ValueMember = "Id";
            //cbRole.SelectedValue = EmployeeRole.PV;

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

            //if (cbRole.SelectedValue.GetType() != typeof(int))
            //{
            //    return;
            //}

            //try
            //{
            //    var percent = criteriaService.GetCriteriaValue(dtpStartdate.Value.Month, dtpStartdate.Value.Year, (int)cbRole.SelectedValue == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            //    List<EmployeePointViewModel> list = reportService.GetReportBroadcast(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, Constants.ArticleType.THOI_SU);
            //    SortableBindingList<EmployeePointViewModel> sbl = new SortableBindingList<EmployeePointViewModel>(list);
            //    bs = new BindingSource();
            //    bs.DataSource = sbl;                
            //    //txtPoint.Text = list.Sum(e => e.TotalPoint).ToString();
            //    //txtCost.Text = list.Sum(e => e.TotalCost).ToString("N0") + " vnđ";
                
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //saveFileDialog.FileName = $"BaoCao_TS_{cbRole.Text}_{dtpEnddate.Value.Month}{dtpEnddate.Value.Year}.xlsx";
            //var data = reportService.GetReportTS(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.THOI_SU);

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
                reportService.InteropPreviewReportTS(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
                int month = this.dtpMonth.Value.Month;
                int year = this.dtpYear.Value.Year;
                actionLog.Message = string.Format(AppActions.Export_ThoiSu_TongHopThuLoa, month, year);
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
            PVEmployeeDeduction deductionForm = new PVEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.THOI_SU);
            deductionForm.ShowDialog();
        }

        private void btnExportKHK_Click(object sender, EventArgs e)
        {
            //saveFileDialog.FileName = $"BaoCao_TS_KHK_{dtpEnddate.Value.Month}{dtpEnddate.Value.Year}.xlsx";
            //var data = reportService.GetReportTS_KHK(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);

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
                //reportService.InteropPreviewReportTS_KHK(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, Constants.ArticleType.KHOIHK_TTNM);
                var month = dtpMonth.Value.Month;
                var year = dtpYear.Value.Year;
                actionLog.Message = string.Format(AppActions.Export_ThoiSu_KhoiHauKy, month, year);
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

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            //reportService.InteropPreviewReportTS(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, Constants.ArticleType.THOI_SU);
        }

        private void btnEditCriteria_Click(object sender, EventArgs e)
        {
            CriteriaTSForm criteriaForm = new CriteriaTSForm();
            criteriaForm.FormClosed += new FormClosedEventHandler(CriteriaTSForm_Closed);
            criteriaForm.ShowDialog();
        }

        private void CriteriaTSForm_Closed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnDeductionPTV_Click(object sender, EventArgs e)
        {
            PTVEmployeeDeduction deductionForm = new PTVEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.THOI_SU);
            deductionForm.ShowDialog();
        }
    }
}
