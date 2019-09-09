﻿using ATV_Allowance.Common;
using ATV_Allowance.Helpers;
using ATV_Allowance.Services;
using ATV_Allowance.Validators;
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
    public partial class AddEmployeeForm : Form
    {
        private IEmployeeService employeeService;
        private IOrganizationService organizationService;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epOrganization;
        private System.Windows.Forms.ErrorProvider epPosition;
        private System.Windows.Forms.ErrorProvider epCode;
        internal new Dictionary<Control, ErrorProvider> epDic;
        public AddEmployeeForm()
        {
            InitializeComponent();
            epName = new System.Windows.Forms.ErrorProvider(components);
            epOrganization = new System.Windows.Forms.ErrorProvider(this.components);
            epPosition = new System.Windows.Forms.ErrorProvider(this.components);
            epCode = new System.Windows.Forms.ErrorProvider(this.components);
            epDic = new Dictionary<Control, ErrorProvider>();
            epDic.Add(txtName, epName);
            epDic.Add(cbOrganizationId, epOrganization);
            epDic.Add(txtCode, epCode);
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
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
        private bool btnAdd_Validate(Employee emp)
        {            
            EmployeeValidator validator = new EmployeeValidator();
            ValidationResult result = validator.Validate(emp);   
            if (result.IsValid == false)
            {
                ValidatorHelper.ShowValidationMessage(gbStudentInfo, result.Errors, epDic);
            }
            return result.IsValid;
        }
        private void btnAdd_Click(object sender, EventArgs e)
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
                    Code = empCode,
                    Name = empName,
                    OrganizationId = orgId,
                    RoleId = posId,
                    IsActive = true
                };
                bool result = btnAdd_Validate(newEmp);
                if (result)
                {
                    employeeService.AddEmployee(newEmp);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;                
            }
            finally
            {
                employeeService = null;
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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {           
        }        
    }
}
