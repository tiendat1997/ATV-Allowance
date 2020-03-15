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

namespace ATV_Allowance.Forms.PrintReportForms
{
    public partial class ReportTTNMForm : CommonForm
    {
        private IReportService reportService;
        private IAppLogger _logger;
        public ReportTTNMForm()
        {
            _logger = new AppLogger();
            InitializeComponent();
            reportService = new ReportService();
        }

        private void btnEditCriteria_Click(object sender, EventArgs e)
        {
            CriteriaTTNMForm criteriaForm = new CriteriaTTNMForm();
            criteriaForm.FormClosed += new FormClosedEventHandler(CriteriaTTNMForm_Closed);
            criteriaForm.ShowDialog();
        }

        private void CriteriaTTNMForm_Closed(object sender, FormClosedEventArgs args)
        {

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
                reportService.InteropPreviewReportTTNM(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
                int month = this.dtpMonth.Value.Month;
                int year = this.dtpYear.Value.Year;
                actionLog.Message = string.Format(AppActions.Export_TTNM, month, year);
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
            PVEmployeeDeduction deductionForm = new PVEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.PV_TTNM);
            deductionForm.ShowDialog();
        }
    }
}
