using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Forms.CriteriaForms;
using ATV_Allowance.Services;
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
        public ReportTTNMForm()
        {
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
            reportService.InteropPreviewReportTTNM(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
        }
    }
}
