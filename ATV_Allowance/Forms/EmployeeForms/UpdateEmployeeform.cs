using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
using ATV_Allowance.Enums;
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
        private List<OrganizationViewModel> orgList;
        private string currCode;
        public EmployeeViewModel model { get; set; }
        private readonly IAppLogger _logger;
        public UpdateEmployeeForm(EmployeeViewModel inputModel)
        {
            _logger = new AppLogger();
            this.model = inputModel;
            components = new System.ComponentModel.Container();
            InitializeComponent();
            InitializeErrorProvider();
        }        
        private void LoadData()
        {
            if (model != null)
            {
                txtName.Text = model.Name;
                txtCode.Text = model.Code;
                txtTitle.Text = model.Title ?? "";
                currCode = model.Code;
                int index = orgList.FindIndex(t => t.Id == model.OrganizationId);
                cbOrganizationId.SelectedIndex = index;
                var selectedRb = gbPosition.Controls.OfType<RadioButton>()
                                    .FirstOrDefault(r => r.Name.Equals("rb" + model.Position.ToUpper()));
                selectedRb.Checked = true;
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
                orgList = organizationService.GetAllIsActive(true);                
                cbOrganizationId.DisplayMember = "Name";
                cbOrganizationId.DataSource = orgList;
                cbOrganizationId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbOrganizationId.AutoCompleteSource = AutoCompleteSource.ListItems;
                LoadData();
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
                //string tmpName = txtName.Text.ToUpper();                
                //string generatedCode = employeeService.GenerateEmployeeCode(tmpName, currCode);
                //txtCode.Text = generatedCode;
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
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.UPDATE
            };

            try
            {
                employeeService = new EmployeeService();
                
                var checkedButton = gbPosition.Controls.OfType<RadioButton>()
                                    .FirstOrDefault(r => r.Checked);
                var org = (OrganizationViewModel)cbOrganizationId.SelectedValue;
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
                    IsActive = true,
                    Title = model.Title
                };
                actionLog.Message = string.Format(AppActions.Employee_Update, newEmp.Code);
                bool result = btnUpdate_Validate(newEmp);
                if (result)
                {
                    employeeService.UpdateEmployee(newEmp);
                    ValidatorHelper.ClearEPValidation(epDic);
                    Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, AppActions.Employee_Update);
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
            }
            finally
            {
                _logger.LogBusiness(actionLog);
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

        private void cbOrganizationId_TextUpdate(object sender, EventArgs e)
        {
            string filter_param = cbOrganizationId.Text.ToLower();

            List<OrganizationViewModel> filteredItems = orgList.FindAll(x => x.Name.ToLower().Contains(filter_param));
            // another variant for filtering using StartsWith:
            // List<string> filteredItems = arrProjectList.FindAll(x => x.StartsWith(filter_param));

            cbOrganizationId.DataSource = filteredItems;

            if (String.IsNullOrWhiteSpace(filter_param))
            {
                cbOrganizationId.DataSource = orgList;
            }
            cbOrganizationId.DroppedDown = true;

            // this will ensure that the drop down is as long as the list
            cbOrganizationId.IntegralHeight = true;

            // remove automatically selected first item
            cbOrganizationId.SelectedIndex = -1;

            cbOrganizationId.Text = filter_param;

            // set the position of the cursor
            cbOrganizationId.SelectionStart = filter_param.Length;
            cbOrganizationId.SelectionLength = 0;
            Cursor.Current = Cursors.Default;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string code = txtCode.Text.Trim();
                
                employeeService = new EmployeeService();
                var existedEmployee = employeeService.GetEmployeeByCode(code);
                if (currCode.Equals(code) == false && existedEmployee != null)
                {
                    epCode.SetError(txtCode, "Mã nhân viên đã tồn tại");
                }
                else
                {
                    epCode.SetError(txtCode, string.Empty);
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
