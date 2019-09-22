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
    public partial class ManagePTTTForm : CommonForm
    {
        private int articleType = ArticleType.PHAT_THANH_TT;
        private DateTime fromDate = DateTime.Now;
        private DateTime toDate = DateTime.Now;
        private int empId = -1;
        private IArticleService articleService;
        private IEmployeeService employeeService;
        private BindingSource bs = null;
        private ArticleViewModel model = null;
        private List<ArticleViewModel> articleList = new List<ArticleViewModel>();
        public ManagePTTTForm()
        {
            InitializeComponent();
            LoadDGV();
        }

        private void LoadDGV()
        {
            try
            {
                RemoveTimePortion();
                articleService = new ArticleService();
                bs = new BindingSource();
                articleList = articleService.GetArticle(articleType, fromDate, toDate, empId);
                SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(articleList);
                bs.DataSource = sbl;
                adgvList.DataSource = bs;
                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["TypeId"].Visible = false;
                adgvList.Columns["Title"].Visible = true;
                adgvList.Columns["Date"].Visible = true;

                adgvList.Columns["Title"].HeaderText = ADGVArticleText.Title;
                adgvList.Columns["Title"].Width = ControlsAttribute.GV_WIDTH_LARGE_XX;
                adgvList.Columns["Date"].HeaderText = ADGVArticleText.Date;
                adgvList.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

        private void RemoveTimePortion()
        {
            fromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day);
            toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day);
        }

        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            var emp = (EmployeeViewModel)cbEmployee.SelectedValue;
            empId = emp.Id;
            LoadDGV();
        }
        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            toDate = dtpEndDate.Value;
            LoadDGV();
        }
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            fromDate = dtpStartDate.Value;
            LoadDGV();
        }
        private void ManagePTForm_Load(object sender, EventArgs e)
        {
            try
            {
                employeeService = new EmployeeService();
                List<EmployeeViewModel> list = new List<EmployeeViewModel>
                {
                    new EmployeeViewModel
                    {
                        Id = -1,
                        Name = "<chọn nhân viên />" // empty employee
                    }
                };
                list.AddRange(employeeService.GetAllActive(true));
                cbEmployee.DisplayMember = "Name";
                cbEmployee.DataSource = list;
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var filteredList = articleList.Where(t => t.Title.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(filteredList);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvList.DataSource = bs;
        }
        private void adgvList_SelectionChanged(object sender, EventArgs e)
        {
            model = (ArticleViewModel)adgvList.CurrentRow.DataBoundItem;
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
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (model == null)
                {
                    return;
                }
                if (MessageBox.Show("Xác nhận xóa nhân viên", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void AddTSForm_Closed(object sender, FormClosedEventArgs e)
        {
            int rowIndex = adgvList.CurrentRow.Index;
            LoadDGV();
            //adgvList.ClearSelection();
            //adgvList.Rows[rowIndex].Selected = true;
            //adgvList.CurrentCell = adgvList.Rows[rowIndex].Cells[1];
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
    }
}
