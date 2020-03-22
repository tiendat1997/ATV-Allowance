using ATV_Allowance.Common;
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

namespace ATV_Allowance.Forms.CriteriaForms
{
    public partial class CriteriaTSForm : CommonForm
    {
        private const int TYPE_TS = 3;

        private ICriteriaService criteriaService;
        private BindingSource bs;
        public CriteriaTSForm()
        {
            InitializeComponent();
            InitTabIndex();
            criteriaService = new CriteriaService();
            LoadCriteriasOfYear();            
        }

        private void InitTabIndex()
        {
            dtpYear.TabIndex = 0;
            adgvCriterias.TabIndex = 1;
        }

        private void LoadCriteriasOfYear(int? year = null, int? type = TYPE_TS)
        {
            if (year == null)
            {
                year = DateTime.Now.Year;
            }

            var result = criteriaService.GetYearlyCriterias(year.Value, type.Value);
            var dataSource = new List<CriteriaTSTableViewModel>();
            for (int i = 0; i < 12; i++)
            {
                var model = new CriteriaTSTableViewModel()
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

            SortableBindingList<CriteriaTSTableViewModel> sbl = new SortableBindingList<CriteriaTSTableViewModel>(dataSource);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvCriterias.DataSource = bs;
            adgvCriterias.AutoGenerateColumns = false;

            adgvCriterias.Columns["Id"].Visible = false;
            adgvCriterias.Columns["Year"].Visible = false;

            adgvCriterias.Columns["Month"].HeaderText = "Thg";
            adgvCriterias.Columns["Month"].Width = 30;

        }
       
        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            LoadCriteriasOfYear(dtpYear.Value.Year, TYPE_TS);            
        }

        private void adgvCriterias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int month = (int)adgvCriterias.SelectedRows[0].Cells["Month"].Value;
            int year = dtpYear.Value.Year;
            CriteriaDetailForm detailForm = new CriteriaDetailForm(month, year, TYPE_TS);
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
