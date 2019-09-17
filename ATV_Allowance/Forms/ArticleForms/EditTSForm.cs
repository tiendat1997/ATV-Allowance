using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Helpers;
using ATV_Allowance.Services;
using ATV_Allowance.Validators;
using ATV_Allowance.ViewModel;
using DataService.Entity;
using FluentValidation.Results;
using System;
using System.Collections;
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
    public partial class EditTSForm : CommonForm
    {
        private BindingSource bs = null;
        private ArticleViewModel article;
        private int articleTypeId;
        private IArticleService articleService;
        private IPointTypeService pointTypeService;
        private IEmployeeService employeeService;
        private System.Windows.Forms.ErrorProvider epArticleTitle;
        private ComboBox comboBox;
        private List<EmployeeViewModel> empList;
        private List<PointTypeViewModel> listPointType;
        internal Dictionary<Control, ErrorProvider> epDic;               
        public EditTSForm(ArticleViewModel model, int articleTypeId)
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            InitializeErrorProvider();
            this.articleTypeId = articleTypeId;
            this.article = model;
            LoadDGV();
        }

        private void InitializeErrorProvider()
        {
            epDic = new Dictionary<Control, ErrorProvider>();
            epArticleTitle = new System.Windows.Forms.ErrorProvider(components);
            epDic.Add(txtTitle, epArticleTitle);
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
                employeeService = new EmployeeService();
                bs = new BindingSource();
                listPointType = pointTypeService.GetPointType(articleTypeId);
                empList = employeeService.GetAllActive(true);
                List<ArticleEmployeeViewModel> list = articleService.GetArticleEmployee(article.Id);
                var bindList = new BindingList<ArticleEmployeeViewModel>(list);
                bs.DataSource = bindList;
                adgvList.DataSource = bs;

                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["EmployeeId"].Visible = false;
                adgvList.Columns["ArticleId"].Visible = false;
                adgvList.Columns["Code"].Visible = false;
                adgvList.Columns["Name"].Visible = true;
                adgvList.Columns["Organization"].Visible = true;
                adgvList.Columns["Position"].Visible = true;
                adgvList.Columns["Organization"].ReadOnly = true;
                adgvList.Columns["Position"].ReadOnly = true;

                adgvList.Columns["Code"].HeaderText = ADGVEmployeeText.Code;
                adgvList.Columns["Code"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                adgvList.Columns["Name"].HeaderText = ADGVEmployeeText.Name;
                adgvList.Columns["Name"].Width = ControlsAttribute.GV_WIDTH_LARGE;
                adgvList.Columns["Position"].HeaderText = ADGVEmployeeText.AbbrPosition;
                adgvList.Columns["Position"].Width = ControlsAttribute.GV_WIDTH_SMALL;
                adgvList.Columns["Organization"].HeaderText = ADGVEmployeeText.Organization;
                adgvList.Columns["Organization"].Width = ControlsAttribute.GV_WIDTH_LARGE;


                DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
                cmbCol.HeaderText = ADGVEmployeeText.Code;
                cmbCol.DisplayMember = "Code";
                cmbCol.ValueMember = "Id";
                cmbCol.Name = "CbEmployeeColumn";
                cmbCol.DataSource = empList;
                adgvList.Columns.Add(cmbCol);
                adgvList.Columns["CbEmployeeColumn"].DisplayIndex = 2;
               
                InvisiblePointType();
                foreach (var type in listPointType)
                {
                    adgvList.Columns[type.Code].Visible = true;
                    adgvList.Columns[type.Code].HeaderText = type.Code;
                    adgvList.Columns[type.Code].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                adgvList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(adgvList_EditingControlShowing);                                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                pointTypeService = null;
                articleService = null;
                employeeService = null;
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
                    Title = txtTitle.Text
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
                articleService = null;
            }
        }

        private void adgvList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            comboBox = e.Control as ComboBox;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.SelectionChangeCommitted -= new EventHandler(SelectionChangeCommitted);
                comboBox.SelectionChangeCommitted += SelectionChangeCommitted;
                comboBox.KeyDown -= new KeyEventHandler(KeyDown);
                comboBox.KeyDown += new KeyEventHandler(KeyDown);
                comboBox.SelectedIndex = 0;
            }
        }
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter or TAB
            {
                var selectedEmp = (EmployeeViewModel)(sender as ComboBox).SelectedItem;
                if (selectedEmp != null)
                {
                    SelectionChangeCommitted(sender, null);
                }
            }
        }
        private void SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedEmp = (EmployeeViewModel)(sender as ComboBox).SelectedItem;
            if (selectedEmp != null)
            {
                int currRowIndex = adgvList.CurrentRow.Index;
                int currColIndex = adgvList.CurrentCell.ColumnIndex;
                adgvList.Rows[currRowIndex].Cells["Name"].Value = selectedEmp.Name;
                adgvList.Rows[currRowIndex].Cells["EmployeeId"].Value = selectedEmp.Id;
                adgvList.Rows[currRowIndex].Cells["Code"].Value = selectedEmp.Code;
                adgvList.Rows[currRowIndex].Cells["Position"].Value = selectedEmp.Position;
                adgvList.Rows[currRowIndex].Cells["Organization"].Value = selectedEmp.Organization;
            }
        }
        private void EditTSForm_Load(object sender, EventArgs e)
        {
            txtTitle.Text = article.Title;
            txtDate.Text = article.Date;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                // validation            
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    epArticleTitle.SetError(txtTitle, "Vui lòng nhập tiêu đề tin");
                }
                else
                {
                    epArticleTitle.SetError(txtTitle, "");
                    article.Title = txtTitle.Text;
                    articleService.UpdateArticle(article);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                articleService = null;
            }
            
        }

        private void adgvList_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Note the check to see if the current row is dirty
            string selectedValue = adgvList.Rows[e.RowIndex].Cells["CbEmployeeColumn"].FormattedValue.ToString();
            string currCodeValue = adgvList.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
            if ((string.IsNullOrEmpty(currCodeValue) || !selectedValue.Equals(currCodeValue)) && adgvList.IsCurrentRowDirty)
            {
                e.Cancel = true;
                adgvList.Rows[e.RowIndex].Cells["CbEmployeeColumn"].ErrorText = "Vui lòng chọn nhân viên";
            }
            else
            {
                adgvList.Rows[e.RowIndex].Cells["CbEmployeeColumn"].ErrorText = string.Empty;
            }

            foreach (var type in listPointType)
            {
                string typeValue = adgvList.Rows[e.RowIndex].Cells[type.Code].FormattedValue.ToString();
                int i;
                if (!int.TryParse(typeValue, out i) || i < 0)
                {
                    e.Cancel = true;
                    adgvList.Rows[e.RowIndex].Cells[type.Code].ErrorText = "Vui lòng nhập định dạng số (điểm >= 0)";
                }
                else
                {
                    adgvList.Rows[e.RowIndex].Cells[type.Code].ErrorText = string.Empty;
                }
            }
        }

        private void adgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context.ToString().Contains("Parsing"))
            {
                MessageBox.Show("Vui lòng nhập định dạng số cho điểm");
            }
        }

        private void adgvList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {           
            try
            {
                articleService = new ArticleService();
                ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;
                if (articleEmployee != null)
                {
                    if (articleEmployee.Id == 0) // Add new records 
                    {
                        articleEmployee.ArticleId = article.Id;
                        articleService.AddLArticleEmployeeTS(articleEmployee);
                    }
                    else
                    {
                        articleService.UpdateArticleEmployeeTS(articleEmployee);
                    }
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

        private void adgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) //Index of your DataGridViewComboBoxColumn 
            {
                if (adgvList.Rows[e.RowIndex].IsNewRow == false)
                {
                    var data = (ArticleEmployeeViewModel)adgvList.Rows[e.RowIndex].DataBoundItem;
                    e.Value = data.Code;
                }
            }
        }      
        private void adgvList_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {           
        }

        private void adgvList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                if (adgvList.CurrentRow.IsNewRow == false)
                {
                    ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;
                    if (articleEmployee != null && articleEmployee.Id > 0)
                    {
                        articleService.RemoveArticleEmployee(articleEmployee);
                    }
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
    }
}
