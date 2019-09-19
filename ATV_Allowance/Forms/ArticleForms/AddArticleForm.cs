using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Helpers;
using ATV_Allowance.Services;
using ATV_Allowance.Validators;
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
    public partial class AddArticleForm : CommonForm
    {
        private int typeId; // articleTypeId
        private IArticleService articleService;
        private System.Windows.Forms.ErrorProvider epTitle;
        internal new Dictionary<Control, ErrorProvider> epDic;
        public AddArticleForm(int typeId)
        {
            this.typeId = typeId;
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            InitializeErrorProvider();
        }
        private void InitializeErrorProvider()
        {
            epTitle = new System.Windows.Forms.ErrorProvider(components);
            epDic = new Dictionary<Control, ErrorProvider>();
            epDic.Add(txtTitle, epTitle);
        }

        private bool btnAdd_Validate(Organization org)
        {
            OrganizationValidator validator = new OrganizationValidator();
            ValidationResult result = validator.Validate(org);
            if (result.IsValid == false)
            {
                ValidatorHelper.ShowValidationMessage(gbOrgInfo, result.Errors, epDic);
            }
            return result.IsValid;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                ValidatorHelper.ClearEPValidation(epDic);
                Article newEmp = new Article()
                {
                    Title = txtTitle.Text,
                    Date = dtpDate.Value,
                    TypeId = typeId
                };
                ArticleValidator validator = new ArticleValidator();
                ValidationResult result = validator.Validate(newEmp);
                if (result.IsValid == false)
                {
                    ValidatorHelper.ShowValidationMessage(gbOrgInfo, result.Errors, epDic);
                } else
                {
                    articleService.AddArticle(newEmp);
                    this.Close();
                }                                            
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

        private void AddArticleForm_Load(object sender, EventArgs e)
        {
            dtpDate.MinDate = DateTime.Now;
        }
    }
}
