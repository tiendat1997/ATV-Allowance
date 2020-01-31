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
        private readonly IAppLogger _logger;
        public EditTSForm(ArticleViewModel model)
        {
            _logger = new AppLogger();
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
                _logger.LogSystem(ex, string.Empty);
            }
        }

        private void InitializeErrorProvider()
        {
            epDic = new Dictionary<Control, ErrorProvider>();
            epArticleTitle = new System.Windows.Forms.ErrorProvider(components);
            epDic.Add(txtTitle, epArticleTitle);
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
                List<ArticleEmployeeViewModel> list = articleService.GetArticleEmployee(article.Id, article.TypeId);

                var bindList = ArticleEmployeeHelper.MapToBindingList(articleTypeId, list);
                bs.DataSource = bindList;
                adgvList.DataSource = bs;

                // If you want to change column index, you need to disable auto genrate column                 
                adgvList.AutoGenerateColumns = false;

                // set indexing for the table                
                adgvList.Columns["EmployeeCode"].DisplayIndex = 0;
                adgvList.Columns["Name"].DisplayIndex = 1;
                adgvList.Columns["Organization"].DisplayIndex = 2;
                adgvList.Columns["Position"].DisplayIndex = 3;

                // hidden column 
                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["EmployeeId"].Visible = false;
                adgvList.Columns["ArticleId"].Visible = false;

                // readonly field before employee selection
                adgvList.Columns["Name"].ReadOnly = true;
                adgvList.Columns["Organization"].ReadOnly = true;
                adgvList.Columns["Position"].ReadOnly = true;
                adgvList.Columns["EmployeeCode"].ReadOnly = true;

                adgvList.Columns["EmployeeCode"].HeaderText = ADGVEmployeeText.Code;
                adgvList.Columns["EmployeeCode"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                adgvList.Columns["Name"].HeaderText = ADGVEmployeeText.Name;
                adgvList.Columns["Name"].Width = ControlsAttribute.GV_WIDTH_MEDIUM;
                adgvList.Columns["Position"].HeaderText = ADGVEmployeeText.AbbrPosition;
                adgvList.Columns["Position"].Width = ControlsAttribute.GV_WIDTH_SMALL;
                adgvList.Columns["Organization"].HeaderText = ADGVEmployeeText.Organization;
                adgvList.Columns["Organization"].Width = ControlsAttribute.GV_WIDTH_MEDIUM;

                int nextIndex = 3;
                foreach (var type in listPointType)
                {
                    nextIndex++;
                    adgvList.Columns[type.Code].DisplayIndex = nextIndex;
                    adgvList.Columns[type.Code].HeaderText = type.Code;
                    adgvList.Columns[type.Code].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //adgvList.Columns[type.Code].Width = ControlsAttribute.GV_WIDTH_SMALL;
                }
                adgvList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(adgvList_EditingControlShowing);
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
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
                _logger.LogSystem(ex, string.Empty);
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
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
                _logger.LogSystem(ex, string.Empty);
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
                    adgvList.Rows[currRowIndex].Cells["EmployeeCode"].Value = selectedEmp.Code;
                    adgvList.Rows[currRowIndex].Cells["Position"].Value = selectedEmp.Position;
                    adgvList.Rows[currRowIndex].Cells["Organization"].Value = selectedEmp.Organization;

                    var textCell = new DataGridViewTextBoxCell();
                    textCell.Value = selectedEmp.Code;

                    adgvList.Rows[currRowIndex].ReadOnly = false;

                    // change employee code column to text and mark it read only
                    adgvList.Rows[currRowIndex].Cells["EmployeeCode"] = textCell;
                    adgvList.Rows[currRowIndex].Cells["EmployeeCode"].ReadOnly = true;

                    // focus on the first point of the column 
                    adgvList.CurrentCell = adgvList.Rows[currRowIndex].Cells[listPointType[0].Code];
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
            }
        }
        private void EditTSForm_Load(object sender, EventArgs e)
        {
            txtTitle.Text = article.Title;
            txtDate.Text = article.Date;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                 
        }

        private void adgvList_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Note the check to see if the current row is dirty
            string selectedValue = adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].FormattedValue.ToString();
            string currCodeValue = adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].FormattedValue.ToString();
            if ((string.IsNullOrEmpty(currCodeValue) || !selectedValue.Equals(currCodeValue)) && adgvList.IsCurrentRowDirty)
            {
                e.Cancel = true;
                adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].ErrorText = "Vui lòng chọn nhân viên";
            }
            else
            {
                adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].ErrorText = string.Empty;
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
            adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].Value = "";
            e.Cancel = true;
        }

        private void adgvList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {           
            try
            {
                articleService = new ArticleService();
                ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;
                if (articleEmployee != null)
                {
                    if (articleEmployee.Id == 0 && articleEmployee.Name != null) // Add new records 
                    {
                        articleService.AddArticleEmployee(articleEmployee, article);
                    }
                    else
                    {
                        articleService.UpdateArticleEmployee(articleEmployee, article);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
            }
            finally
            {
                articleService = null;
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
                    var confirmResult = DialogHelper.OpenConfirmationDialog("Bạn có chắc muốn xóa nhân viên ra khỏi tin này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;
                        if (articleEmployee != null)
                        {
                            articleEmployee.ArticleId = article.Id;
                            articleService.RemoveArticleEmployee(articleEmployee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
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
                _logger.LogSystem(ex, string.Empty);
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
                    adgvList.Rows[e.RowIndex].Cells["EmployeeCode"] = cmbCell;
                    adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].ReadOnly = false;
                    //go to first column
                    SendKeys.Send("{Home}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
            }
        }

        private void adgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{Tab}");//go to first column
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
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

                DialogHelper.OpenActionResultDialog("Lưu thành công", "Lưu tiêu đề tin");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra", "Lưu tiêu đề tin");
                _logger.LogSystem(ex, string.Empty);
            }
            finally
            {
                articleService = null;
            }
        }
    }
}
