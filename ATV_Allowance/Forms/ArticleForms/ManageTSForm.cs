﻿using ATV_Allowance.Common;
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
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.ArticleForms
{
    public partial class ManageTSForm : CommonForm
    {
        private int articleType = ArticleType.THOI_SU;
        private DateTime fromDate = DateTime.Now;
        private DateTime toDate = DateTime.Now;
        private int empId = -1;
        private IArticleService articleService;
        private IEmployeeService employeeService;
        private BindingSource bs = null;        

        public ManageTSForm()
        {
            InitializeComponent();
            LoadDGV();
        }
        private void LoadDGV()
        {
            try
            {
                articleService = new ArticleService();
                bs = new BindingSource();           
                var list = articleService.GetArticle(articleType, fromDate, toDate, empId);                                 
                SortableBindingList<ArticleViewModel> sbl = new SortableBindingList<ArticleViewModel>(list);
                bs.DataSource = sbl;
                adgvList.DataSource = bs;
                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["TypeId"].Visible = false;
                adgvList.Columns["Title"].Visible = true;
                adgvList.Columns["Date"].Visible = true;

                adgvList.Columns["Title"].HeaderText = ADGVArticleText.Title;
                adgvList.Columns["Title"].Width = ControlsAttribute.GV_WIDTH_LARGE_XX;                
                adgvList.Columns["Date"].HeaderText = ADGVArticleText.Date;                                
                adgvList.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                articleService = null; 
            }
        }

        private void ManageTSForm_Load(object sender, EventArgs e)
        {
            try
            {
                employeeService = new EmployeeService();
                List<EmployeeViewModel> list = new List<EmployeeViewModel>
                {
                    new EmployeeViewModel
                    {
                        Id = -1,
                        Name = "<chọn nhân viên />" // empty employee
                    }
                };
                list.AddRange(employeeService.GetAllActive(true));
                cbEmployee.DisplayMember = "Name";
                cbEmployee.DataSource = list;
                cbEmployee.AutoCompleteMode = AutoCompleteMode.Suggest;
                cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                employeeService = null; 
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            fromDate = dtpStartDate.Value;
            LoadDGV();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            toDate = dtpStartDate.Value;
            LoadDGV();
        }

        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            var emp = (EmployeeViewModel)cbEmployee.SelectedValue;
            empId = emp.Id;
            LoadDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTSForm form = new AddTSForm(articleType);
            form.FormClosed += new FormClosedEventHandler(AddTSForm_Closed);
            form.ShowDialog();
        }
        private void AddTSForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
        }
    }
}
