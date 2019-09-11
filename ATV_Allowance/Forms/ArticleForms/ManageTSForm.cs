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
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.ArticleForms
{
    public partial class ManageTSForm : CommonForm
    {
        private int articleType = ArticleType.THOI_SU;
        private IArticleService articleService;
        private BindingSource bs = null;

        public ManageTSForm()
        {
            InitializeComponent();
            LoadDGV();
        }
        private void LoadDGV()
        {
            try
            {
                articleService = new ArticleService();
                bs = new BindingSource();
                DateTime fromDate = dtpStartDate.Value;
                DateTime toDate = dtpEndDate.Value;
                var list = articleService.GetArticle(articleType, fromDate, toDate, -1);                                 
                SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(list);
                bs.DataSource = sbl;
                adgvList.DataSource = bs;
                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["TypeId"].Visible = false;
                adgvList.Columns["Title"].Visible = true;
                adgvList.Columns["Date"].Visible = true;

                adgvList.Columns["Title"].HeaderText = ADGVArticleText.Title;
                adgvList.Columns["Title"].Width = ControlsAttribute.GV_WIDTH_LARGE_XX;                
                adgvList.Columns["Date"].HeaderText = ADGVArticleText.Date;                                
                adgvList.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                articleService = null; 
            }
        }
    }
}
