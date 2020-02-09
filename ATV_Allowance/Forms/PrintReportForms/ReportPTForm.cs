using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Forms.CriteriaForms;
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
        public ReportPTForm()
        {
            InitializeComponent();
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
    }
}
