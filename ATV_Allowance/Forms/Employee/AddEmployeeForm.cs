using ATV_Allowance.Common;
using ATV_Allowance.Services;
using DataService.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Forms.Employee
{
    public partial class AddEmployeeForm : Form
    {
        private IEmployeeService employeeService;
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            List<Organization> list = new List<Organization>
            {
                new Organization
                {
                    Id = 1,
                    Name = "Đài Phát Thanh"
                },
                new Organization
                {
                    Id = 2,
                    Name = "Châu phú"
                },
                new Organization
                {
                    Id = 3,
                    Name = "Châu thành"
                }
            };
            cbOrganization.DisplayMember = "Name";
            cbOrganization.DataSource = list;
            cbOrganization.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbOrganization.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var checkedButton = gbPosition.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            var org = (Organization)cbOrganization.SelectedValue;
            string empName = txtName.Text;
            string empCode = txtCode.Text;
            if (checkedButton != null)
            {
                string positionCode = checkedButton.Text;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            try
            {
                employeeService = new EmployeeService();
                string tmpName = txtName.Text.ToUpper();
                string generatedCode = employeeService.GenerateEmployeeCode(tmpName);
                txtCode.Text = generatedCode;
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
