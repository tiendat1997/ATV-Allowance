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
        private BindingList<string> employeeBindingList;
        public EditTSForm(ArticleViewModel model)
        {
            _logger = new AppLogger();
            this.components = new System.ComponentModel.Container();
            InitializeComponent();            
            InitializeErrorProvider();
            InitializeTabIndex();

            this.articleTypeId = model.TypeId;
            this.article = model;
            this.Text = GetArticleTypeName(articleTypeId);

            LoadEmployeeData();
            LoadDGV();
        }
        private void InitializeTabIndex()
        {
            txtTitle.TabIndex = 0;            
            adgvList.TabIndex = 1;
        }
        private string GetArticleTypeName(int typeId)
        {
            string typeName = "Cập nhật ";
            switch (typeId)
            {
                case 1:
                    typeName += "tin phát thanh";
                    break;
                case 2:
                    typeName += "tin phát thanh tt";
                    break;
                case 3:
                    typeName += "tin thời sự hàng ngày";
                    break;
                case 4:
                    typeName += "trên từng cây số";
                    break;
                case 5:
                    typeName += "biên soạn trên từng cây số";
                    break;
                case 6:
                    typeName += "khối hậu kỳ biên soạn trên từng cây số";
                    break;
                default:
                    break;
            }
            return typeName;
        }

        private void LoadEmployeeData()
        {
            try
            {
                employeeService = new EmployeeService();
                empList = employeeService.GetAllEmployeeCode(true);
                employeeBindingList = new BindingList<string>(empList);
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
                throw ex;
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

                var employeeCodeColumn = new DataGridViewComboBoxColumn();
                employeeCodeColumn.Name = "ComboboxEmployee";
                employeeCodeColumn.HeaderText = "Mã NV";
                employeeCodeColumn.DataSource = employeeBindingList;
                employeeCodeColumn.DisplayIndex = 0;
                adgvList.Columns.Add(employeeCodeColumn);

                adgvList.Columns["ComboboxEmployee"].DataPropertyName = "EmployeeCode";

                // set indexing for the table                
                adgvList.Columns["Name"].DisplayIndex = 1;
                adgvList.Columns["Organization"].DisplayIndex = 2;
                adgvList.Columns["Position"].DisplayIndex = 3;

                // hidden column 
                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["EmployeeId"].Visible = false;
                adgvList.Columns["EmployeeCode"].Visible = false;
                adgvList.Columns["ArticleId"].Visible = false;

                // readonly field before employee selection
                adgvList.Columns["Name"].ReadOnly = true;
                adgvList.Columns["Organization"].ReadOnly = true;
                adgvList.Columns["Position"].ReadOnly = true;
                adgvList.Columns["EmployeeCode"].ReadOnly = true;

                adgvList.Columns["EmployeeCode"].HeaderText = ADGVEmployeeText.Code;
                adgvList.Columns["EmployeeCode"].Width = 180;
                adgvList.Columns["Name"].HeaderText = ADGVEmployeeText.Name;
                adgvList.Columns["Name"].Width = 250;
                adgvList.Columns["Position"].HeaderText = ADGVEmployeeText.AbbrPosition;
                adgvList.Columns["Position"].Width = 60;
                adgvList.Columns["Organization"].HeaderText = ADGVEmployeeText.Organization;
                adgvList.Columns["Organization"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                int nextIndex = 3;
                foreach (var type in listPointType)
                {
                    nextIndex++;
                    adgvList.Columns[type.Code].DisplayIndex = nextIndex;
                    adgvList.Columns[type.Code].HeaderText = type.Code;
                    adgvList.Columns[type.Code].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    int colSize = Utilities.GetPointColumnSize(type.Code);
                    adgvList.Columns[type.Code].Width = colSize;
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
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.DropDownWidth = 150;
                comboBox.SelectionChangeCommitted -= new EventHandler(EmployeeCodeSelectionChangeCommitted);
                comboBox.SelectionChangeCommitted += EmployeeCodeSelectionChangeCommitted;
                comboBox.KeyDown -= new KeyEventHandler(EmployeeComboboxKeyDown);
                comboBox.KeyDown += new KeyEventHandler(EmployeeComboboxKeyDown);
                comboBox.IntegralHeight = false;
                comboBox.MaxDropDownItems = 10;
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
                    adgvList.Rows[currRowIndex].Cells["ComboboxEmployee"].Value = empCode;

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
            try
            {
                // Note the check to see if the current row is dirty
                string selectedValue = adgvList.Rows[e.RowIndex].Cells["ComboboxEmployee"].FormattedValue.ToString();
                string currCodeValue = adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].FormattedValue.ToString();
                if ((string.IsNullOrEmpty(currCodeValue) || !selectedValue.Equals(currCodeValue)) && adgvList.IsCurrentRowDirty)
                {
                    e.Cancel = true;
                    adgvList.Rows[e.RowIndex].Cells["ComboboxEmployee"].ErrorText = "Vui lòng chọn nhân viên";
                }
                else
                {
                    adgvList.Rows[e.RowIndex].Cells["ComboboxEmployee"].ErrorText = string.Empty;
                }

                foreach (var type in listPointType)
                {
                    string typeValue = adgvList.Rows[e.RowIndex].Cells[type.Code].FormattedValue.ToString();
                    double i;
                    if (!double.TryParse(typeValue, out i) || i < 0)
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
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
            }
        }

        private void adgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void adgvList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;
                if (articleEmployee.Id == 0 && articleEmployee.Name != null) // Add new records 
                {
                    articleService.AddArticleEmployee(articleEmployee, article);
                    LoadDGV();
                }
                else
                {
                    articleService.UpdateArticleEmployee(articleEmployee, article);
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
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
                    LoadEmployeeData(); // reload data
                    var empCol = adgvList.Columns["ComboboxEmployee"] as DataGridViewComboBoxColumn;
                    empCol.DataSource = employeeBindingList;
                    //var cmbCell = new DataGridViewComboBoxCell();                    
                    //cmbCell.FlatStyle = FlatStyle.Flat;                    
                    //cmbCell.DataSource = employeeBindingList;          
                    //adgvList.Rows[e.RowIndex].ReadOnly = true;
                    //adgvList.Rows[e.RowIndex].Cells["EmployeeCode"] = cmbCell;
                    //adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].ReadOnly = false;

                    //go to first column
                    SendKeys.Send("{Home}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
                throw ex;
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
                MessageBox.Show("Có lỗi xảy ra! Vui lòng liên hệ kỹ thuật!", "Lưu tiêu đề tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.LogSystem(ex, string.Empty);
            }
            finally
            {
                articleService = null;
            }
        }
    }
}
