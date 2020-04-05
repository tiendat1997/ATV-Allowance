using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Helpers;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.ArticleForms
{
    public partial class ManageTSFormAdvance : CommonForm
    {
        private int articleType = ArticleType.THOI_SU;
        private DateTime fromDate;
        private DateTime toDate;
        private int empId = 0;
        private IArticleService articleService;
        private IEmployeeService employeeService;
        private IPointTypeService pointTypeService;
        private BindingSource articleBindingSource = null;
        private ArticleViewModel model = null;
        private List<ArticleViewModel> articleList = null;
        private List<int> currArticleTypes;
        private List<EmployeeViewModel> empList;
        private List<PointTypeViewModel> listPointType;
        private readonly IAppLogger _logger;

        public ManageTSFormAdvance()
        {
            _logger = new AppLogger();
            components = new System.ComponentModel.Container();
            InitializeComponent();
            InitTabIndex();

            fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            toDate = fromDate.AddMonths(1).AddDays(-1);
            dgvEmployee.ReadOnly = true;
            
            InitDataGridView();
            InitArticleTypeFilter();            
        }
        private void InitTabIndex()
        {
            cbArticleType.TabIndex = 0;
            dtpStartDate.TabIndex = 1;
            dtpEndDate.TabIndex = 2;
            cbEmployee.TabIndex = 3;
            txtSearch.TabIndex = 4;
            adgvList.TabIndex = 5;
            dgvEmployee.TabIndex = 6;
        }

        private void InitDataGridView()
        {
            articleList = new List<ArticleViewModel>();
            articleBindingSource = new BindingSource();
            SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(articleList);
            articleBindingSource.DataSource = sbl;
            articleBindingSource.ListChanged += new ListChangedEventHandler(this.articleBindingSource_ListChanged);
            adgvList.DataSource = articleBindingSource;

            adgvList.AutoGenerateColumns = false;
            adgvList.Columns["Id"].Visible = false;
            adgvList.Columns["TypeId"].Visible = false;
            adgvList.Columns["Title"].Visible = true;
            adgvList.Columns["Code"].Visible = true;
            adgvList.Columns["Date"].Visible = true;

            adgvList.Columns["Title"].HeaderText = ADGVArticleText.Title;
            adgvList.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adgvList.Columns["Code"].HeaderText = ADGVArticleText.Type;
            adgvList.Columns["Code"].Width = 100;
            adgvList.Columns["Date"].HeaderText = ADGVArticleText.Date;
            adgvList.Columns["Date"].Width = ControlsAttribute.GV_WIDTH_MEDIUM;
        }
        private void InitArticleTypeFilter()
        {
            List<ArticleGroup> list = Constants.ArticleTypeGroup.DROPDOWN_VALUE;
            currArticleTypes = list[0].GroupIds;
            cbArticleType.DisplayMember = "Name";
            cbArticleType.ValueMember = "GroupIds";

            cbArticleType.SelectedIndexChanged -= new EventHandler(cbArticleType_SelectedIndexChanged);

            cbArticleType.DataSource = list;
            cbArticleType.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbArticleType.SelectedIndexChanged += new EventHandler(cbArticleType_SelectedIndexChanged);

            dtpStartDate.ValueChanged -= new EventHandler(dtpStartDate_ValueChanged);
            dtpEndDate.ValueChanged -= new EventHandler(dtpEndDate_ValueChanged);

            dtpStartDate.Value = fromDate;
            dtpEndDate.Value = toDate;

            dtpStartDate.ValueChanged += new EventHandler(dtpStartDate_ValueChanged);
            dtpEndDate.ValueChanged += new EventHandler(dtpEndDate_ValueChanged);
        }
        private void RemoveTimePortion()
        {
            fromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day);
            toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day);
        }
        private void LoadDGV()
        {
            try
            {
                RemoveTimePortion();
                articleService = new ArticleService();
                articleList = articleService.GetComboArticle(currArticleTypes, fromDate, toDate, empId);
                SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(articleList);
                //articleBindingSource = new BindingSource();
                articleBindingSource.DataSource = sbl;
                adgvList.DataSource = articleBindingSource;
                adgvList.AutoGenerateColumns = false;

                if (articleList.Count == 0)
                {
                    model = null;
                    dgvEmployee.DataSource = null;
                }
                else
                {
                    this.LoadArticleEmployee(articleList.First());
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

        private void ManageTSForm_Load(object sender, EventArgs e)
        {
            try
            {
                employeeService = new EmployeeService();
                empList = new List<EmployeeViewModel> {
                    new EmployeeViewModel {
                        CodeAndName = "Tất cả",
                        Code = "0"
                    }
                };                
                empList.AddRange(employeeService.GetAllActive(true));
                cbEmployee.DisplayMember = "CodeAndName";
                cbEmployee.ValueMember = "Code";
                cbEmployee.DataSource = empList;
                //cbEmployee.DropDownStyle = ComboBoxStyle.DropDown;
                cbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbEmployee.IntegralHeight = false;
                cbEmployee.MaxDropDownItems = 10;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                employeeService = null;
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {            
            fromDate = dtpStartDate.Value;
            LoadDGV();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            toDate = dtpEndDate.Value;
            LoadDGV();
        }

        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                employeeService = new EmployeeService();
                string empCode = cbEmployee.SelectedValue.ToString();
                EmployeeViewModel emp;
                if (empCode != "0")
                {
                    emp = employeeService.GetEmployeeByCode(empCode);
                    empId = emp.Id;
                }
                else
                {
                    empId = 0;
                }
                LoadDGV();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddArticleForm addForm = new AddArticleForm(articleType);
            addForm.FormClosed += new FormClosedEventHandler(AddArticleForm_Closed);
            addForm.ShowDialog();
        }
        private void AddArticleForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (adgvList.CurrentRow == null)
            {
                LoadDGV();
                return;
            }
            int oldCount = adgvList.Rows.Count - 1;
            int currIndex = adgvList.CurrentRow.Index;
            int selectedIndex = currIndex;
            LoadDGV();
            adgvList.ClearSelection();
            int rowIndex = adgvList.Rows.Count - 1;
            if (rowIndex > oldCount)
            {
                selectedIndex = rowIndex;
            }
            adgvList.Rows[selectedIndex].Selected = true;
            adgvList.CurrentCell = adgvList.Rows[selectedIndex].Cells[1];
        }

        private void AddTSForm_Closed(object sender, FormClosedEventArgs e)
        {
            int rowIndex = adgvList.CurrentRow.Index;
            LoadDGV();
            txtSearch_TextChanged(sender, new EventArgs());
        }
  
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (adgvList.CurrentRow == null)
            {
                return;
            }

            var articleModel = (ArticleViewModel)adgvList.CurrentRow.DataBoundItem;
            if (articleModel != null)
            {
                EditTSForm form = new EditTSForm(articleModel);
                form.FormClosed += new FormClosedEventHandler(AddTSForm_Closed);
                form.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string unsignSearchValue = Utilities.RemoveSign4VietnameseString(txtSearch.Text.ToUpper());
            var filteredList = articleList.Where(t => Utilities.RemoveSign4VietnameseString(t.Title.ToUpper()).Contains(unsignSearchValue)).ToList();
            SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(filteredList);
            //articleBindingSource = new BindingSource();
            articleBindingSource.DataSource = sbl;
            adgvList.DataSource = articleBindingSource;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (model == null)
                {
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa tin này?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    articleService = new ArticleService();
                    articleService.RemoveArticle(model);
                    LoadDGV();
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

        private void cbArticleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curItem = (ArticleGroup)cbArticleType.SelectedItem;
            currArticleTypes = curItem.GroupIds;
            LoadDGV();
        }

        private void adgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var articleModel = (ArticleViewModel)adgvList.CurrentRow.DataBoundItem;
            if (articleModel != null)
            {
                EditTSForm form = new EditTSForm(articleModel);
                form.FormClosed += new FormClosedEventHandler(AddTSForm_Closed);
                form.ShowDialog();
            }
        }

        private void adgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = adgvList.CurrentRow;
            if (currentRow != null)
            {
                var articleModel = (ArticleViewModel)currentRow.DataBoundItem;
                this.LoadArticleEmployee(articleModel);
            }
        }

        private void LoadArticleEmployee(ArticleViewModel article)
        {
            try
            {
                pointTypeService = new PointTypeService();
                articleService = new ArticleService();
                employeeService = new EmployeeService();
                
                listPointType = pointTypeService.GetPointType(article.TypeId);
                List<ArticleEmployeeViewModel> list = articleService.GetArticleEmployee(article.Id, article.TypeId);
                var bindList = ArticleEmployeeHelper.MapToBindingList(article.TypeId, list);
                BindingSource employeeBs = new BindingSource();
                employeeBs.DataSource = bindList;
                dgvEmployee.DataSource = employeeBs;

                // If you want to change column index, you need to disable auto genrate column                 
                //dgvEmployee.AutoGenerateColumns = false;

                // set indexing for the table                
                dgvEmployee.Columns["EmployeeCode"].DisplayIndex = 0;

                // hidden column 
                dgvEmployee.Columns["Id"].Visible = false;
                dgvEmployee.Columns["EmployeeId"].Visible = false;
                dgvEmployee.Columns["ArticleId"].Visible = false;
                dgvEmployee.Columns["Organization"].Visible = false;
                dgvEmployee.Columns["Position"].Visible = false;
                dgvEmployee.Columns["Name"].Visible = false;

                // readonly field before employee selection
                dgvEmployee.Columns["EmployeeCode"].ReadOnly = true;

                dgvEmployee.Columns["EmployeeCode"].HeaderText = ADGVEmployeeText.Code;
                dgvEmployee.Columns["EmployeeCode"].Width = ControlsAttribute.GV_WIDTH_MEDIUM;
                dgvEmployee.Columns["Position"].HeaderText = ADGVEmployeeText.AbbrPosition;
                dgvEmployee.Columns["Position"].Width = ControlsAttribute.GV_WIDTH_SMALL;

                int nextIndex = 2;
                foreach (var type in listPointType)
                {
                    nextIndex++;
                    dgvEmployee.Columns[type.Code].DisplayIndex = nextIndex;
                    dgvEmployee.Columns[type.Code].HeaderText = type.Code;
                    dgvEmployee.Columns[type.Code].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    int colSize = Utilities.GetPointColumnSize(type.Code);
                    dgvEmployee.Columns[type.Code].Width = colSize;
                }                
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, string.Empty);
            }
        }

        private void adgvList_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgvList.FilterString;
            string pattern = @"([a-zA-Z]+)";
            MatchCollection matches = Regex.Matches(tmp, pattern);
            try
            {
                articleBindingSource.Filter = adgvList.FilterString;

            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
        }

        private void cbEmployee_Leave(object sender, EventArgs e)
        {
            if (cbEmployee.Text == String.Empty)
            {
                cbEmployee.SelectedIndex = 0;
            }
        }

        private void adgvList_SortStringChanged(object sender, EventArgs e)
        {
            articleBindingSource.Sort = adgvList.SortString;
        }

        private void articleBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            lblTotal.Text = string.Format("Số lượng tin: {0}", this.articleBindingSource.List.Count);
        }
    }
}
