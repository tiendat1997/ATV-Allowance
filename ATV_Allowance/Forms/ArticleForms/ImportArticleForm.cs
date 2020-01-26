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
    public partial class ImportArticleForm : CommonForm
    {
        private List<string> pointCodes;
        private BindingSource bs = null;
        private ArticleViewModel article;
        private int articleTypeId;
        private IArticleService articleService;
        private IPointTypeService pointTypeService;
        private IEmployeeService employeeService;
        private System.Windows.Forms.ErrorProvider epArticleTitle;
        private ComboBox comboBox;
        private List<string> empList;
        private List<ArticleViewModel> articleList;
        private List<PointTypeViewModel> listPointType;
        internal Dictionary<Control, ErrorProvider> epDic;
        private DateTime currDate;
        public ImportArticleForm(int articleTypeId, List<string> pointCodes)
        {
            this.components = new System.ComponentModel.Container();
            InitializeComponent();
            InitializeErrorProvider();
            InitializeTabIndex();

            this.pointCodes = pointCodes;
            this.articleTypeId = articleTypeId;

            this.Text = GetArticleTypeName(articleTypeId);
            LoadEmployeeData();
            LoadArticleData();
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
        private string GetArticleTypeName(int typeId)
        {
            string typeName = "Nhập ";
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
                    typeName += "thông tin ngày mới";
                    break;
                case 5:
                    typeName += "biên soạn thông tin ngày mới";
                    break;
                case 6:
                    typeName += "khối hậu kỳ biên soạn thông tin ngày mới";
                    break;
                default:
                    break;
            }
            return typeName;
        }
        private void InitializeTabIndex()
        {
            dtpDate.TabIndex = 0;
            nudOrdinal.TabIndex = 1;
            txtTitle.TabIndex = 2;
            adgvList.TabIndex = 3;
        }

        private void InitializeErrorProvider()
        {
            epDic = new Dictionary<Control, ErrorProvider>();
            epArticleTitle = new System.Windows.Forms.ErrorProvider(components);
            epDic.Add(txtTitle, epArticleTitle);
        }
     
        private void LoadArticleData()
        {
            try
            {
                articleService = new ArticleService();
                articleList = articleService.GetArticle(this.articleTypeId, currDate, currDate, 0);
                nudOrdinal.Maximum = articleList.Count;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void DisplayColumnIndex()
        {

        }
        private void LoadDGV()
        {
            try
            {
                pointTypeService = new PointTypeService();
                articleService = new ArticleService();
                bs = new BindingSource();

                listPointType = pointTypeService.GetPointType(articleTypeId);

                List<ArticleEmployeeViewModel> list = new List<ArticleEmployeeViewModel>();
                if (article != null)
                {
                    list = articleService.GetArticleEmployee(article.Id, article.TypeId);                    
                }    
                
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
                adgvList.Columns["EmployeeCode"].Width = ControlsAttribute.GV_WIDTH_MEDIUM;
                adgvList.Columns["Name"].HeaderText = ADGVEmployeeText.Name;
                adgvList.Columns["Name"].Width = ControlsAttribute.GV_WIDTH_LARGE;
                adgvList.Columns["Position"].HeaderText = ADGVEmployeeText.AbbrPosition;
                adgvList.Columns["Position"].Width = ControlsAttribute.GV_WIDTH_SMALL;
                adgvList.Columns["Organization"].HeaderText = ADGVEmployeeText.Organization;
                adgvList.Columns["Organization"].Width = ControlsAttribute.GV_WIDTH_LARGE;
                
                int nextIndex = 3;
                foreach (var type in listPointType)
                {
                    nextIndex++;
                    adgvList.Columns[type.Code].DisplayIndex = nextIndex;
                    adgvList.Columns[type.Code].HeaderText = type.Code;
                    adgvList.Columns[type.Code].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                adgvList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(adgvList_EditingControlShowing);                
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }
        private void EditTSForm_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDate.Value = DateTime.Now;
                nudOrdinal.Minimum = 0;
                adgvList.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void adgvList_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void adgvList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;

                if (articleEmployee != null && articleEmployee.Name != null)
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
        }
        private void ConfirmBeforeDelete()
        {
            var confirmResult = DialogHelper.OpenConfirmationDialog("Bạn có chắc muốn xóa nhân viên ra khỏi tin này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;
                if (articleEmployee != null)
                {
                    articleEmployee.ArticleId = article.Id;
                    articleService.RemoveArticleEmployee(articleEmployee);
                }
            }           
        }
        private void adgvList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                if (adgvList.CurrentRow.IsNewRow == false)
                {
                    ConfirmBeforeDelete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                currDate = Utilities.RemoveTimePortion(dtpDate.Value);
                LoadArticleData();
                // set the new index
                nudOrdinal.Value = articleList.Count;
                ResetDGV();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) // ENTER

            {
                // Then Do your Thang
                try
                {
                    articleService = new ArticleService();
                    // validation            
                    if (string.IsNullOrEmpty(txtTitle.Text))
                    {
                        //epArticleTitle.SetError(txtTitle, "Vui lòng nhập tiêu đề tin");
                    }
                    else
                    {
                        //epArticleTitle.SetError(txtTitle, "");
                        if (article == null)
                        {
                            // add article                            
                            Article newEmp = new Article()
                            {
                                Title = txtTitle.Text,
                                Date = currDate,
                                TypeId = articleTypeId,
                                IsActive = true
                            };
                            articleService.AddArticle(newEmp);
                        }
                        //// load adgv                         
                        LoadArticleData();
                        int articleIndex = (int)nudOrdinal.Value;

                        article = articleList[articleIndex];
                        article.Title = txtTitle.Text;
                        articleService.UpdateArticle(article);
                        adgvList.ReadOnly = false;
                        LoadDGV();
                        this.ActiveControl = adgvList;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private void nudOrdinal_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // change text value
                int selectedIndex = (int)nudOrdinal.Value;

                if (selectedIndex < articleList.Count)
                {
                    // before new article
                    article = articleList[selectedIndex];
                    txtTitle.Text = article.Title;
                }
                else
                {
                    // check if after new article
                    article = null;
                    txtTitle.Text = string.Empty;
                }
                ResetDGV();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ResetDGV()
        {
            adgvList.Rows.Clear();
            adgvList.ReadOnly = true;
            adgvList.Refresh();
        }

        private void nudOrdinal_Enter(object sender, EventArgs e)
        {
            nudOrdinal.Select(0, nudOrdinal.Text.Length);
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
                    adgvList.Rows[e.RowIndex].ReadOnly = true;
                    adgvList.Rows[e.RowIndex].Cells["EmployeeCode"] = cmbCell;
                    adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].ReadOnly = false;
                    adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].Selected = true;

                    //go to first column
                    SendKeys.Send("{Home}");
                }
            }
            catch (Exception ex)
            {
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

        private void adgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            adgvList.Rows[e.RowIndex].Cells["EmployeeCode"].Value = "";            
            e.Cancel = true;
        }

        private void btnArticleList_Click(object sender, EventArgs e)
        {
            List<IndexedArticleViewModel> indexArticleList = new List<IndexedArticleViewModel>();
            for (int i = 0; i < articleList.Count; i++)
            {
                var item = articleList[i];
                indexArticleList.Add(new IndexedArticleViewModel
                {
                    Id = item.Id,
                    Index = i,
                    Title = item.Title
                });
            }
            
            ArticleListForm form = new ArticleListForm(indexArticleList);
            form.FormClosed += new FormClosedEventHandler(ArticleListForm_Closed);
            form.ShowDialog();
        }

        private void ArticleListForm_Closed(object sender, FormClosedEventArgs e)
        {
            var form = sender as ArticleListForm;
            var indexedArticle = form.IndexedArticle;           
            if (indexedArticle != null)
            {
                article = articleList.Where(a => a.Id == indexedArticle.Id).FirstOrDefault();
                txtTitle.Text = article.Title;
                nudOrdinal.Value = indexedArticle.Index;
                adgvList.ReadOnly = false;
                LoadDGV();
            }            
        }
    }
}
