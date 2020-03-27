﻿using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
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
    public partial class AddEmployeeForm : CommonForm
    {
        private IEmployeeService employeeService;
        private IOrganizationService organizationService;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epOrganization;
        private System.Windows.Forms.ErrorProvider epPosition;
        private System.Windows.Forms.ErrorProvider epCode;
        private List<OrganizationViewModel> orgList;
        internal new Dictionary<Control, ErrorProvider> epDic;
        private IAppLogger _logger;
        public AddEmployeeForm()
        {
            components = new System.ComponentModel.Container();
            InitializeComponent();
            InitializeTabIndex();
            InitializeErrorProvider();
            _logger = new AppLogger();
        }
        private void InitializeTabIndex()
        {
            txtCode.TabIndex = 0;
            txtName.TabIndex = 1;
            //cbOrganizationId.TabIndex = 2;
            txtOrganization.TabIndex = 2;
            txtTitle.TabIndex = 3;
            gbPosition.TabIndex = 4;
            btnAdd.TabIndex = 5;
        }
        private void InitializeErrorProvider()
        {
            epName = new System.Windows.Forms.ErrorProvider(components);
            epOrganization = new System.Windows.Forms.ErrorProvider(this.components);
            epPosition = new System.Windows.Forms.ErrorProvider(this.components);
            epCode = new System.Windows.Forms.ErrorProvider(this.components);
            epDic = new Dictionary<Control, ErrorProvider>();
            epDic.Add(txtName, epName);
            //epDic.Add(cbOrganizationId, epOrganization);
            epDic.Add(txtOrganization, epOrganization);
            epDic.Add(txtCode, epCode);
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            try
            {
                organizationService = new OrganizationService();
                orgList = organizationService.GetAllIsActive(true);
                //cbOrganizationId.DisplayMember = "Name";
                //cbOrganizationId.DataSource = orgList;
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
            string existedCode = epCode.GetError(txtCode);
            if (result.IsValid == false)
            {
                ValidatorHelper.ShowValidationMessage(gbStudentInfo, result.Errors, epDic);
            }
            bool isValid = result.IsValid;

            if (string.IsNullOrEmpty(existedCode) == false)
            {
                isValid = false;
            }

            return isValid;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };

            try
            {
                employeeService = new EmployeeService();
                
                var checkedButton = gbPosition.Controls.OfType<RadioButton>()
                                    .FirstOrDefault(r => r.Checked);
                //var org = (OrganizationViewModel)cbOrganizationId.SelectedValue;                
                string empName = txtName.Text;
                string empCode = txtCode.Text;
                string organization = txtOrganization.Text.Trim();
                string title = txtTitle.Text.Trim();
                int posId = -1;
                //int orgId = -1;

                //if (org != null)
                //{
                //    orgId = org.Id;
                //}

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
                    //OrganizationId = orgId,
                    Organization = organization,
                    RoleId = posId,
                    IsActive = true,
                    Title = title
                };
                actionLog.Message = string.Format(AppActions.Employee_Add, newEmp.Code);
                bool result = btnAdd_Validate(newEmp);
                if (result)
                {
                    employeeService.AddEmployee(newEmp);
                    ValidatorHelper.ClearEPValidation(epDic);
                    
                    DialogHelper.OpenActionResultDialog("Lưu thành công", "Thêm nhân viên");
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, AppActions.Employee_Add);
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                MessageBox.Show("Có lỗi xảy ra! Vui lòng liên hệ kỹ thuật!", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _logger.LogBusiness(actionLog);
                employeeService = null;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                return;
            }
        }     

        //private void cbOrganizationId_TextUpdate(object sender, EventArgs e)
        //{
        //    string filter_param = cbOrganizationId.Text.ToLower();
        //    List<OrganizationViewModel> filteredItems = orgList.FindAll(x => x.Name.ToLower().Contains(filter_param));

        //    cbOrganizationId.DataSource = filteredItems;

        //    if (String.IsNullOrWhiteSpace(filter_param))
        //    {
        //        cbOrganizationId.DataSource = orgList;
        //    }
        //    cbOrganizationId.DroppedDown = true;

        //    // this will ensure that the drop down is as long as the list
        //    cbOrganizationId.IntegralHeight = true;

        //    // remove automatically selected first item
        //    cbOrganizationId.SelectedIndex = -1;
        //    cbOrganizationId.Text = filter_param;

        //    // set the position of the cursor
        //    cbOrganizationId.SelectionStart = filter_param.Length;
        //    cbOrganizationId.SelectionLength = 0;
        //    Cursor.Current = Cursors.Default;
        //}

        private void txtCode_Leave(object sender, EventArgs e)
        {            
            try
            {
                string code = txtCode.Text.Trim().ToUpper();
                employeeService = new EmployeeService();
                var existedEmployee = employeeService.GetEmployeeByCode(code);
                if (existedEmployee != null)
                {
                    epCode.SetError(txtCode, "Mã nhân viên đã tồn tại");
                }
                else
                {
                    epCode.SetError(txtCode, string.Empty);
                    txtCode.Text = code;
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, AppActions.Employee_Add);
                MessageBox.Show("Có lỗi xảy ra! Vui lòng liên hệ kỹ thuật!", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                employeeService = null;
            }
        }
    }
}
