using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Helpers;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Forms.DeductionForms
{
    public partial class PTDepartmentDeduction : CommonForm
    {
        private int year;
        private int month;
        private int articleType;
        private IDeductionService deductionService;
        private IDeductionTypeService deductionTypeService;
        private BindingSource bs;
        private List<DeductionTypeViewModel> deductionTypes;
        private ComboBox comboBox;
        private readonly IAppLogger _logger;

        public PTDepartmentDeduction(int? month, int? year, int articleType)
        {
            _logger = new AppLogger();
            InitializeComponent();
            InitTabIndex();
            deductionService = new DeductionService();
            deductionTypeService = new DeductionTypeService();

            this.year = (year.HasValue) ? DateTime.Now.Year : (int)year;
            this.month = (month.HasValue) ? DateTime.Now.Month : (int)month;
            this.articleType = articleType;
            
            LoadDeductions();
        }

        private void InitTabIndex()
        {
            dtpMonth.TabIndex = 0;
            dtp.TabIndex = 1;
            adgvDeduction.TabIndex = 2;
        }

        public void LoadDeductions()
        {
            try
            {
                deductionService = new DeductionService();
                var dataSource = deductionService.GetAllPeopleInPhongPT(this.month, this.year, this.articleType);

                SortableBindingList<EmployeeDeductionViewModel> sbl = new SortableBindingList<EmployeeDeductionViewModel>(dataSource);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvDeduction.DataSource = bs;

                adgvDeduction.Columns["Id"].Visible = false;
                adgvDeduction.Columns["EmployeeId"].Visible = false;
                adgvDeduction.Columns["DeductionType"].Visible = false;
                adgvDeduction.Columns["Year"].Visible = false;
                adgvDeduction.Columns["Month"].Visible = false;

                adgvDeduction.Columns["EmployeeName"].HeaderText = "Tên Nhân Viên";
                adgvDeduction.Columns["Deduction"].HeaderText = "Giảm trừ";
                adgvDeduction.Columns["DeductionType"].HeaderText = "Loại";

                deductionTypes = deductionTypeService.GetDeductionTypes();

                if (adgvDeduction.Columns["cbDeductionCol"] != null)
                {
                    adgvDeduction.Columns.Remove("cbDeductionCol");
                }

                DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
                cmbCol.DataSource = deductionTypes;
                cmbCol.HeaderText = "Loại";
                cmbCol.DisplayMember = "Name";
                cmbCol.ValueMember = "Id";
                cmbCol.Name = "cbDeductionCol";
                adgvDeduction.Columns.Add(cmbCol);

                if (deductionTypes != null && deductionTypes.Count > 0)
                {
                    for (int i = 0; i < dataSource.Count; i++)
                    {
                        adgvDeduction.Rows[i].Cells["cbDeductionCol"].Value = ((DeductionTypeViewModel)cmbCol.Items[dataSource[i].DeductionType - 1]).Id;
                    }
                }

                adgvDeduction.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(adgvDeduction_EditingControlShowing);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void adgvDeduction_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            comboBox = e.Control as ComboBox;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.SelectionChangeCommitted -= new EventHandler(cbDeductionSelectedIndexChange);
                comboBox.SelectionChangeCommitted += cbDeductionSelectedIndexChange;
            }
        }

        private void cbDeductionSelectedIndexChange(object sender, EventArgs e)
        {
            comboBox = sender as ComboBox;
            var deductionType = ((DeductionTypeViewModel)comboBox.SelectedItem).Id;
            double value = deductionTypes.Where(d => d.Id == ((DeductionTypeViewModel)comboBox.SelectedItem).Id).FirstOrDefault().Value;
            adgvDeduction.Rows[adgvDeduction.SelectedRows[0].Index].Cells["Deduction"].Value = value;
            adgvDeduction.Rows[adgvDeduction.SelectedRows[0].Index].Cells["DeductionType"].Value = deductionType;           
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {          
            this.month = dtpMonth.Value.Month;
            this.year = dtp.Value.Year;
            LoadDeductions();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE,
                Message = string.Format(AppActions.SaveDeduction_PV, this.month, this.year)
            };

            try
            {
                deductionService = new DeductionService();
                BindingSource bs = (BindingSource)adgvDeduction.DataSource;
                var list = bs.DataSource as IList<EmployeeDeductionViewModel>;
                deductionService.UpdateDeductions(list, this.month, this.year, this.articleType);
                DialogHelper.OpenActionResultDialog("Lưu Thành Công", "Cập nhật giảm trừ PV");
                LoadDeductions();
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, AppActions.SaveDeduction_PV);
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                MessageBox.Show("Có lỗi xảy ra! Vui lòng liên hệ kỹ thuật!", "Cập nhật giảm trừ PV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _logger.LogBusiness(actionLog);
                deductionService = null;
            }
        }

        private void adgvDeduction_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);                
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            this.month = dtpMonth.Value.Month;
            this.year = dtp.Value.Year;
            LoadDeductions();
        }

        private void adgvDeduction_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
