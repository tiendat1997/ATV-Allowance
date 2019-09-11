using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Helpers;
using ATV_Allowance.Services;
using ATV_Allowance.Validators;
using ATV_Allowance.ViewModel;
using DataService.Entity;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Forms.ArticleForms
{
    public partial class AddTSForm : CommonForm
    {
        private ArticleViewModel model;
        private int typeId;
        private IArticleService articleService;
        private System.Windows.Forms.ErrorProvider epArticleTitle;
        internal Dictionary<Control, ErrorProvider> epDic;

        public AddTSForm(ArticleViewModel model, int typeId)
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            InitializeErrorProvider();
            this.typeId = typeId;
            this.model = model;
            btnAddArticle.Enabled = false;
            LoadDGV();
        }
        public AddTSForm(int typeId)
        {            
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            InitializeErrorProvider();
            this.typeId = typeId;
            btnAddArticle.Enabled = true;
            LoadDGV();
        }
        private void InitializeErrorProvider()
        {
            epDic = new Dictionary<Control, ErrorProvider>();
            epArticleTitle = new System.Windows.Forms.ErrorProvider(components);                      
            epDic.Add(cbTitle, epArticleTitle);
        }
        private void LoadDGV()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            } finally
            {

            }
        }

        private bool btnAddArticle_Validate(Article art)
        {
            ArticleValidator validator = new ArticleValidator();
            ValidationResult result = validator.Validate(art);
            if (result.IsValid == false)
            {
                ValidatorHelper.ShowValidationMessage(gbArticleTitle, result.Errors, epDic);
            }
            return result.IsValid;
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                Article article = new Article
                {
                    Title = cbTitle.Text
                };
                bool result = btnAddArticle_Validate(article);
                if (result)
                {
                    MessageBox.Show("Hoàn thành");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }   
            finally
            {

            }
        }
    }
}
