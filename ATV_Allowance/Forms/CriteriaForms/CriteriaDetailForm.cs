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
    public partial class CriteriaDetailForm : CommonForm
    {
        private ICriteriaService criteriaService;
        private int month;
        private int year;         

        public CriteriaDetailForm(int month, int year , int articleType)
        {            
            InitializeComponent();
            criteriaService = new CriteriaService();
            this.month = month;
            this.year = year;

            CustomStyle();
            LoadCriteriasOfMonth(month, year, articleType);
        }

        private void CustomStyle()
        {
            fpCriteriaList.AutoScroll = false;
            fpCriteriaList.HorizontalScroll.Enabled = false;
            fpCriteriaList.HorizontalScroll.Visible = false;
            fpCriteriaList.HorizontalScroll.Maximum = 0;
            fpCriteriaList.AutoScroll = true;
        }

        private void LoadCriteriasOfMonth(int? month = null, int? year = null, int? type = 3)
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
            string articleTypeLabel = "";
            if (type == ArticleType.THOI_SU)
            {
                articleTypeLabel = "[Tin Thời Sự] - ";
            }

            gbCriterias.Text = articleTypeLabel + "Chỉ tiêu tháng " + month + " / " + year;

            var result = criteriaService.GetCriterias(month.Value, year.Value, type.Value);

            foreach (var criteria in result)
            {
                this.fpCriteriaList.Controls.Add(new ACriteriaTemplate(criteria.CriteriaId, criteria.Name, criteria.Value, criteria.Unit));
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
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

                criteriaService.UpdateCriterias(listCriterias, this.month, this.year);
                this.Close();
            }
            catch (Exception ex)  
            {
                throw ex;
            }            
        }
    }
}
