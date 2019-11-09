﻿using ATV_Allowance.Common;
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

namespace ATV_Allowance.Forms.Report
{
    public partial class ReportKhoiHauKyForm : Form
    {
        private BindingSource bs;

        private IReportService reportService;
        private SaveFileDialog saveFileDialog;
        public ReportKhoiHauKyForm()
        {
            InitializeComponent();
            reportService = new ReportService();

            InitValue();
            LoadReport();
        }

        public void InitValue()
        {
            var positions = new List<PositionViewModel>();
            positions.Add(new PositionViewModel
            {
                Id = EmployeeRole.PV,
                Code = "PV"
            });
            positions.Add(new PositionViewModel
            {
                Id = EmployeeRole.CTV,
                Code = "CTV"
            });

            cbRole.DataSource = positions;
            cbRole.DisplayMember = "Code";
            cbRole.ValueMember = "Id";
            cbRole.SelectedValue = EmployeeRole.PV;

            dtpMonth.Value = DateTime.Now;
            dtpYear.Value = DateTime.Now;

            dtpStartdate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, 1);
            dtpEnddate.Value = new DateTime(dtpYear.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpYear.Value.Year, dtpMonth.Value.Month));

            InitSaveFile();
        }

        public void InitSaveFile()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Lưu báo cáo";
        }

        private void LoadReport()
        {

            if (cbRole.SelectedValue.GetType() != typeof(int))
            {
                return;
            }

            try
            {

                reportService = new ReportService();
                List<EmployeePointViewModel> list = reportService.GetReportBroadcast(dtpStartdate.Value, dtpEnddate.Value, (int)cbRole.SelectedValue, (int)edtPrice.Value, ArticleType.KHOIHK_TTNM);
                SortableBindingList<EmployeePointViewModel> sbl = new SortableBindingList<EmployeePointViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvReportBroadcast.DataSource = bs;
                adgvReportBroadcast.Columns["EmployeeName"].HeaderText = ADGVReportHeader.Name;
                adgvReportBroadcast.Columns["Organization"].HeaderText = ADGVReportHeader.Organization;
                adgvReportBroadcast.Columns["Sum"].HeaderText = ADGVReportHeader.TongCong;
                adgvReportBroadcast.Columns["IncreasePercent"].HeaderText = ADGVReportHeader.TangGiam;
                adgvReportBroadcast.Columns["IncreasePercent"].DefaultCellStyle.Format = "F1";
                adgvReportBroadcast.Columns["TotalCost"].HeaderText = ADGVReportHeader.TotalCost;
                adgvReportBroadcast.Columns["TotalCost"].DefaultCellStyle.Format = "N0";
                adgvReportBroadcast.Columns["SoDCT"].HeaderText = ADGVReportHeader.SoDCT;
                adgvReportBroadcast.Columns["DiemDCT"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoKTD"].HeaderText = ADGVReportHeader.SoKTD;
                adgvReportBroadcast.Columns["DiemKTD"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoTCT"].HeaderText = ADGVReportHeader.SoTCT;
                adgvReportBroadcast.Columns["DiemTCT"].HeaderText = ADGVReportHeader.Diem;
                adgvReportBroadcast.Columns["SoKT_TH"].HeaderText = ADGVReportHeader.SoKT_TH;
                adgvReportBroadcast.Columns["DiemKT_TH"].HeaderText = ADGVReportHeader.Diem;


                adgvReportBroadcast.Columns["EmployeeId"].Visible = false;
                adgvReportBroadcast.Columns["Descrease"].Visible = false;
                adgvReportBroadcast.Columns["TotalPoint"].Visible = false;

                adgvReportBroadcast.Columns["SoBai"].Visible = false;
                adgvReportBroadcast.Columns["DiemBai"].Visible = false;
                adgvReportBroadcast.Columns["SoCd"].Visible = false;
                adgvReportBroadcast.Columns["DiemCd"].Visible = false;
                adgvReportBroadcast.Columns["SoPv"].Visible = false;
                adgvReportBroadcast.Columns["DiemPv"].Visible = false;
                adgvReportBroadcast.Columns["SoSD"].Visible = false;
                adgvReportBroadcast.Columns["DiemSD"].Visible = false;

                adgvReportBroadcast.Columns["SoTTh_Gnh"].Visible = false;
                adgvReportBroadcast.Columns["DiemTTh_Gnh"].Visible = false;
                adgvReportBroadcast.Columns["SoCde"].Visible = false;
                adgvReportBroadcast.Columns["DiemCde"].Visible = false;
                adgvReportBroadcast.Columns["SoBs_DCT"].Visible = false;
                adgvReportBroadcast.Columns["DiemBs_DCT"].Visible = false;
                adgvReportBroadcast.Columns["SoBt_Dd"].Visible = false;
                adgvReportBroadcast.Columns["DiemBt_Dd"].Visible = false;

                adgvReportBroadcast.Columns["SoTin"].Visible = false;
                adgvReportBroadcast.Columns["DiemTin"].Visible = false;
                adgvReportBroadcast.Columns["SoPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemPsu"].Visible = false;
                adgvReportBroadcast.Columns["SoQtin"].Visible = false;
                adgvReportBroadcast.Columns["DiemQtin"].Visible = false;
                adgvReportBroadcast.Columns["SoQPsu"].Visible = false;
                adgvReportBroadcast.Columns["DiemQPsu"].Visible = false;
                adgvReportBroadcast.Columns["SoTLT"].Visible = false;
                adgvReportBroadcast.Columns["DiemTLT"].Visible = false;
                adgvReportBroadcast.Columns["SoThop"].Visible = false;
                adgvReportBroadcast.Columns["DiemThop"].Visible = false;

                adgvReportBroadcast.Columns["SoBs_TTN"].Visible = false;
                adgvReportBroadcast.Columns["DiemBs_TTN"].Visible = false;
                adgvReportBroadcast.Columns["SoBs_Sapo"].Visible = false;
                adgvReportBroadcast.Columns["DiemBs_Sapo"].Visible = false;
                adgvReportBroadcast.Columns["SoKThinh"].Visible = false;
                adgvReportBroadcast.Columns["DiemKThinh"].Visible = false;
                adgvReportBroadcast.Columns["SoTFile"].Visible = false;
                adgvReportBroadcast.Columns["DiemTFile"].Visible = false;
                adgvReportBroadcast.Columns["SoBt_Duyet"].Visible = false;
                adgvReportBroadcast.Columns["DiemBt_Duyet"].Visible = false;

                txtPoint.Text = list.Sum(e => e.TotalPoint).ToString();
                txtCost.Text = list.Sum(e => e.TotalCost).ToString("N0") + " vnđ";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reportService = null;
            }
        }
    }
}