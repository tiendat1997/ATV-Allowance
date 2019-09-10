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
        private BindingSource bs = null;
        private EmployeeViewModel employee = null;
        private IEmployeeService employeeService = null;
        public ListEmployeeForm()
        {
            InitializeComponent();
            LoadDGV();
        }
        private void LoadDGV()
        {
            IEmployeeService employeeService = null;
            try
            {
                employeeService = new EmployeeService();
                List<EmployeeViewModel> list = employeeService.GetAllActive(true);
                SortableBindingList<EmployeeViewModel> sbl = new SortableBindingList<EmployeeViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvEmployee.DataSource = bs;

                adgvEmployee.Columns["Id"].Visible = false;
                adgvEmployee.Columns["OrganizationId"].Visible = false;
                adgvEmployee.Columns["PositionId"].Visible = false;
                adgvEmployee.Columns["Code"].Visible = true;
                adgvEmployee.Columns["Name"].Visible = true;
                adgvEmployee.Columns["Position"].Visible = true;
                adgvEmployee.Columns["Organization"].Visible = true;
                adgvEmployee.Columns["IsActive"].Visible = false;

                adgvEmployee.Columns["Code"].HeaderText = ADGVEmployeeText.Code;
                adgvEmployee.Columns["Code"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgvEmployee.Columns["Name"].HeaderText = ADGVEmployeeText.Name;
                adgvEmployee.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgvEmployee.Columns["Position"].HeaderText = ADGVEmployeeText.Position;
                adgvEmployee.Columns["Position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgvEmployee.Columns["Organization"].HeaderText = ADGVEmployeeText.Organization;
                adgvEmployee.Columns["Organization"].Width = ControlsAttribute.GV_WIDTH_NORMAL;

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
            bs.Sort = adgvEmployee.SortString;
        }

        private void adgvEmployee_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgvEmployee.FilterString;
            string pattern = @"([a-zA-Z]+)";
            MatchCollection matches = Regex.Matches(tmp, pattern);
            try
            {
                bs.Filter = adgvEmployee.FilterString;
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmployeeForm detailForm = new AddEmployeeForm();
            detailForm.FormClosed += new FormClosedEventHandler(AddEmployeeForm_Closed);
            detailForm.ShowDialog();
        }
        private void AddEmployeeForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
            adgvEmployee.ClearSelection();
            int rowIndex = adgvEmployee.Rows.Count - 1;
            adgvEmployee.Rows[rowIndex].Selected = true;
            adgvEmployee.CurrentCell = adgvEmployee.Rows[rowIndex].Cells[1];
            adgvEmployee_SelectionChanged(sender, e);
        }
        private void EditEmployeeForm_Closed(object sender, FormClosedEventArgs e)
        {
            int rowIndex = adgvEmployee.CurrentRow.Index;
            LoadDGV();
            adgvEmployee.ClearSelection();
            adgvEmployee.Rows[rowIndex].Selected = true;
            adgvEmployee.CurrentCell = adgvEmployee.Rows[rowIndex].Cells[1];
            adgvEmployee_SelectionChanged(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (employee != null)
            {
                UpdateEmployeeForm detailForm = new UpdateEmployeeForm(employee);
                detailForm.FormClosed += new FormClosedEventHandler(EditEmployeeForm_Closed);
                detailForm.ShowDialog();
            }
        }

        private void adgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            employee = (EmployeeViewModel)adgvEmployee.CurrentRow.DataBoundItem;
        }

        private void adgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            employee = (EmployeeViewModel)adgvEmployee.CurrentRow.DataBoundItem;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận xóa nhân viên", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    employee = (EmployeeViewModel)adgvEmployee.CurrentRow.DataBoundItem;
                    employeeService = new EmployeeService();
                    var empEntity = new Employee { Id = employee.Id, IsActive = employee.IsActive };
                    employeeService.DeactiveEmployee(empEntity);
                    LoadDGV();
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
    }
}
