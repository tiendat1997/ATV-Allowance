using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Helpers;
using ATV_Allowance.Services;
using ATV_Allowance.Validators;
using ATV_Allowance.ViewModel;
using DataService.Entity;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Forms.EmployeeForms
{
    public partial class UpdateEmployeeForm : CommonForm
    {
        private IEmployeeService employeeService;
        private IOrganizationService organizationService;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epOrganization;
        private System.Windows.Forms.ErrorProvider epPosition;
        private System.Windows.Forms.ErrorProvider epCode;
        internal new Dictionary<Control, ErrorProvider> epDic;
        private string currCode;
        public EmployeeViewModel model { get; set; }
        public UpdateEmployeeForm(EmployeeViewModel inputModel)
        {
            this.model = inputModel;
            InitializeComponent();
            InitializeErrorProvider();
            LoadData();            
        }        
        private void LoadData()
        {
            if (model != null)
            {
                txtName.Text = model.Name;
                txtCode.Text = model.Code;
                currCode = model.Code;
                cbOrganizationId.SelectedValue = model.OrganizationId;
                var selectedRb = gbPosition.Controls.OfType<RadioButton>()
                                    .FirstOrDefault(r => r.Name.Equals("rb" + model.Position.ToUpper()));
                selectedRb.Select();
            }
        }
        private void InitializeErrorProvider()
        {
            epName = new System.Windows.Forms.ErrorProvider(components);
            epOrganization = new System.Windows.Forms.ErrorProvider(this.components);
            epPosition = new System.Windows.Forms.ErrorProvider(this.components);
            epCode = new System.Windows.Forms.ErrorProvider(this.components);
            epDic = new Dictionary<Control, ErrorProvider>();
            epDic.Add(txtName, epName);
            epDic.Add(cbOrganizationId, epOrganization);
            epDic.Add(txtCode, epCode);
        }
        private void UpdateEmployeeForm_Load(object sender, EventArgs e)
        {
            try
            {
                organizationService = new OrganizationService();
                List<Organization> list = organizationService.GetAll();
                cbOrganizationId.DisplayMember = "Name";
                cbOrganizationId.DataSource = list;
                cbOrganizationId.AutoCompleteMode = AutoCompleteMode.Suggest;
                cbOrganizationId.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                organizationService = null;
            }
        }
        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                return;
            }
            try
            {
                employeeService = new EmployeeService();
                string tmpName = txtName.Text.ToUpper();                
                string generatedCode = employeeService.GenerateEmployeeCode(tmpName, currCode);
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                employeeService = new EmployeeService();
                ValidatorHelper.ClearEPValidation(epDic);
                var checkedButton = gbPosition.Controls.OfType<RadioButton>()
                                    .FirstOrDefault(r => r.Checked);
                var org = (Organization)cbOrganizationId.SelectedValue;
                string empName = txtName.Text;
                string empCode = txtCode.Text;
                int posId = -1;
                int orgId = -1;

                if (org != null)
                {
                    orgId = org.Id;
                }

                if (checkedButton != null)
                {
                    string positionCode = checkedButton.Text;
                    var position = employeeService.GetPositionByCode(positionCode);
                    if (position != null)
                    {
                        posId = position.Id;
                    }
                }
                Employee newEmp = new Employee()
                {
                    Id = model.Id,
                    Code = empCode,
                    Name = empName,
                    OrganizationId = orgId,
                    RoleId = posId,
                    IsActive = true
                };
                bool result = btnUpdate_Validate(newEmp);
                if (result)
                {
                    employeeService.UpdateEmployee(newEmp);
                    this.Close();
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
        private bool btnUpdate_Validate(Employee emp)
        {
            EmployeeValidator validator = new EmployeeValidator();
            ValidationResult result = validator.Validate(emp);
            if (result.IsValid == false)
            {
                ValidatorHelper.ShowValidationMessage(gbStudentInfo, result.Errors, epDic);
            }
            return result.IsValid;
        }
    }
}
