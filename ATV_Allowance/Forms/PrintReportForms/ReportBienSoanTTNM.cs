﻿using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Forms.CriteriaForms;
using ATV_Allowance.Forms.DeductionForms;
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
    public partial class ReportBienSoanTTNM : CommonForm
    {
        private IReportService reportService;
        public ReportBienSoanTTNM()
        {
            InitializeComponent();

            reportService = new ReportService();
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
            reportService.InteropPreviewReportBSTTNM(dtpStartdate.Value, dtpEnddate.Value, (int)edtPrice.Value);
        }

        private void btnDeduction_Click(object sender, EventArgs e)
        {
            PVEmployeeDeduction deductionForm = new PVEmployeeDeduction(dtpMonth.Value.Month, dtpYear.Value.Year, Constants.ArticleType.BIENSOAN_TTNM);
            deductionForm.ShowDialog();
        }
    }
}