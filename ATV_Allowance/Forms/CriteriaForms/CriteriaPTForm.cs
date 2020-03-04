﻿using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
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

namespace ATV_Allowance.Forms.CriteriaForms
{
    public partial class CriteriaPTForm : CommonForm
    {
        private const int ARTICLE_TYPE = ArticleType.PHAT_THANH; // PT and PTTT have the same management
        private readonly ICriteriaService criteriaService;
        private BindingSource bs;
        public CriteriaPTForm()
        {
            InitializeComponent();
            criteriaService = new CriteriaService();
            LoadCriteriasOfYear();
        }

        private void LoadCriteriasOfYear(int? year = null, int? type = ARTICLE_TYPE)
        {
            if (year == null)
            {
                year = DateTime.Now.Year;
            }

            var result = criteriaService.GetYearlyCriterias(year.Value, type.Value);
            var dataSource = new List<CriteriaPTTableViewModel>();
            for (int i = 0; i < 12; i++)
            {
                var model = new CriteriaPTTableViewModel()
                {
                    Month = i + 1,
                    PV = result[i].Where(c => c.CriteriaId == 12).First().Value,
                    CTV = result[i].Where(c => c.CriteriaId == 13).First().Value,
                    TrichBBT = result[i].Where(c => c.CriteriaId == 14).First().Value,
                };
                dataSource.Add(model);
            }

            SortableBindingList<CriteriaPTTableViewModel> sbl = new SortableBindingList<CriteriaPTTableViewModel>(dataSource);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvCriterias.DataSource = bs;
            adgvCriterias.AutoGenerateColumns = false;

            adgvCriterias.Columns["Id"].Visible = false;
            adgvCriterias.Columns["Year"].Visible = false;

            adgvCriterias.Columns["Month"].HeaderText = "Thg";
            adgvCriterias.Columns["Month"].Width = 40;
        }

        private void adgvCriterias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int month = (int)adgvCriterias.SelectedRows[0].Cells["Month"].Value;
            int year = dtpYear.Value.Year;
            CriteriaDetailForm detailForm = new CriteriaDetailForm(month, year, ARTICLE_TYPE);
            detailForm.FormClosed += new FormClosedEventHandler(CriteriaDetailForm_Closed);
            detailForm.ShowDialog();
        }

        private void CriteriaDetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadCriteriasOfYear();
        }

        private void btnCopyCriteria_Click(object sender, EventArgs e)
        {

        }
    }
}
