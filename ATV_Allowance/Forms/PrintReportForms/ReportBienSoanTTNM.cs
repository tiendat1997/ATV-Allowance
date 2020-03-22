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
    public partial class ReportBienSoanTTNM : CommonForm
    {
        private IReportService reportService;
        private readonly IAppLogger _logger;
        public ReportBienSoanTTNM()
        {
            _logger = new AppLogger();
            InitializeComponent();
            InitTabIndex();
            reportService = new ReportService();
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
        }
        private void btnEditCriteria_Click(object sender, EventArgs e)
        {
            CriteriaBSTTNMForm criteriaForm = new CriteriaBSTTNMForm();
            criteriaForm.FormClosed += new FormClosedEventHandler(CriteriaBSTTNMForm_Closed);
            criteriaForm.ShowDialog();
        }

        private void CriteriaBSTTNMForm_Closed(object sender, FormClosedEventArgs args)
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

        private void btnDeduction_Click(object sender, EventArgs e)
        {
            PVEmployeeDeduction deductionForm = new PVEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.BIENSOAN_TTNM);
            deductionForm.ShowDialog();
        }
    }
}
