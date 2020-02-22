using ATV_Allowance.Forms.CommonForms;
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
    public partial class ReportPTForm : CommonForm
    {
        private IReportService reportService;

        public ReportPTForm()
        {
            InitializeComponent();
            reportService = new ReportService();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            reportService.InteropPreviewReportPT(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
        }
    }
}
