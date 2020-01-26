using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
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
    public partial class ArticleListForm : CommonForm
    {
        private List<IndexedArticleViewModel> articleList;
        public IndexedArticleViewModel IndexedArticle { get; set; }
        public ArticleListForm(List<IndexedArticleViewModel> articles)
        {
            this.articleList = articles;
            InitializeComponent();
            InitDataGridView();
        }
        private void InitDataGridView()
        {
            
            BindingSource bs = new BindingSource();
            SortableBindingList<IndexedArticleViewModel> sbl = new SortableBindingList<IndexedArticleViewModel>(articleList);
            adgvList.DataSource = articleList;

            adgvList.Columns["Id"].Visible = false;
            adgvList.Columns["Index"].Visible = true;
            adgvList.Columns["Title"].Visible = true;

            adgvList.Columns["Index"].HeaderText = "STT";
            adgvList.Columns["Index"].Width = ControlsAttribute.GV_WIDTH_SEEM;
            adgvList.Columns["Title"].HeaderText = ADGVArticleText.Title;
            adgvList.Columns["Title"].Width = ControlsAttribute.GV_WIDTH_LARGE_XX;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var selectedIndex = adgvList.SelectedRows[0].Index;
            IndexedArticle = articleList[selectedIndex];
            Close();
        }
    }
}
