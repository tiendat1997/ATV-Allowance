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
using ArticleType = ATV_Allowance.Common.Constants.ArticleType;

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
        private List<string> empList;
        private List<PointTypeViewModel> listPointType;
        internal Dictionary<Control, ErrorProvider> epDic;               
        public EditTSForm(ArticleViewModel model)
        {
            this.components = new System.ComponentModel.Container();
            InitializeComponent();            
            InitializeErrorProvider();
            this.articleTypeId = model.TypeId;
            this.article = model;
            LoadEmployeeData();
            LoadDGV();
        }
        private void LoadEmployeeData()
        {
            try
            {
                employeeService = new EmployeeService();
                empList = employeeService.GetAllEmployeeCode(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            adgvList.Columns["Tl_tin"].Visible = false;
            adgvList.Columns["Thop"].Visible = false;
            // BIEN SOAN TTNM
            adgvList.Columns["Bs_TTN"].Visible = false;
            adgvList.Columns["Bs_Sapo"].Visible = false;
            adgvList.Columns["KThinh"].Visible = false;
            adgvList.Columns["TFile"].Visible = false;
            adgvList.Columns["Bt_Duyet"].Visible = false;
            // KHOI HAU KY TTNM
            adgvList.Columns["DCT"].Visible = false;
            adgvList.Columns["KTD"].Visible = false;
            adgvList.Columns["TCT"].Visible = false;
            adgvList.Columns["KT_TH"].Visible = false;
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
                List<ArticleEmployeeViewModel> list = articleService.GetArticleEmployee(article.Id);
                var bindList = new BindingList<ArticleEmployeeViewModel>(list);
                bs.DataSource = bindList;
                adgvList.DataSource = bs;

                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["EmployeeId"].Visible = false;
                adgvList.Columns["ArticleId"].Visible = false;
                adgvList.Columns["Code"].Visible = true;
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
                               
                InvisiblePointType();
                foreach (var type in listPointType)
                {
                    adgvList.Columns[type.Code].Visible = true;
                    adgvList.Columns[type.Code].HeaderText = type.Code;
                    adgvList.Columns[type.Code].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                adgvList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(adgvList_EditingControlShowing);
                adgvList.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
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
                comboBox.DropDownWidth = 150;
                comboBox.SelectionChangeCommitted -= new EventHandler(EmployeeCodeSelectionChangeCommitted);
                comboBox.SelectionChangeCommitted += EmployeeCodeSelectionChangeCommitted;
                comboBox.KeyDown -= new KeyEventHandler(EmployeeComboboxKeyDown);
                comboBox.KeyDown += new KeyEventHandler(EmployeeComboboxKeyDown);
                comboBox.SelectedIndex = 0;
            }
        }
        private void EmployeeComboboxKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) // Enter or TAB 
                {
                    string empCode = (string)(sender as ComboBox).SelectedItem;
                    if (string.IsNullOrEmpty(empCode) == false)
                    {
                        EmployeeCodeSelectionChangeCommitted(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void EmployeeCodeSelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                employeeService = new EmployeeService();
                var empCode = (string)(sender as ComboBox).SelectedItem;
                var selectedEmp = employeeService.GetEmployeeByCode(empCode);
                if (selectedEmp != null)
                {
                    int currRowIndex = adgvList.CurrentRow.Index;
                    int currColIndex = adgvList.CurrentCell.ColumnIndex;
                    adgvList.Rows[currRowIndex].Cells["Name"].Value = selectedEmp.Name;
                    adgvList.Rows[currRowIndex].Cells["EmployeeId"].Value = selectedEmp.Id;
                    adgvList.Rows[currRowIndex].Cells["Code"].Value = selectedEmp.Code;
                    adgvList.Rows[currRowIndex].Cells["Position"].Value = selectedEmp.Position;
                    adgvList.Rows[currRowIndex].Cells["Organization"].Value = selectedEmp.Organization;

                    var textCell = new DataGridViewTextBoxCell();
                    textCell.Value = selectedEmp.Code;

                    // change employee code column to text and mark it read only
                    adgvList.Rows[currRowIndex].Cells["Code"] = textCell;
                    adgvList.Rows[currRowIndex].Cells["Code"].ReadOnly = true;

                    // focus on the first point of the column 
                    adgvList.CurrentCell = adgvList.Rows[currRowIndex].Cells[listPointType[0].Code];

                    adgvList.Update();
                    adgvList.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
            string selectedValue = adgvList.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
            string currCodeValue = adgvList.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
            if ((string.IsNullOrEmpty(currCodeValue) || !selectedValue.Equals(currCodeValue)) && adgvList.IsCurrentRowDirty)
            {
                e.Cancel = true;
                adgvList.Rows[e.RowIndex].Cells["Code"].ErrorText = "Vui lòng chọn nhân viên";
            }
            else
            {
                adgvList.Rows[e.RowIndex].Cells["Code"].ErrorText = string.Empty;
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
                        if (articleTypeId == ArticleType.THOI_SU)
                        {
                            articleService.AddArticleEmployeeTS(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PV_TTNM)
                        {
                            articleService.AddArticleEmployeeTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.BIENSOAN_TTNM)
                        {
                            articleService.AddArticleEmployeeBSTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.KHOIHK_TTNM)
                        {
                            articleService.AddArticleEmployeeHKTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PHAT_THANH)
                        {
                            articleService.AddArticleEmployeePT(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PHAT_THANH_TT)
                        {
                            articleService.AddArticleEmployeePTTT(articleEmployee);
                        }                        
                    }
                    else
                    {
                        if (articleTypeId == ArticleType.THOI_SU)
                        {
                            articleService.UpdateArticleEmployeeTS(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PV_TTNM)
                        {
                            articleService.UpdateArticleEmployeeTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.BIENSOAN_TTNM)
                        {
                            articleService.UpdateArticleEmployeeBSTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.KHOIHK_TTNM)
                        {
                            articleService.UpdateArticleEmployeeHKTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PHAT_THANH)
                        {
                            articleService.UpdateArticleEmployeePT(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PHAT_THANH_TT)
                        {
                            articleService.UpdateArticleEmployeePTTT(articleEmployee);
                        }                       
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
                    if (articleEmployee != null)
                    {
                        articleEmployee.ArticleId = article.Id;
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (article == null)
                {
                    return;
                }
                if (MessageBox.Show("Xác nhận xóa tin", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    articleService = new ArticleService();
                    articleService.RemoveArticle(article);
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

        private void adgvList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Change Code Column Cell to combobox
                if (e.RowIndex == adgvList.NewRowIndex)
                {
                    var cmbCell = new DataGridViewComboBoxCell();
                    cmbCell.DataSource = empList;
                    adgvList.Rows[e.RowIndex].Cells["Code"] = cmbCell;
                    adgvList.Rows[e.RowIndex].Cells["Code"].ReadOnly = false;
                    adgvList.Update();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
