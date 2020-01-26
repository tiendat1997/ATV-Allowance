using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Services;
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
    public partial class ManageTSForm : CommonForm
    {
        private int articleType = ArticleType.THOI_SU;
        private DateTime fromDate = DateTime.Now;
        private DateTime toDate = DateTime.Now;
        private int empId = 0;
        private IArticleService articleService;
        private IEmployeeService employeeService;
        private BindingSource bs = null;
        private ArticleViewModel model = null;
        private List<ArticleViewModel> articleList = null;
        private List<int> currArticleTypes;
        private List<string> empList;

        public ManageTSForm()
        {
            components = new System.ComponentModel.Container();
            InitializeComponent();
            InitDataGridView();
            InitArticleTypeFilter();            
        }
        private void InitDataGridView()
        {
            articleList = new List<ArticleViewModel>();
            bs = new BindingSource();
            SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(articleList);
            bs.DataSource = sbl;
            adgvList.DataSource = bs;

            adgvList.Columns["Id"].Visible = false;
            adgvList.Columns["TypeId"].Visible = false;
            adgvList.Columns["Title"].Visible = true;
            adgvList.Columns["Code"].Visible = true;
            adgvList.Columns["Date"].Visible = true;

            adgvList.Columns["Title"].HeaderText = ADGVArticleText.Title;
            adgvList.Columns["Title"].Width = ControlsAttribute.GV_WIDTH_LARGE_XX;
            adgvList.Columns["Code"].HeaderText = ADGVArticleText.Type;
            adgvList.Columns["Code"].Width = ControlsAttribute.GV_WIDTH_SEEM;
            adgvList.Columns["Date"].HeaderText = ADGVArticleText.Date;
            adgvList.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void InitArticleTypeFilter()
        {
            List<ArticleGroup> list = Constants.ArticleTypeGroup.DROPDOWN_VALUE;
            currArticleTypes = list[0].GroupIds;
            cbArticleType.DisplayMember = "Name";
            cbArticleType.ValueMember = "GroupIds";
            cbArticleType.DataSource = list;
            cbArticleType.AutoCompleteSource = AutoCompleteSource.ListItems;
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
                bs = new BindingSource();
                articleList = articleService.GetComboArticle(currArticleTypes, fromDate, toDate, empId);
                SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(articleList);
                bs.DataSource = sbl;
                adgvList.DataSource = bs;

                if (articleList.Count == 0)
                {
                    model = null;
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
                empList = new List<string> { "Tất cả" };
                empList.AddRange(employeeService.GetAllEmployeeCode(true));
                cbEmployee.DisplayMember = "Name";
                cbEmployee.DataSource = empList;
                cbEmployee.DropDownStyle = ComboBoxStyle.DropDown;
                cbEmployee.AutoCompleteMode = AutoCompleteMode.Suggest;
                cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
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
                string empCode = (string)cbEmployee.SelectedValue;
                EmployeeViewModel emp;
                if (empCode != "Tất cả")
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
                throw;
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
            adgvList_SelectionChanged(sender, e);
        }

        private void AddTSForm_Closed(object sender, FormClosedEventArgs e)
        {
            int rowIndex = adgvList.CurrentRow.Index;
            LoadDGV();
        }

        private void adgvList_SelectionChanged(object sender, EventArgs e)
        {
            model = (ArticleViewModel)adgvList.CurrentRow.DataBoundItem;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (model != null)
            {
                EditTSForm form = new EditTSForm(model);
                form.FormClosed += new FormClosedEventHandler(AddTSForm_Closed);
                form.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string unsignSearchValue = Utilities.RemoveSign4VietnameseString(txtSearch.Text.ToUpper());
            var filteredList = articleList.Where(t => Utilities.RemoveSign4VietnameseString(t.Title.ToUpper()).Contains(unsignSearchValue)).ToList();
            SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(filteredList);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvList.DataSource = bs;
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
    }
}
