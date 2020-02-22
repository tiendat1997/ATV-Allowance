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

namespace ATV_Allowance.Forms.PrintReportForms
{
    public partial class ReportBienSoanTTNM : CommonForm
    {
        public ReportBienSoanTTNM()
        {
            InitializeComponent();
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
    }
}
