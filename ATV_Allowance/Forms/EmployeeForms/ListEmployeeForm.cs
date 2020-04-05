using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
using DataService.Entity;
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

namespace ATV_Allowance.Forms.EmployeeForms
{
    public partial class ListEmployeeForm : CommonForm
    {
        private BindingSource articleBs = null;
        private EmployeeViewModel employee = null;
        private IEmployeeService employeeService = null;
        private List<EmployeeViewModel> list = null;
        public ListEmployeeForm()
        {
            InitializeComponent();
            InitTabIndex();
            LoadDGV();
        }
        private void InitTabIndex()
        {
            txtSearch.TabIndex = 0;
            adgvEmployee.TabIndex = 1;
            btnAdd.TabIndex = 2;
            btnEdit.TabIndex = 3;
            btnRemove.TabIndex = 4;
        }
        private void LoadDGV()
        {
            try
            {
                employeeService = new EmployeeService();
                list = employeeService.GetAllActive(true);
                SortableBindingList<EmployeeViewModel> sbl = new SortableBindingList<EmployeeViewModel>(list);
                articleBs = new BindingSource();
                articleBs.ListChanged += new ListChangedEventHandler(this.articleBindingSource_ListChanged);
                articleBs.DataSource = sbl;
                adgvEmployee.DataSource = articleBs;
                adgvEmployee.AutoGenerateColumns = false;

                adgvEmployee.Columns["Id"].Visible = false;
                adgvEmployee.Columns["OrganizationId"].Visible = false;
                adgvEmployee.Columns["PositionId"].Visible = false;
                adgvEmployee.Columns["CodeAndName"].Visible = false;

                adgvEmployee.Columns["Code"].Visible = true;
                adgvEmployee.Columns["Name"].Visible = true;
                adgvEmployee.Columns["Position"].Visible = true;
                adgvEmployee.Columns["Organization"].Visible = true;
                adgvEmployee.Columns["IsActive"].Visible = false;                
                
                adgvEmployee.Columns["Code"].HeaderText = ADGVEmployeeText.Code;
                adgvEmployee.Columns["Code"].Width = 200;
                adgvEmployee.Columns["Name"].HeaderText = ADGVEmployeeText.Name;
                adgvEmployee.Columns["Name"].Width = ControlsAttribute.GV_WIDTH_LARGE;                
                adgvEmployee.Columns["Position"].HeaderText = ADGVEmployeeText.Position;
                adgvEmployee.Columns["Position"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                adgvEmployee.Columns["Organization"].HeaderText = ADGVEmployeeText.Organization;
                adgvEmployee.Columns["Organization"].Width = ControlsAttribute.GV_WIDTH_LARGE;
                adgvEmployee.Columns["Title"].HeaderText = ADGVEmployeeText.Title;
                adgvEmployee.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Set selected employee 
                if (list.Count > 0)
                {
                    employee = list[0];
                }
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

        private void adgvEmployee_SortStringChanged(object sender, EventArgs e)
        {
            articleBs.Sort = adgvEmployee.SortString;
        }

        private void adgvEmployee_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgvEmployee.FilterString;
            string pattern = @"([a-zA-Z]+)";
            MatchCollection matches = Regex.Matches(tmp, pattern);
            try
            {
                articleBs.Filter = adgvEmployee.FilterString;
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
        }

        private void articleBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            lblTotal.Text = string.Format("Số lượng: {0}", this.articleBs.List.Count);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmployeeForm detailForm = new AddEmployeeForm();
            detailForm.FormClosed += new FormClosedEventHandler(AddEmployeeForm_Closed);
            detailForm.ShowDialog();
        }
        private void AddEmployeeForm_Closed(object sender, FormClosedEventArgs e)
        {

            if (adgvEmployee.CurrentRow == null)
            {
                LoadDGV();
                return;
            }
            int oldCount = adgvEmployee.Rows.Count - 1;            
            int currIndex = adgvEmployee.CurrentRow.Index;
            int selectedIndex = currIndex;
            LoadDGV();
            txtSearch_TextChanged(sender, new EventArgs());
            adgvEmployee.ClearSelection();
            int rowIndex = adgvEmployee.Rows.Count - 1;
            if (rowIndex > oldCount)
            {
                selectedIndex = rowIndex;
            }
            adgvEmployee.Rows[selectedIndex].Selected = true;
            adgvEmployee.CurrentCell = adgvEmployee.Rows[selectedIndex].Cells[1];
        }
        private void EditEmployeeForm_Closed(object sender, FormClosedEventArgs e)
        {
            int rowIndex = adgvEmployee.CurrentRow.Index;
            LoadDGV();
            txtSearch_TextChanged(sender, new EventArgs());
            adgvEmployee.ClearSelection();
            adgvEmployee.Rows[rowIndex].Selected = true;
            adgvEmployee.CurrentCell = adgvEmployee.Rows[rowIndex].Cells[1];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var employeeSrc = (EmployeeViewModel)adgvEmployee.CurrentRow.DataBoundItem;
            if (employeeSrc != null)
            {
                UpdateEmployeeForm detailForm = new UpdateEmployeeForm(employeeSrc);
                detailForm.FormClosed += new FormClosedEventHandler(EditEmployeeForm_Closed);
                detailForm.ShowDialog();
            }
        }
       
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var employeeSrc = (EmployeeViewModel)adgvEmployee.CurrentRow.DataBoundItem;
                if (employeeSrc != null)
                {
                    if (MessageBox.Show("Xác nhận xóa nhân viên", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        employeeService = new EmployeeService();
                        var empEntity = new Employee { Id = employeeSrc.Id, IsActive = employeeSrc.IsActive };
                        employeeService.DeactiveEmployee(empEntity);
                        LoadDGV();
                    }
                }
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
            string unsignSearchValue = Utilities.RemoveSign4VietnameseString(txtSearch.Text.ToUpper());
            var filteredList = list.Where(t => Utilities.RemoveSign4VietnameseString(t.CodeAndName.ToUpper()).Contains(unsignSearchValue)).ToList();
            SortableBindingList<EmployeeViewModel> sbl = new SortableBindingList<EmployeeViewModel>(filteredList);
            articleBs = new BindingSource();
            articleBs.ListChanged += new ListChangedEventHandler(this.articleBindingSource_ListChanged);
            articleBs.DataSource = sbl;
            adgvEmployee.DataSource = articleBs;
        }

        private void adgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var employeeSrc = (EmployeeViewModel)adgvEmployee.Rows[e.RowIndex].DataBoundItem;
            if (employeeSrc != null)
            {
                UpdateEmployeeForm detailForm = new UpdateEmployeeForm(employeeSrc);
                detailForm.FormClosed += new FormClosedEventHandler(EditEmployeeForm_Closed);
                detailForm.ShowDialog();
            }
        }
    }
}
