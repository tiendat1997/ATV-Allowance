using ATV_Allowance.Common;
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

namespace ATV_Allowance.Forms.Employee
{
    public partial class ListEmployeeForm : Form
    {        
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

            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                employeeService = null;
            }
        }
        private BindingSource bs = null;

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
        }

    }
}
