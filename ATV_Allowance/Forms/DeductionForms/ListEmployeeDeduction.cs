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
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.DeductionForms
{
    public partial class ListEmployeeDeduction : Form
    {
        private IDeductionService deductionService;
        private IDeductionTypeService deductionTypeService;
        private BindingSource bs;

        private ComboBox comboBox;
        private List<DeductionTypeViewModel> deductionTypes;

        public ListEmployeeDeduction()
        {
            InitializeComponent();
            deductionService = new DeductionService();
            deductionTypeService = new DeductionTypeService();
            InitComboboxView();
            LoadDeduction();
        }

        private void InitComboboxView()
        {
            cbArticleType.SelectedIndex = 0;
            cbEmpRole.SelectedIndex = 0;
        }

        public void LoadDeduction(int? month = null, int? year = null, int? employeeRole = null, int? articleType = null)
        {
            
            if (month == null)
            {
                month = DateTime.Now.Month;
            }
            if (year == null)
            {
                year = DateTime.Now.Year;
            }
            if (employeeRole == null)
            {
                employeeRole = EmployeeRole.PV;
            }
            if (articleType == null)
            {
                articleType = ArticleType.THOI_SU;
            }

            var dataSource = deductionService.GetDeductions(month.Value, year.Value, employeeRole.Value, articleType.Value);

            SortableBindingList<EmployeeDeductionViewModel> sbl = new SortableBindingList<EmployeeDeductionViewModel>(dataSource);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvDeduction.DataSource = bs;

            adgvDeduction.Columns["EmployeeId"].Visible = false;
            adgvDeduction.Columns["DeductionType"].Visible = false;

            deductionTypes = deductionTypeService.GetDeductionTypes();

            if (adgvDeduction.Columns["cbDeductionCol"] != null)
            {
                adgvDeduction.Columns.Remove("cbDeductionCol");
            }

            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            cmbCol.DataSource = deductionTypes;
            cmbCol.HeaderText = "Giam tru"; //fix here
            cmbCol.DisplayMember = "Name";
            cmbCol.ValueMember = "Id";
            cmbCol.ValueType = typeof(int);
            cmbCol.Name = "cbDeductionCol";
            adgvDeduction.Columns.Add(cmbCol);

            adgvDeduction.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(adgvDeduction_EditingControlShowing);

        }

        private void adgvDeduction_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            comboBox = e.Control as ComboBox;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.SelectedIndexChanged += new EventHandler(cbDeductionSelectedIndexChange);
                comboBox.SelectedIndex = 0;

            }
        }

        private void cbDeductionSelectedIndexChange(object sender, EventArgs e)
        {
            comboBox = sender as ComboBox;
            double value = deductionTypes.Where(d => d.Id == ((DeductionTypeViewModel)comboBox.SelectedItem).Id).FirstOrDefault().Value;

            adgvDeduction.Rows[adgvDeduction.SelectedRows[0].Index].Cells["Deduction"].Value = value;
            var model = (EmployeeDeductionViewModel)adgvDeduction.CurrentRow.DataBoundItem; ;
            deductionService.UpdateDeduction(model.EmployeeId,
                                            ((DeductionTypeViewModel)comboBox.SelectedItem).Id,
                                            dtpMonth.Value.Month,
                                            dtp.Value.Year,
                                            EmployeeRole.PV,
                                            ArticleType.THOI_SU);
        }

        private void cbArticleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeduction(dtpMonth.Value.Month, dtp.Value.Year, cbEmpRole.SelectedIndex + 1, cbArticleType.SelectedIndex + 1);
        }

        private void cbEmpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeduction(dtpMonth.Value.Month, dtp.Value.Year, cbEmpRole.SelectedIndex + 1, cbArticleType.SelectedIndex + 1);
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadDeduction(dtpMonth.Value.Month, dtp.Value.Year, cbEmpRole.SelectedIndex + 1, cbArticleType.SelectedIndex + 1);
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            LoadDeduction(dtpMonth.Value.Month, dtp.Value.Year, cbEmpRole.SelectedIndex + 1, cbArticleType.SelectedIndex + 1);
        }
    }
}
