using ATV_Allowance.Common;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ATV_Allowance.Forms.CriteriaForms
{
    public partial class ListCriteriaForm : Form
    {
        private ICriteriaService criteriaService;
        private BindingSource bs;

        public ListCriteriaForm()
        {
            InitializeComponent();

            CustomStyle();
            criteriaService = new CriteriaService();
            LoadCriteriasOfYear();
            LoadCriteriasOfMonth();
        }

        public void CustomStyle()
        {
            fpCriteriaList.AutoScroll = false;
            fpCriteriaList.HorizontalScroll.Enabled = false;
            fpCriteriaList.HorizontalScroll.Visible = false;
            fpCriteriaList.HorizontalScroll.Maximum = 0;
            fpCriteriaList.AutoScroll = true;


        }

        private void LoadCriteriasOfMonth(int? month = null, int? year = null)
        {
            //to remove all control
            fpCriteriaList.Visible = false;

            while (fpCriteriaList.Controls.Count > 0)
            {
                fpCriteriaList.Controls[0].Dispose();
            }

            fpCriteriaList.Visible = true;



            if (month == null)
            {
                month = DateTime.Now.Month;
            }

            if (year == null)
            {
                year = DateTime.Now.Year;
            }

            //change label
            gbCriterias.Text = "Quản lý chỉ tiêu tháng " + month + " / " + year;

            var result = criteriaService.GetCriterias(month.Value, year.Value);

            foreach (var criteria in result)
            {
                this.fpCriteriaList.Controls.Add(new ACriteriaTemplate(criteria.CriteriaId, criteria.Name, criteria.Value, criteria.Unit));
            }

        }

        private void LoadCriteriasOfYear(int? year = null)
        {
            if (year == null)
            {
                year = DateTime.Now.Year;
            }

            var result = criteriaService.GetCriterias(year.Value);
            var dataSource = new List<CriteriaTableViewModel>();
            for (int i = 0; i < 12; i++)
            {
                var model = new CriteriaTableViewModel()
                {
                    Month = i + 1,
                    PV = result[i].Where(c => c.CriteriaId == 1).FirstOrDefault().Value,
                    CTV = result[i].Where(c => c.CriteriaId == 2).FirstOrDefault().Value,
                    BtCTTS = result[i].Where(c => c.CriteriaId == 3).FirstOrDefault().Value,
                    PTV = result[i].Where(c => c.CriteriaId == 4).FirstOrDefault().Value,
                    KTDung = result[i].Where(c => c.CriteriaId == 5).FirstOrDefault().Value,
                    TPCTTS = result[i].Where(c => c.CriteriaId == 6).FirstOrDefault().Value,
                    PVTruc = result[i].Where(c => c.CriteriaId == 7).FirstOrDefault().Value,
                    Ngay = result[i].Where(c => c.CriteriaId == 8).FirstOrDefault().Value,
                    Vtinh = result[i].Where(c => c.CriteriaId == 9).FirstOrDefault().Value,
                    TienVT = result[i].Where(c => c.CriteriaId == 10).FirstOrDefault().Value,
                    TienDS = result[i].Where(c => c.CriteriaId == 11).FirstOrDefault().Value,
                };

                dataSource.Add(model);
            }

            SortableBindingList<CriteriaTableViewModel> sbl = new SortableBindingList<CriteriaTableViewModel>(dataSource);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvCriterias.DataSource = bs;

            adgvCriterias.Columns["Id"].Visible = false;
            adgvCriterias.Columns["Year"].Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var listCriterias = new List<CriteriaViewModel>();
            foreach (ACriteriaTemplate c in fpCriteriaList.Controls.OfType<ACriteriaTemplate>())
            {
                listCriterias.Add(new CriteriaViewModel()
                {
                    CriteriaId = c.GetCriteriaId(),
                    Value = c.GetValue()
                });
            }

            int month = adgvCriterias.SelectedRows[0].Index + 1;
            int year = dtp.Value.Year;
            criteriaService.UpdateCriterias(listCriterias, month, year);
            LoadCriteriasOfYear(year);
        }

        private void adgvCriterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadMonthWithCurrentRowSelected();
        }

        private void LoadMonthWithCurrentRowSelected()
        {
            int month = (int) adgvCriterias.SelectedRows[0].Cells["Month"].Value;
            int year = dtp.Value.Year;
            LoadCriteriasOfMonth(month, year);
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCriteriasOfYear(dtp.Value.Year);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadCriteriasOfYear(dtp.Value.Year);
        }
    }
}
