using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
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

namespace ATV_Allowance.Forms.DeductionForms
{
    public partial class PTVDeductionForm : CommonForm
    {
        private int year;
        private int month;
        private int articleType;
        private IDeductionService deductionService;
        private IDeductionTypeService deductionTypeService;
        private BindingSource bs;
        private List<DeductionTypeViewModel> deductionTypes;
        private ComboBox comboBox;

        public PTVDeductionForm(int? month, int? year, int articleType)
        {
            InitializeComponent();

            deductionService = new DeductionService();
            deductionTypeService = new DeductionTypeService();

            this.year = (year.HasValue) ? DateTime.Now.Year : (int)year;
            this.month = (month.HasValue) ? DateTime.Now.Month : (int)month;
            this.articleType = articleType;

            LoadDeductions();
        }

        public void LoadDeductions()
        {
            var dataSource = deductionService.GetDeductionPV(this.month, this.year, this.articleType);

            SortableBindingList<EmployeeDeductionViewModel> sbl = new SortableBindingList<EmployeeDeductionViewModel>(dataSource);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvDeduction.DataSource = bs;

            adgvDeduction.Columns["EmployeeId"].Visible = false;
            adgvDeduction.Columns["DeductionType"].Visible = false;

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
                comboBox.SelectedIndex = 0;

            }
        }

        private void cbDeductionSelectedIndexChange(object sender, EventArgs e)
        {
            comboBox = sender as ComboBox;
            double value = deductionTypes.Where(d => d.Id == ((DeductionTypeViewModel)comboBox.SelectedItem).Id).FirstOrDefault().Value;

            adgvDeduction.Rows[adgvDeduction.SelectedRows[0].Index].Cells["Deduction"].Value = value;
            var model = (EmployeeDeductionViewModel)adgvDeduction.CurrentRow.DataBoundItem; ;
            //deductionService.UpdateDeduction(model.EmployeeId,
            //                                ((DeductionTypeViewModel)comboBox.SelectedItem).Id,
            //                                dtpMonth.Value.Month,
            //                                dtp.Value.Year,
            //                                ((PositionViewModel)cbEmpRole.SelectedItem).Id,
            //                                ((ArticleTypeViewModel)cbArticleType.SelectedItem).Id);
        }

    }
}
