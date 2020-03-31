using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Forms.CriteriaForms;
using ATV_Allowance.Forms.DeductionForms;
using ATV_Allowance.Services;
using DataService.Entity;
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

namespace ATV_Allowance.Forms.PrintReportForms
{
    public partial class ReportPTForm : CommonForm
    {
        private IReportService reportService;
        private readonly IAppLogger _logger;

        public ReportPTForm()
        {
            _logger = new AppLogger();
            InitializeComponent();
            InitValue();
            InitTabIndex();
            reportService = new ReportService();
        }

        public void InitValue()
        {

            var firstDateInMonth = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);

            dtpMonth.Value = firstDateInMonth;
            dtpYear.Value = firstDateInMonth;

            dtpStartdate.Value = firstDateInMonth;
            dtpEnddate.Value = firstDateInMonth.AddMonths(1).AddDays(-1);

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
            btnExport.TabIndex = 7;
            button1.TabIndex = 8;
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
                reportService.InteropPreviewReportPT(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
                int month = this.dtpMonth.Value.Month;
                int year = this.dtpYear.Value.Year;
                actionLog.Message = string.Format(AppActions.Export_PhatThanh, month, year);
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
            CriteriaPTForm criteriaForm = new CriteriaPTForm();
            criteriaForm.FormClosed += new FormClosedEventHandler(CriteriaPTForm_Closed);
            criteriaForm.ShowDialog();
        }

        private void CriteriaPTForm_Closed(object sender, FormClosedEventArgs args)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };

            try
            {
                reportService.InteropPreviewReportPTTT(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
                int month = this.dtpMonth.Value.Month;
                int year = this.dtpYear.Value.Year;
                actionLog.Message = string.Format(AppActions.Export_PhatThanhTT, month, year);
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

        private void btnDeduction_Click(object sender, EventArgs e)
        {
            PTDepartmentDeduction deductionForm = new PTDepartmentDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.PHAT_THANH);
            deductionForm.ShowDialog();
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
    }
}
