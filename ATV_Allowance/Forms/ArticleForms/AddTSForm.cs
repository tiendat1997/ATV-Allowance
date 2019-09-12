﻿using ATV_Allowance.Common;
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
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.ArticleForms
{
    public partial class AddTSForm : CommonForm
    {
        private BindingSource bs = null;
        private ArticleViewModel article;
        private int articleTypeId;
        private IArticleService articleService;
        private IPointTypeService pointTypeService;
        private System.Windows.Forms.ErrorProvider epArticleTitle;
        internal Dictionary<Control, ErrorProvider> epDic;


        public AddTSForm(ArticleViewModel model, int articleTypeId)
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            InitializeErrorProvider();
            this.articleTypeId = articleTypeId;
            this.article = model;
            btnAddArticle.Enabled = false;
            LoadDGV();
        }
        public AddTSForm(int articleTypeId)
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            InitializeErrorProvider();
            this.articleTypeId = articleTypeId;
            btnAddArticle.Enabled = true;
            LoadDGV();
        }
        private void InitializeErrorProvider()
        {
            epDic = new Dictionary<Control, ErrorProvider>();
            epArticleTitle = new System.Windows.Forms.ErrorProvider(components);
            epDic.Add(cbTitle, epArticleTitle);
        }
        private void InvisiblePointType()
        {
            adgvList.Columns["Tin"].Visible = false;
            adgvList.Columns["PS"].Visible = false;
            adgvList.Columns["QTin"].Visible = false;
            adgvList.Columns["QPs"].Visible = false;
            adgvList.Columns["Pv_Pb"].Visible = false;
            adgvList.Columns["Tlt"].Visible = false;
            adgvList.Columns["Sd"].Visible = false;
            adgvList.Columns["Cd_Cm"].Visible = false;
            adgvList.Columns["Bai"].Visible = false;
            adgvList.Columns["TTh_Gnh"].Visible = false;
            adgvList.Columns["CDe"].Visible = false;
            adgvList.Columns["Bs_DCT"].Visible = false;
            adgvList.Columns["Bt_Dd"].Visible = false;
        }
        private void LoadDGV()
        {
            try
            {
                pointTypeService = new PointTypeService();
                articleService = new ArticleService();
                var listPointType = pointTypeService.GetPointType(articleTypeId);
                List<ArticleEmployeeViewModel> list = articleService.GetArticleEmployee(article.Id);
                var bindList = new BindingList<ArticleEmployeeViewModel>(list);                         
                adgvList.DataSource = bindList;

                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["EmployeeId"].Visible = false;
                adgvList.Columns["Code"].Visible = true;
                adgvList.Columns["Name"].Visible = true;

                adgvList.Columns["Code"].HeaderText = ADGVEmployeeText.Code;
                adgvList.Columns["Code"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgvList.Columns["Name"].HeaderText = ADGVEmployeeText.Name;
                adgvList.Columns["Name"].Width = ControlsAttribute.GV_WIDTH_MEDIUM;

                InvisiblePointType();
                foreach (var type in listPointType)
                {
                    adgvList.Columns[type.Code].Visible = true;
                    adgvList.Columns[type.Code].HeaderText = type.Code;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                pointTypeService = null;
                articleService = null;
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
