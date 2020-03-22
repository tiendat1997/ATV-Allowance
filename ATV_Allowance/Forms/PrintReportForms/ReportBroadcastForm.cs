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
            InitTabIndex();
            reportService = new ReportService();
            criteriaService = new CriteriaService();

            InitValue();
        }

        private void InitTabIndex()
        {
            dtpMonth.TabIndex = 0;
            dtpYear.TabIndex = 1;
            dtpStartdate.TabIndex = 2;
            dtpEnddate.TabIndex = 3;
            edtPrice.TabIndex = 4;

            btnEditCriteria.TabIndex = 5;
            btnDeduction.TabIndex = 6;
            btnDeductionPTV.TabIndex = 7;
            btnDeductionKTD.TabIndex = 8;
            btnExport.TabIndex = 9;
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
    
        private void btnExport_Click(object sender, EventArgs e)
        {           
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
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            dtpStartdate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);
            dtpEnddate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpYear.Value.Year, dtpMonth.Value.Month));
        }        

        private void btnDeduction_Click(object sender, EventArgs e)
        {
            PVEmployeeDeduction deductionForm = new PVEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.THOI_SU);
            deductionForm.ShowDialog();
        }

        private void btnExportKHK_Click(object sender, EventArgs e)
        {          
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };

            try
            {
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

        private void btnDeductionKTD_Click(object sender, EventArgs e)
        {
            KTDEmployeeDeduction deductionForm = new KTDEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.THOI_SU);
            deductionForm.ShowDialog();
        }
    }
}
