using ATV_Allowance.Helpers;
using ATV_Allowance.ViewModel;
using DataService.Repository;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{
    public interface IReportService
    {
        List<EmployeePointViewModel> GetReportBroadcast(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        byte[] GetReportTS(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        byte[] GetReportPT(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        byte[] GetReportPTTT(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        byte[] GetReportBSTTNM(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        byte[] GetReportTTNM(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        byte[] GetReportKHK(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        byte[] GetReportTS_KHK(DateTime startDate, DateTime endDate, int price);

        void InteropPreviewReportTS(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        void InteropPreviewReportPT(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        void InteropPreviewReportPTTT(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        void InteropPreviewReportBSTTNM(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        void InteropPreviewReportTTNM(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        //void InteropPreviewReportKHK(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        void InteropPreviewReportTS_KHK(DateTime startDate, DateTime endDate, int role, int price, int reportType);

    }
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ICriteriaRepository _criteriaRepository;
        private readonly IDeductionService _deductionService;
        private readonly ICriteriaService _criteriaService;

        public ReportService()
        {
            _reportRepository = new ReportRepository();
            _criteriaRepository = new CriteriaRepository();
            _deductionService = new DeductionService();
            _criteriaService = new CriteriaService();
        }

        public List<EmployeePointViewModel> GetReportBroadcast(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            var list = _reportRepository.GetReport(startDate, endDate, reportType, role);
            List<EmployeePointViewModel> result = new List<EmployeePointViewModel>();
            int currentId = 0;
            EmployeePointViewModel employeePointVM = null;
            foreach (var item in list)
            {
                if (currentId != item.EmployeeId)
                {
                    employeePointVM = new EmployeePointViewModel();
                    employeePointVM.EmployeeId = item.EmployeeId;
                    employeePointVM.Organization = item.OrganizationName;
                    employeePointVM.EmployeeName = item.EmployeeName;
                    result.Add(employeePointVM);

                    currentId = item.EmployeeId;
                }
                if (item.PointType == PointType_ThoiSu.Tin)
                {
                    employeePointVM.SoTin = item.Amount;
                    employeePointVM.DiemTin = item.TotalPoint;
                }
                else if (item.PointType == PointType_ThoiSu.PS)
                {
                    employeePointVM.SoPsu = item.Amount;
                    employeePointVM.DiemPsu = item.TotalPoint;
                }
                else if (item.PointType == PointType_ThoiSu.QTin)
                {
                    employeePointVM.SoQtin = item.Amount;
                    employeePointVM.DiemQtin = item.TotalPoint;
                }
                else if (item.PointType == PointType_ThoiSu.QPs)
                {
                    employeePointVM.SoQPsu = item.Amount;
                    employeePointVM.DiemQPsu = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanh.Bai)
                {
                    employeePointVM.SoBai = item.Amount;
                    employeePointVM.DiemBai = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanh.Cd_Cm)
                {
                    employeePointVM.SoCd = item.Amount;
                    employeePointVM.DiemCd = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanh.Pv_Pb)
                {
                    employeePointVM.SoPv = item.Amount;
                    employeePointVM.DiemPv = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanh.Tlt)
                {
                    employeePointVM.SoTLT = item.Amount;
                    employeePointVM.DiemTLT = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanh.Sd)
                {
                    employeePointVM.SoSD = item.Amount;
                    employeePointVM.DiemSD = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanhTT.TTh_Gnh)
                {
                    employeePointVM.SoTTh_Gnh = item.Amount;
                    employeePointVM.DiemTTh_Gnh = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanhTT.CDe)
                {
                    employeePointVM.SoCde = item.Amount;
                    employeePointVM.DiemCde = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanhTT.Bs_DCT)
                {
                    employeePointVM.SoBs_DCT = item.Amount;
                    employeePointVM.DiemBs_DCT = item.TotalPoint;
                }
                else if (item.PointType == PointType_PhatThanhTT.Bt_Dd)
                {
                    employeePointVM.SoBt_Dd = item.Amount;
                    employeePointVM.DiemBt_Dd = item.TotalPoint;
                }
                else if (item.PointType == PointType_TTNM.Tl_tin)
                {
                    employeePointVM.SoTLT = item.Amount;
                    employeePointVM.DiemTLT = item.TotalPoint;
                }
                else if (item.PointType == PointType_TTNM.Thop)
                {
                    employeePointVM.SoThop = item.Amount;
                    employeePointVM.DiemThop = item.TotalPoint;
                }
                else if (item.PointType == PointType_BIENSOAN_TTNM.Bs_Sapo)
                {
                    employeePointVM.SoBs_Sapo = item.Amount;
                    employeePointVM.DiemBs_Sapo = item.TotalPoint;
                }
                else if (item.PointType == PointType_BIENSOAN_TTNM.Bs_TTN)
                {
                    employeePointVM.SoBs_TTN = item.Amount;
                    employeePointVM.DiemBs_TTN = item.TotalPoint;
                }
                else if (item.PointType == PointType_BIENSOAN_TTNM.Bt_Duyet)
                {
                    employeePointVM.SoBt_Duyet = item.Amount;
                    employeePointVM.DiemBt_Duyet = item.TotalPoint;
                }
                else if (item.PointType == PointType_BIENSOAN_TTNM.KThinh)
                {
                    employeePointVM.SoKThinh = item.Amount;
                    employeePointVM.DiemKThinh = item.TotalPoint;
                }
                else if (item.PointType == PointType_BIENSOAN_TTNM.TFile)
                {
                    employeePointVM.SoTFile = item.Amount;
                    employeePointVM.DiemTFile = item.TotalPoint;
                }
                else if (item.PointType == PointType_HAUKY_TTNM.DCT)
                {
                    employeePointVM.SoDCT = item.Amount;
                    employeePointVM.DiemDCT = item.TotalPoint;
                }
                else if (item.PointType == PointType_HAUKY_TTNM.KTD)
                {
                    employeePointVM.SoKTD = item.Amount;
                    employeePointVM.DiemKTD = item.TotalPoint;
                }
                else if (item.PointType == PointType_HAUKY_TTNM.KT_TH)
                {
                    employeePointVM.SoKT_TH = item.Amount;
                    employeePointVM.DiemKT_TH = item.TotalPoint;
                }
                else if (item.PointType == PointType_HAUKY_TTNM.TCT)
                {
                    employeePointVM.SoTCT = item.Amount;
                    employeePointVM.DiemTCT = item.TotalPoint;
                }


            }

            CalculateCost(result, price, reportType, role, startDate);

            return result;
        }

        public byte[] GetReportTS(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);
            ExcelHelper helper = new ExcelHelper();
            var package = helper.GetPackage(Tempate.TS);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();


            int currentRow = 5;

            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, TS_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            for (int i = 0; i < list.Count; i++)
            {
                worksheet.InsertRow(currentRow, 1);
                worksheet.Cells[currentRow, TS_COL.STT].Value = i + 1;
                worksheet.Cells[currentRow, TS_COL.HO_TEN].Value = list[i].EmployeeName;
                worksheet.Cells[currentRow, TS_COL.TIN].Value = list[i].SoTin;
                worksheet.Cells[currentRow, TS_COL.TIN_DIEM].Value = list[i].DiemTin;
                worksheet.Cells[currentRow, TS_COL.PHSU].Value = list[i].SoPsu;
                worksheet.Cells[currentRow, TS_COL.PHSU_DIEM].Value = list[i].DiemPsu;
                worksheet.Cells[currentRow, TS_COL.QTIN_DIEM].Value = list[i].DiemQtin;
                worksheet.Cells[currentRow, TS_COL.QPSU_DIEM].Value = list[i].DiemQPsu;

                worksheet.Cells[currentRow, TS_COL.CONG].Value = list[i].SumPoint;
                worksheet.Cells[currentRow, TS_COL.TRUCHITIEU].Value = list[i].Descrease;
                worksheet.Cells[currentRow, TS_COL.TANGGIAM].Value = list[i].IncreasePercent;
                worksheet.Cells[currentRow, TS_COL.TONGCONG].Value = list[i].TotalPoint;
                worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = list[i].TotalCost;

                currentRow += 1;
            }

            //title row
            worksheet.Cells[2, 12].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, 11].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, 14].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            worksheet.Cells[currentRow, TS_COL.TIN].Value = list.Sum(e => e.SoTin);
            worksheet.Cells[currentRow, TS_COL.TIN_DIEM].Value = list.Sum(e => e.DiemTin);
            worksheet.Cells[currentRow, TS_COL.PHSU].Value = list.Sum(e => e.SoPsu);
            worksheet.Cells[currentRow, TS_COL.PHSU_DIEM].Value = list.Sum(e => e.DiemPsu);
            worksheet.Cells[currentRow, TS_COL.QTIN_DIEM].Value = list.Sum(e => e.DiemQtin);
            worksheet.Cells[currentRow, TS_COL.QPSU_DIEM].Value = list.Sum(e => e.DiemQPsu);
            worksheet.Cells[currentRow, TS_COL.CONG].Value = list.Sum(e => e.SumPoint);
            worksheet.Cells[currentRow, TS_COL.TRUCHITIEU].Value = list.Sum(e => e.Descrease);
            worksheet.Cells[currentRow, TS_COL.TANGGIAM].Value = list.Sum(e => e.IncreasePercent);
            worksheet.Cells[currentRow, TS_COL.TONGCONG].Value = list.Sum(e => e.TotalPoint);
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, 14].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Column(TS_COL.TRUCHITIEU).Hidden = true;
            }

            //set oreintation
            worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

            if (list.Count > 0)
            {
                //border
                worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
            else
            {

            }

            return package.GetAsByteArray();
        }

        public byte[] GetReportPT(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);
            ExcelHelper helper = new ExcelHelper();
            var package = helper.GetPackage(Tempate.PT);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, PT_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            for (int i = 0; i < list.Count; i++)
            {
                worksheet.InsertRow(currentRow, 1);
                worksheet.Cells[currentRow, PT_COL.STT].Value = i + 1;
                worksheet.Cells[currentRow, PT_COL.HO_TEN].Value = list[i].EmployeeName;
                worksheet.Cells[currentRow, PT_COL.DON_VI].Value = list[i].Organization;
                worksheet.Cells[currentRow, PT_COL.SL_TIN].Value = list[i].SoTin;
                worksheet.Cells[currentRow, PT_COL.D_TIN].Value = list[i].DiemTin;
                worksheet.Cells[currentRow, PT_COL.SL_BAI].Value = list[i].SoBai;
                worksheet.Cells[currentRow, PT_COL.D_BAI].Value = list[i].DiemBai;
                worksheet.Cells[currentRow, PT_COL.SL_CD].Value = list[i].SoCd;
                worksheet.Cells[currentRow, PT_COL.D_CD].Value = list[i].DiemCd;
                worksheet.Cells[currentRow, PT_COL.SL_PV].Value = list[i].SoPv;
                worksheet.Cells[currentRow, PT_COL.D_PV].Value = list[i].DiemPv;
                worksheet.Cells[currentRow, PT_COL.SL_TLT].Value = list[i].SoTLT;
                worksheet.Cells[currentRow, PT_COL.D_TLT].Value = list[i].DiemTLT;
                worksheet.Cells[currentRow, PT_COL.SL_SD].Value = list[i].SoSD;
                worksheet.Cells[currentRow, PT_COL.D_SD].Value = list[i].DiemSD;

                worksheet.Cells[currentRow, PT_COL.TRUCHITIEU].Value = list[i].Descrease;
                worksheet.Cells[currentRow, PT_COL.TONGDIEM].Value = list[i].SumPoint;
                worksheet.Cells[currentRow, PT_COL.TANGGIAM].Value = list[i].IncreasePercent;
                worksheet.Cells[currentRow, PT_COL.THANHTIEN].Value = list[i].TotalCost;

                currentRow += 1;
            }

            //title row
            worksheet.Cells[2, PT_COL.SL_SD].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, PT_COL.SL_TLT].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, PT_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, PT_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, PT_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Column(PT_COL.TRUCHITIEU).Hidden = true;
            }

            //set oreintation
            worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

            if (list.Count > 0)
            {
                //border
                worksheet.Cells[5, 1, currentRow - 1, PT_COL.THANHTIEN + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PT_COL.THANHTIEN + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PT_COL.THANHTIEN + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PT_COL.THANHTIEN + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
            else
            {

            }

            return package.GetAsByteArray();
        }

        public byte[] GetReportPTTT(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);
            ExcelHelper helper = new ExcelHelper();
            var package = helper.GetPackage(Tempate.PTTT);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, PTTT_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            for (int i = 0; i < list.Count; i++)
            {
                worksheet.InsertRow(currentRow, 1);
                worksheet.Cells[currentRow, PTTT_COL.STT].Value = i + 1;
                worksheet.Cells[currentRow, PTTT_COL.HO_TEN].Value = list[i].EmployeeName;
                worksheet.Cells[currentRow, PTTT_COL.DON_VI].Value = list[i].Organization;
                worksheet.Cells[currentRow, PTTT_COL.SL_TIN].Value = list[i].SoTin;
                worksheet.Cells[currentRow, PTTT_COL.D_TIN].Value = list[i].DiemTin;
                worksheet.Cells[currentRow, PTTT_COL.SL_TT].Value = list[i].SoTTh_Gnh;
                worksheet.Cells[currentRow, PTTT_COL.D_TT].Value = list[i].DiemTTh_Gnh;
                worksheet.Cells[currentRow, PTTT_COL.SL_CD].Value = list[i].SoCde;
                worksheet.Cells[currentRow, PTTT_COL.D_CD].Value = list[i].DiemCde;
                worksheet.Cells[currentRow, PTTT_COL.SL_PV].Value = list[i].SoPv;
                worksheet.Cells[currentRow, PTTT_COL.D_PV].Value = list[i].DiemPv;
                worksheet.Cells[currentRow, PTTT_COL.SL_BS].Value = list[i].SoBs_DCT;
                worksheet.Cells[currentRow, PTTT_COL.D_BS].Value = list[i].DiemBs_DCT;
                worksheet.Cells[currentRow, PTTT_COL.SL_BT].Value = list[i].SoBt_Dd;
                worksheet.Cells[currentRow, PTTT_COL.D_BT].Value = list[i].DiemBt_Dd;

                worksheet.Cells[currentRow, PTTT_COL.TRUCHITIEU].Value = list[i].Descrease;
                worksheet.Cells[currentRow, PTTT_COL.TONGDIEM].Value = list[i].SumPoint;
                worksheet.Cells[currentRow, PTTT_COL.TANGGIAM].Value = list[i].IncreasePercent;
                worksheet.Cells[currentRow, PTTT_COL.THANHTIEN].Value = list[i].TotalCost;

                currentRow += 1;
            }

            //title row
            worksheet.Cells[2, PTTT_COL.SL_BT].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, PTTT_COL.SL_BS].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, PTTT_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, PTTT_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, PTTT_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Column(PTTT_COL.TRUCHITIEU).Hidden = true;
            }

            //set oreintation
            worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

            if (list.Count > 0)
            {
                //border
                worksheet.Cells[5, 1, currentRow - 1, PTTT_COL.THANHTIEN + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PTTT_COL.THANHTIEN + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PTTT_COL.THANHTIEN + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PTTT_COL.THANHTIEN + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
            else
            {

            }

            return package.GetAsByteArray();
        }

        public byte[] GetReportTTNM(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);
            ExcelHelper helper = new ExcelHelper();
            var package = helper.GetPackage(Tempate.TTNM);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, TTNM_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            for (int i = 0; i < list.Count; i++)
            {
                worksheet.InsertRow(currentRow, 1);
                worksheet.Cells[currentRow, TTNM_COL.STT].Value = i + 1;
                worksheet.Cells[currentRow, TTNM_COL.HO_TEN].Value = list[i].EmployeeName;
                worksheet.Cells[currentRow, TTNM_COL.DON_VI].Value = list[i].Organization;
                worksheet.Cells[currentRow, TTNM_COL.SL_TIN].Value = list[i].SoTin;
                worksheet.Cells[currentRow, TTNM_COL.D_TIN].Value = list[i].DiemTin;
                worksheet.Cells[currentRow, TTNM_COL.SL_PS].Value = list[i].SoTTh_Gnh;
                worksheet.Cells[currentRow, TTNM_COL.D_PS].Value = list[i].DiemTTh_Gnh;
                worksheet.Cells[currentRow, TTNM_COL.SL_QTin].Value = list[i].SoCde;
                worksheet.Cells[currentRow, TTNM_COL.D_QTin].Value = list[i].DiemCde;
                worksheet.Cells[currentRow, TTNM_COL.SL_QPsu].Value = list[i].SoPv;
                worksheet.Cells[currentRow, TTNM_COL.D_QPsu].Value = list[i].DiemPv;
                worksheet.Cells[currentRow, TTNM_COL.SL_Tlt].Value = list[i].SoBs_DCT;
                worksheet.Cells[currentRow, TTNM_COL.D_Tlt].Value = list[i].DiemBs_DCT;
                worksheet.Cells[currentRow, TTNM_COL.SL_Thop].Value = list[i].SoBt_Dd;
                worksheet.Cells[currentRow, TTNM_COL.D_Thop].Value = list[i].DiemBt_Dd;

                worksheet.Cells[currentRow, TTNM_COL.TRUCHITIEU].Value = list[i].Descrease;
                worksheet.Cells[currentRow, TTNM_COL.TONGDIEM].Value = list[i].SumPoint;
                worksheet.Cells[currentRow, TTNM_COL.TANGGIAM].Value = list[i].IncreasePercent;
                worksheet.Cells[currentRow, TTNM_COL.THANHTIEN].Value = list[i].TotalCost;

                currentRow += 1;
            }

            //title row
            worksheet.Cells[2, TTNM_COL.SL_Thop].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, TTNM_COL.SL_Tlt].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, TTNM_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, TTNM_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, TTNM_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Column(TTNM_COL.TRUCHITIEU).Hidden = true;
            }

            //set oreintation
            worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

            if (list.Count > 0)
            {
                //border
                worksheet.Cells[5, 1, currentRow - 1, TTNM_COL.THANHTIEN + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, TTNM_COL.THANHTIEN + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, TTNM_COL.THANHTIEN + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, TTNM_COL.THANHTIEN + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
            else
            {

            }

            return package.GetAsByteArray();
        }

        public byte[] GetReportBSTTNM(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            var listBSTTNM = GetReportBroadcast(startDate, endDate, role, price, reportType);
            var listKHK = GetReportBroadcast(startDate, endDate, role, price, ArticleType.KHOIHK_TTNM);

            ExcelHelper helper = new ExcelHelper();
            var package = helper.GetPackage(Tempate.BSTTNM);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, BSTTNM_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            for (int i = 0; i < listBSTTNM.Count; i++)
            {
                worksheet.InsertRow(currentRow, 1);
                worksheet.Cells[currentRow, BSTTNM_COL.STT].Value = i + 1;
                worksheet.Cells[currentRow, BSTTNM_COL.HO_TEN].Value = listBSTTNM[i].EmployeeName;
                worksheet.Cells[currentRow, BSTTNM_COL.DON_VI].Value = listBSTTNM[i].Organization;
                worksheet.Cells[currentRow, BSTTNM_COL.SL_BS_TTN].Value = listBSTTNM[i].SoBs_TTN;
                worksheet.Cells[currentRow, BSTTNM_COL.D_BS_TTN].Value = listBSTTNM[i].DiemBs_TTN;
                worksheet.Cells[currentRow, BSTTNM_COL.SL_BtDuyet].Value = listBSTTNM[i].SoBt_Duyet;
                worksheet.Cells[currentRow, BSTTNM_COL.D_BtDuyet].Value = listBSTTNM[i].DiemBt_Duyet;
                worksheet.Cells[currentRow, BSTTNM_COL.SL_Kthinh].Value = listBSTTNM[i].SoKThinh;
                worksheet.Cells[currentRow, BSTTNM_COL.D_Kthinh].Value = listBSTTNM[i].DiemKThinh;
                worksheet.Cells[currentRow, BSTTNM_COL.SL_Sapo].Value = listBSTTNM[i].SoBs_Sapo;
                worksheet.Cells[currentRow, BSTTNM_COL.D_Sapo].Value = listBSTTNM[i].DiemBs_Sapo;
                worksheet.Cells[currentRow, BSTTNM_COL.SL_Tfile].Value = listBSTTNM[i].SoTFile;
                worksheet.Cells[currentRow, BSTTNM_COL.D_Tfile].Value = listBSTTNM[i].DiemTFile;

                worksheet.Cells[currentRow, BSTTNM_COL.TRUCHITIEU].Value = listBSTTNM[i].Descrease;
                worksheet.Cells[currentRow, BSTTNM_COL.TONGDIEM].Value = listBSTTNM[i].SumPoint;
                worksheet.Cells[currentRow, BSTTNM_COL.TANGGIAM].Value = listBSTTNM[i].IncreasePercent;
                worksheet.Cells[currentRow, BSTTNM_COL.THANHTIEN].Value = listBSTTNM[i].TotalCost;

                currentRow += 1;
            }

            //sum row
            var totalCostBSTTNM = listBSTTNM.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, BSTTNM_COL.THANHTIEN].Value = totalCostBSTTNM;

            if (listBSTTNM.Count > 0)
            {
                //border
                worksheet.Cells[5, 1, currentRow - 1, BSTTNM_COL.THANHTIEN + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, BSTTNM_COL.THANHTIEN + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, BSTTNM_COL.THANHTIEN + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, BSTTNM_COL.THANHTIEN + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
            else
            {

            }

            currentRow += 4;
            for (int i = 0; i < listKHK.Count; i++)
            {
                worksheet.InsertRow(currentRow, 1);
                worksheet.Cells[currentRow, KHK_COL.STT].Value = i + 1;
                worksheet.Cells[currentRow, KHK_COL.HO_TEN].Value = listKHK[i].EmployeeName;
                worksheet.Cells[currentRow, KHK_COL.DON_VI].Value = listKHK[i].Organization;
                worksheet.Cells[currentRow, KHK_COL.SL_DCT].Value = listKHK[i].SoDCT;
                worksheet.Cells[currentRow, KHK_COL.D_DCT].Value = listKHK[i].DiemDCT;
                worksheet.Cells[currentRow, KHK_COL.SL_KTD].Value = listKHK[i].SoKTD;
                worksheet.Cells[currentRow, KHK_COL.D_KTD].Value = listKHK[i].DiemKTD;
                worksheet.Cells[currentRow, KHK_COL.SL_KTTH].Value = listKHK[i].SoKT_TH;
                worksheet.Cells[currentRow, KHK_COL.D_KTTH].Value = listKHK[i].DiemKT_TH;
                worksheet.Cells[currentRow, KHK_COL.SL_TCT].Value = listKHK[i].SoTCT;
                worksheet.Cells[currentRow, KHK_COL.D_TCT].Value = listKHK[i].DiemTCT;

                worksheet.Cells[currentRow, KHK_COL.TRUCHITIEU].Value = listKHK[i].Descrease;
                worksheet.Cells[currentRow, KHK_COL.TONGDIEM].Value = listKHK[i].SumPoint;
                worksheet.Cells[currentRow, KHK_COL.TANGGIAM].Value = listKHK[i].IncreasePercent;
                worksheet.Cells[currentRow, KHK_COL.THANHTIEN].Value = listKHK[i].TotalCost;

                currentRow += 1;
            }

            if (listKHK.Count > 0)
            {
                //border
                worksheet.Cells[5, 1, currentRow - 1, KHK_COL.THANHTIEN + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, KHK_COL.THANHTIEN + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, KHK_COL.THANHTIEN + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, KHK_COL.THANHTIEN + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
            else
            {

            }

            //title row
            worksheet.Cells[2, BSTTNM_COL.TONGDIEM].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, BSTTNM_COL.D_BtDuyet].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, BSTTNM_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCostKHK = listKHK.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, KHK_COL.THANHTIEN].Value = totalCostKHK;

            //money string
            worksheet.Cells[currentRow + 1, BSTTNM_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCostBSTTNM)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Column(BSTTNM_COL.TRUCHITIEU).Hidden = true;
            }

            //set oreintation
            worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

            return package.GetAsByteArray();
        }

        public byte[] GetReportKHK(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);
            ExcelHelper helper = new ExcelHelper();
            var package = helper.GetPackage(Tempate.PT);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, TS_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            for (int i = 0; i < list.Count; i++)
            {
                worksheet.InsertRow(currentRow, 1);
                worksheet.Cells[currentRow, PTTT_COL.STT].Value = i + 1;
                worksheet.Cells[currentRow, PTTT_COL.HO_TEN].Value = list[i].EmployeeName;
                worksheet.Cells[currentRow, PTTT_COL.DON_VI].Value = list[i].Organization;
                worksheet.Cells[currentRow, PTTT_COL.SL_TIN].Value = list[i].SoTin;
                worksheet.Cells[currentRow, PTTT_COL.D_TIN].Value = list[i].DiemTin;
                worksheet.Cells[currentRow, PTTT_COL.SL_TT].Value = list[i].SoTTh_Gnh;
                worksheet.Cells[currentRow, PTTT_COL.D_TT].Value = list[i].DiemTTh_Gnh;
                worksheet.Cells[currentRow, PTTT_COL.SL_CD].Value = list[i].SoCde;
                worksheet.Cells[currentRow, PTTT_COL.D_CD].Value = list[i].DiemCde;
                worksheet.Cells[currentRow, PTTT_COL.SL_PV].Value = list[i].SoPv;
                worksheet.Cells[currentRow, PTTT_COL.D_PV].Value = list[i].DiemPv;
                worksheet.Cells[currentRow, PTTT_COL.SL_BS].Value = list[i].SoBs_DCT;
                worksheet.Cells[currentRow, PTTT_COL.D_BS].Value = list[i].DiemBs_DCT;
                worksheet.Cells[currentRow, PTTT_COL.SL_BT].Value = list[i].SoBt_Dd;
                worksheet.Cells[currentRow, PTTT_COL.D_BT].Value = list[i].DiemBt_Dd;

                var sum = list[i].SumPoint;
                var deduction = 0;
                var tongcong = (sum - deduction) * (1 + percent);
                worksheet.Cells[currentRow, PTTT_COL.TONGDIEM].Value = sum;
                worksheet.Cells[currentRow, PTTT_COL.TANGGIAM].Value = (sum - deduction) * percent;
                worksheet.Cells[currentRow, PTTT_COL.THANHTIEN].Value = tongcong * price;

                currentRow += 1;
            }

            //title row
            worksheet.Cells[2, PTTT_COL.SL_BT].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, PTTT_COL.SL_BS].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, PTTT_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, PTTT_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, PTTT_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //set oreintation
            worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

            if (list.Count > 0)
            {
                //border
                worksheet.Cells[5, 1, currentRow - 1, PTTT_COL.THANHTIEN + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PTTT_COL.THANHTIEN + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PTTT_COL.THANHTIEN + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, currentRow - 1, PTTT_COL.THANHTIEN + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
            else
            {

            }

            return package.GetAsByteArray();
        }

        private void CalculateCost(List<EmployeePointViewModel> list, int price, int reportType, int employeeRole, DateTime startDate)
        {
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, employeeRole == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV) / 100;
            for (int i = 0; i < list.Count; i++)
            {
                double sumPoint = 0;
                if (reportType == ArticleType.THOI_SU)
                {
                    sumPoint = list[i].DiemTin + list[i].DiemPsu + list[i].DiemQtin + list[i].DiemQPsu;
                }
                else if (reportType == ArticleType.PHAT_THANH)
                {
                    sumPoint = list[i].DiemTin + list[i].DiemBai + list[i].DiemCd + list[i].DiemPv + list[i].DiemTLT + list[i].DiemSD;
                }
                else if (reportType == ArticleType.PHAT_THANH_TT)
                {
                    sumPoint = list[i].DiemTin + list[i].DiemTTh_Gnh + list[i].DiemCde + list[i].DiemPv + list[i].DiemBs_DCT + list[i].DiemBt_Dd;
                }
                else if (reportType == ArticleType.PV_TTNM)
                {
                    sumPoint = list[i].DiemTin + list[i].DiemPsu + list[i].DiemQtin + list[i].DiemQPsu + list[i].DiemTLT + list[i].DiemThop;
                }
                else if (reportType == ArticleType.BIENSOAN_TTNM)
                {
                    sumPoint = list[i].DiemBs_TTN + list[i].DiemBs_Sapo + list[i].DiemKThinh + list[i].DiemTFile + list[i].DiemBt_Duyet;
                }
                else if (reportType == ArticleType.KHOIHK_TTNM)
                {
                    sumPoint = list[i].DiemDCT + list[i].DiemKTD + list[i].DiemTCT + list[i].DiemKT_TH;
                }

                var deduction = _deductionService.GetEmployeeDeduction(list[i].EmployeeId, reportType, startDate.Month, startDate.Year);
                list[i].SumPoint = sumPoint;
                list[i].Descrease = deduction;
                list[i].IncreasePercent = percent * (sumPoint - deduction);
                list[i].TotalPoint = list[i].SumPoint - list[i].Descrease + list[i].IncreasePercent;
                list[i].TotalCost = (int)(list[i].TotalPoint * price);
            }
        }

        private string NumberToTextVN(decimal total)
        {
            try
            {
                string rs = "";
                total = Math.Round(total, 0);
                string[] ch = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string[] rch = { "lẻ", "mốt", "", "", "", "lăm" };
                string[] u = { "", "mươi", "trăm", "nghìn", "", "", "triệu", "", "", "tỷ", "", "", "nghìn", "", "", "triệu" };
                string nstr = total.ToString();

                int[] n = new int[nstr.Length];
                int len = n.Length;
                for (int i = 0; i < len; i++)
                {
                    n[len - 1 - i] = Convert.ToInt32(nstr.Substring(i, 1));
                }

                for (int i = len - 1; i >= 0; i--)
                {
                    if (i % 3 == 2)// số 0 ở hàng trăm
                    {
                        if (n[i] == 0 && n[i - 1] == 0 && n[i - 2] == 0) continue;//nếu cả 3 số là 0 thì bỏ qua không đọc
                    }
                    else if (i % 3 == 1) // số ở hàng chục
                    {
                        if (n[i] == 0)
                        {
                            if (n[i - 1] == 0) { continue; }// nếu hàng chục và hàng đơn vị đều là 0 thì bỏ qua.
                            else
                            {
                                rs += " " + rch[n[i]]; continue;// hàng chục là 0 thì bỏ qua, đọc số hàng đơn vị
                            }
                        }
                        if (n[i] == 1)//nếu số hàng chục là 1 thì đọc là mười
                        {
                            rs += " mười"; continue;
                        }
                    }
                    else if (i != len - 1)// số ở hàng đơn vị (không phải là số đầu tiên)
                    {
                        if (n[i] == 0)// số hàng đơn vị là 0 thì chỉ đọc đơn vị
                        {
                            if (i + 2 <= len - 1 && n[i + 2] == 0 && n[i + 1] == 0) continue;
                            rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                            continue;
                        }
                        if (n[i] == 1)// nếu là 1 thì tùy vào số hàng chục mà đọc: 0,1: một / còn lại: mốt
                        {
                            rs += " " + ((n[i + 1] == 1 || n[i + 1] == 0) ? ch[n[i]] : rch[n[i]]);
                            rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                            continue;
                        }
                        if (n[i] == 5) // cách đọc số 5
                        {
                            if (n[i + 1] != 0) //nếu số hàng chục khác 0 thì đọc số 5 là lăm
                            {
                                rs += " " + rch[n[i]];// đọc số 
                                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                                continue;
                            }
                        }
                    }

                    rs += (rs == "" ? " " : ", ") + ch[n[i]];// đọc số
                    rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                }
                if (rs[rs.Length - 1] != ' ')
                    rs += " đồng";
                else
                    rs += "đồng";

                if (rs.Length > 2)
                {
                    string rs1 = rs.Substring(0, 2);
                    rs1 = rs1.ToUpper();
                    rs = rs.Substring(2);
                    rs = rs1 + rs;
                }
                return rs.Trim().Replace("lẻ,", "lẻ").Replace("mươi,", "mươi").Replace("trăm,", "trăm").Replace("mười,", "mười");
            }
            catch
            {
                return "";
            }

        }

        public byte[] GetReportTS_KHK(DateTime startDate, DateTime endDate, int price)
        {
            var listPV = GetReportBroadcast(startDate, endDate, EmployeeRole.PV, price, ArticleType.THOI_SU);
            var sumListPV = listPV.Sum(x => x.TotalCost);

            var listCTV = GetReportBroadcast(startDate, endDate, EmployeeRole.CTV, price, ArticleType.THOI_SU);
            var sumListCTV = listCTV.Sum(x => x.TotalCost);

            var listCriterias = _criteriaRepository.GetAll();

            ExcelHelper helper = new ExcelHelper();
            var package = helper.GetPackage(Tempate.TSKHK);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            int currentRow = 4;
            int count = 0;
            double total = 0;
            //BT CTTS
            worksheet.InsertRow(currentRow, 1);
            count += 1;
            var bt_ctts_percent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.BT_CTTS)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Biên tập CTTS";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{bt_ctts_percent}% x ({sumListPV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))}+{sumListCTV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))})";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = bt_ctts_percent * (sumListPV + sumListCTV);
            total += bt_ctts_percent * (sumListPV + sumListCTV);
            currentRow += 1;

            //PTV
            worksheet.InsertRow(currentRow, 1);
            count += 1;
            var ptv_precent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.PTV)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Phát thanh viên";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ptv_precent}% x ({sumListPV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))}+{sumListCTV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))}) - (720.000/4 PTV)";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = ptv_precent * (sumListPV + sumListCTV) - 720000;
            total += ptv_precent * (sumListPV + sumListCTV) - 720000;
            currentRow += 1;

            //KTD
            worksheet.InsertRow(currentRow, 1);
            count += 1;
            var ktd_precent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.KTD)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Kỹ thuật dựng";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ktd_precent}% x ({sumListPV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))}+{sumListCTV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))})";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = ktd_precent * (sumListPV + sumListCTV);
            total += ktd_precent * (sumListPV + sumListCTV);
            currentRow += 1;

            //TP truc CTTS
            worksheet.InsertRow(currentRow, 1);
            count += 1;
            var tp_ctts_point = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.TP_TRUC_CTTS)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            var numberOfDays = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.SO_NGAY)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "TP trực CTTS";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))} đồng/điểm x {tp_ctts_point} điểm/ngày x {numberOfDays} ngày";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = price * tp_ctts_point * numberOfDays;
            total += price * tp_ctts_point * numberOfDays;
            currentRow += 1;

            //PV TD
            worksheet.InsertRow(currentRow, 1);
            count += 1;
            var pv_td_point = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.PV_TD)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Phóng viên trực dựng";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))} đồng/điểm x {pv_td_point} điểm/ngày x {numberOfDays} ngày";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = price * pv_td_point * numberOfDays;
            total += price * pv_td_point * numberOfDays;
            currentRow += 1;

            //VI TINH
            worksheet.InsertRow(currentRow, 1);
            count += 1;
            var tien_vi_tinh = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.TIEN_VI_TINH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            var nguoi_vi_tinh = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.NGUOI_VI_TINH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Khoản đánh máy vi tính";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{tien_vi_tinh.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))} đồng/người x {nguoi_vi_tinh} người";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = tien_vi_tinh * nguoi_vi_tinh;
            total += tien_vi_tinh * nguoi_vi_tinh;
            currentRow += 1;

            //DANH SÁCH
            worksheet.InsertRow(currentRow, 1);
            count += 1;
            var danh_sach_price = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.DANH_SACH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Soạn list BTL(Kim Thoa)";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{danh_sach_price.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))} đồng/người";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = danh_sach_price;
            total += danh_sach_price;
            currentRow += 1;

            //TỔNG CỘNG
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = total;

            //title row
            worksheet.Cells[2, TS_KHK_COL.THANHTIEN].Value = $"THÁNG {endDate.Month}/{endDate.Year}";


            //report date row
            worksheet.Cells[currentRow + 2, TS_KHK_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //money string
            worksheet.Cells[currentRow + 1, TS_KHK_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN((decimal)total)})";

            //set oreintation
            worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

            //border
            worksheet.Cells[4, 1, currentRow - 1, TS_KHK_COL.THANHTIEN + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[4, 1, currentRow - 1, TS_KHK_COL.THANHTIEN + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[4, 1, currentRow - 1, TS_KHK_COL.THANHTIEN + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[4, 1, currentRow - 1, TS_KHK_COL.THANHTIEN + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;

            return package.GetAsByteArray();
        }

        public void InteropPreviewReportTS(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.TS}.xlsx");
            var worksheet = (Worksheet)workbook.Worksheets[1];

            #endregion

            #region fill data here

            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);

            int currentRow = 5;

            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, TS_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                    {
                        Range line = (Range)worksheet.Rows[currentRow];
                        line.Insert();
                    }

                    worksheet.Cells[currentRow, TS_COL.STT].Value = i + 1;
                    worksheet.Cells[currentRow, TS_COL.HO_TEN].Value = list[i].EmployeeName;
                    worksheet.Cells[currentRow, TS_COL.TIN].Value = list[i].SoTin;
                    worksheet.Cells[currentRow, TS_COL.TIN_DIEM].Value = list[i].DiemTin;
                    worksheet.Cells[currentRow, TS_COL.PHSU].Value = list[i].SoPsu;
                    worksheet.Cells[currentRow, TS_COL.PHSU_DIEM].Value = list[i].DiemPsu;
                    worksheet.Cells[currentRow, TS_COL.QTIN_DIEM].Value = list[i].DiemQtin;
                    worksheet.Cells[currentRow, TS_COL.QPSU_DIEM].Value = list[i].DiemQPsu;

                    worksheet.Cells[currentRow, TS_COL.CONG].Value = list[i].SumPoint;
                    worksheet.Cells[currentRow, TS_COL.TRUCHITIEU].Value = list[i].Descrease;
                    worksheet.Cells[currentRow, TS_COL.TANGGIAM].Value = list[i].IncreasePercent;
                    worksheet.Cells[currentRow, TS_COL.TONGCONG].Value = list[i].TotalPoint;
                    worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = list[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }



            //title row
            worksheet.Cells[2, 12].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, 11].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, 14].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            worksheet.Cells[currentRow, TS_COL.TIN].Value = list.Sum(e => e.SoTin);
            worksheet.Cells[currentRow, TS_COL.TIN_DIEM].Value = list.Sum(e => e.DiemTin);
            worksheet.Cells[currentRow, TS_COL.PHSU].Value = list.Sum(e => e.SoPsu);
            worksheet.Cells[currentRow, TS_COL.PHSU_DIEM].Value = list.Sum(e => e.DiemPsu);
            worksheet.Cells[currentRow, TS_COL.QTIN_DIEM].Value = list.Sum(e => e.DiemQtin);
            worksheet.Cells[currentRow, TS_COL.QPSU_DIEM].Value = list.Sum(e => e.DiemQPsu);
            worksheet.Cells[currentRow, TS_COL.CONG].Value = list.Sum(e => e.SumPoint);
            worksheet.Cells[currentRow, TS_COL.TRUCHITIEU].Value = list.Sum(e => e.Descrease);
            worksheet.Cells[currentRow, TS_COL.TANGGIAM].Value = list.Sum(e => e.IncreasePercent);
            worksheet.Cells[currentRow, TS_COL.TONGCONG].Value = list.Sum(e => e.TotalPoint);
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, 14].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[TS_COL.TRUCHITIEU].Hidden = true;
            }

            //set oreintation
            //worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

            //if (list.Count > 0)
            //{
            //    //border
            //    worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            //}
            //else
            //{

            //}

            #endregion

            #region setup file
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            application.Visible = true;

            worksheet.PrintPreview();
            #endregion
        }

        public void InteropPreviewReportPT(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.PT}.xlsx");
            var worksheet = (Worksheet)workbook.Worksheets[1];

            #endregion

            #region fill data
            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, PT_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;


            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                    {
                        Range line = (Range)worksheet.Rows[currentRow];
                        line.Insert();
                    }
                    worksheet.Cells[currentRow, PT_COL.STT].Value = i + 1;
                    worksheet.Cells[currentRow, PT_COL.HO_TEN].Value = list[i].EmployeeName;
                    worksheet.Cells[currentRow, PT_COL.DON_VI].Value = list[i].Organization;
                    worksheet.Cells[currentRow, PT_COL.SL_TIN].Value = list[i].SoTin;
                    worksheet.Cells[currentRow, PT_COL.D_TIN].Value = list[i].DiemTin;
                    worksheet.Cells[currentRow, PT_COL.SL_BAI].Value = list[i].SoBai;
                    worksheet.Cells[currentRow, PT_COL.D_BAI].Value = list[i].DiemBai;
                    worksheet.Cells[currentRow, PT_COL.SL_CD].Value = list[i].SoCd;
                    worksheet.Cells[currentRow, PT_COL.D_CD].Value = list[i].DiemCd;
                    worksheet.Cells[currentRow, PT_COL.SL_PV].Value = list[i].SoPv;
                    worksheet.Cells[currentRow, PT_COL.D_PV].Value = list[i].DiemPv;
                    worksheet.Cells[currentRow, PT_COL.SL_TLT].Value = list[i].SoTLT;
                    worksheet.Cells[currentRow, PT_COL.D_TLT].Value = list[i].DiemTLT;
                    worksheet.Cells[currentRow, PT_COL.SL_SD].Value = list[i].SoSD;
                    worksheet.Cells[currentRow, PT_COL.D_SD].Value = list[i].DiemSD;

                    worksheet.Cells[currentRow, PT_COL.TRUCHITIEU].Value = list[i].Descrease;
                    worksheet.Cells[currentRow, PT_COL.TONGDIEM].Value = list[i].SumPoint;
                    worksheet.Cells[currentRow, PT_COL.TANGGIAM].Value = list[i].IncreasePercent;
                    worksheet.Cells[currentRow, PT_COL.THANHTIEN].Value = list[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }

            //title row
            worksheet.Cells[2, PT_COL.SL_SD].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, PT_COL.SL_TLT].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, PT_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, PT_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, PT_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[PT_COL.TRUCHITIEU].Hidden = true;
            }

            //if (list.Count > 0)
            //{
            //    //border
            //    worksheet.Cells[5, 1, currentRow - 1, PT_COL.THANHTIEN + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[5, 1, currentRow - 1, PT_COL.THANHTIEN + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[5, 1, currentRow - 1, PT_COL.THANHTIEN + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[5, 1, currentRow - 1, PT_COL.THANHTIEN + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            //}
            //else
            //{

            //}
            #endregion

            #region setup file
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            application.Visible = true;

            worksheet.PrintPreview();
            #endregion
        }

        public void InteropPreviewReportPTTT(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.PTTT}.xlsx");
            var worksheet = (Worksheet)workbook.Worksheets[1];

            #endregion

            #region fill data
            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, PTTT_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                    {
                        Range line = (Range)worksheet.Rows[currentRow];
                        line.Insert();
                    }
                    worksheet.Cells[currentRow, PTTT_COL.STT].Value = i + 1;
                    worksheet.Cells[currentRow, PTTT_COL.HO_TEN].Value = list[i].EmployeeName;
                    worksheet.Cells[currentRow, PTTT_COL.DON_VI].Value = list[i].Organization;
                    worksheet.Cells[currentRow, PTTT_COL.SL_TIN].Value = list[i].SoTin;
                    worksheet.Cells[currentRow, PTTT_COL.D_TIN].Value = list[i].DiemTin;
                    worksheet.Cells[currentRow, PTTT_COL.SL_TT].Value = list[i].SoTTh_Gnh;
                    worksheet.Cells[currentRow, PTTT_COL.D_TT].Value = list[i].DiemTTh_Gnh;
                    worksheet.Cells[currentRow, PTTT_COL.SL_CD].Value = list[i].SoCde;
                    worksheet.Cells[currentRow, PTTT_COL.D_CD].Value = list[i].DiemCde;
                    worksheet.Cells[currentRow, PTTT_COL.SL_PV].Value = list[i].SoPv;
                    worksheet.Cells[currentRow, PTTT_COL.D_PV].Value = list[i].DiemPv;
                    worksheet.Cells[currentRow, PTTT_COL.SL_BS].Value = list[i].SoBs_DCT;
                    worksheet.Cells[currentRow, PTTT_COL.D_BS].Value = list[i].DiemBs_DCT;
                    worksheet.Cells[currentRow, PTTT_COL.SL_BT].Value = list[i].SoBt_Dd;
                    worksheet.Cells[currentRow, PTTT_COL.D_BT].Value = list[i].DiemBt_Dd;

                    worksheet.Cells[currentRow, PTTT_COL.TRUCHITIEU].Value = list[i].Descrease;
                    worksheet.Cells[currentRow, PTTT_COL.TONGDIEM].Value = list[i].SumPoint;
                    worksheet.Cells[currentRow, PTTT_COL.TANGGIAM].Value = list[i].IncreasePercent;
                    worksheet.Cells[currentRow, PTTT_COL.THANHTIEN].Value = list[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }

            //title row
            worksheet.Cells[2, PTTT_COL.SL_BT].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, PTTT_COL.SL_BS].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, PTTT_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, PTTT_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, PTTT_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[PTTT_COL.TRUCHITIEU].Hidden = true;
            }
            #endregion

            #region setup file
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            application.Visible = true;

            worksheet.PrintPreview();
            #endregion
        }

        public void InteropPreviewReportBSTTNM(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.BSTTNM}.xlsx");
            var worksheet = (Worksheet)workbook.Worksheets[1];

            #endregion

            #region fill data
            var listBSTTNM = GetReportBroadcast(startDate, endDate, role, price, reportType);
            var listKHK = GetReportBroadcast(startDate, endDate, role, price, ArticleType.KHOIHK_TTNM);

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, BSTTNM_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            if (listBSTTNM != null && listBSTTNM.Count > 0)
            {
                for (int i = 0; i < listBSTTNM.Count; i++)
                {
                    if (i > 0)
                    {
                        Range line = (Range)worksheet.Rows[currentRow];
                        line.Insert();
                    }
                    worksheet.Cells[currentRow, BSTTNM_COL.STT].Value = i + 1;
                    worksheet.Cells[currentRow, BSTTNM_COL.HO_TEN].Value = listBSTTNM[i].EmployeeName;
                    worksheet.Cells[currentRow, BSTTNM_COL.DON_VI].Value = listBSTTNM[i].Organization;
                    worksheet.Cells[currentRow, BSTTNM_COL.SL_BS_TTN].Value = listBSTTNM[i].SoBs_TTN;
                    worksheet.Cells[currentRow, BSTTNM_COL.D_BS_TTN].Value = listBSTTNM[i].DiemBs_TTN;
                    worksheet.Cells[currentRow, BSTTNM_COL.SL_BtDuyet].Value = listBSTTNM[i].SoBt_Duyet;
                    worksheet.Cells[currentRow, BSTTNM_COL.D_BtDuyet].Value = listBSTTNM[i].DiemBt_Duyet;
                    worksheet.Cells[currentRow, BSTTNM_COL.SL_Kthinh].Value = listBSTTNM[i].SoKThinh;
                    worksheet.Cells[currentRow, BSTTNM_COL.D_Kthinh].Value = listBSTTNM[i].DiemKThinh;
                    worksheet.Cells[currentRow, BSTTNM_COL.SL_Sapo].Value = listBSTTNM[i].SoBs_Sapo;
                    worksheet.Cells[currentRow, BSTTNM_COL.D_Sapo].Value = listBSTTNM[i].DiemBs_Sapo;
                    worksheet.Cells[currentRow, BSTTNM_COL.SL_Tfile].Value = listBSTTNM[i].SoTFile;
                    worksheet.Cells[currentRow, BSTTNM_COL.D_Tfile].Value = listBSTTNM[i].DiemTFile;

                    worksheet.Cells[currentRow, BSTTNM_COL.TRUCHITIEU].Value = listBSTTNM[i].Descrease;
                    worksheet.Cells[currentRow, BSTTNM_COL.TONGDIEM].Value = listBSTTNM[i].SumPoint;
                    worksheet.Cells[currentRow, BSTTNM_COL.TANGGIAM].Value = listBSTTNM[i].IncreasePercent;
                    worksheet.Cells[currentRow, BSTTNM_COL.THANHTIEN].Value = listBSTTNM[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }


            //sum row
            var totalCostBSTTNM = listBSTTNM.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, BSTTNM_COL.THANHTIEN].Value = totalCostBSTTNM;

            currentRow += 4;
            if (listKHK != null && listKHK.Count > 0)
            {
                for (int i = 0; i < listKHK.Count; i++)
                {
                    if (i > 0)
                    {
                        Range line = (Range)worksheet.Rows[currentRow];
                        line.Insert();
                    }
                    worksheet.Cells[currentRow, KHK_COL.STT].Value = i + 1;
                    worksheet.Cells[currentRow, KHK_COL.HO_TEN].Value = listKHK[i].EmployeeName;
                    worksheet.Cells[currentRow, KHK_COL.DON_VI].Value = listKHK[i].Organization;
                    worksheet.Cells[currentRow, KHK_COL.SL_DCT].Value = listKHK[i].SoDCT;
                    worksheet.Cells[currentRow, KHK_COL.D_DCT].Value = listKHK[i].DiemDCT;
                    worksheet.Cells[currentRow, KHK_COL.SL_KTD].Value = listKHK[i].SoKTD;
                    worksheet.Cells[currentRow, KHK_COL.D_KTD].Value = listKHK[i].DiemKTD;
                    worksheet.Cells[currentRow, KHK_COL.SL_KTTH].Value = listKHK[i].SoKT_TH;
                    worksheet.Cells[currentRow, KHK_COL.D_KTTH].Value = listKHK[i].DiemKT_TH;
                    worksheet.Cells[currentRow, KHK_COL.SL_TCT].Value = listKHK[i].SoTCT;
                    worksheet.Cells[currentRow, KHK_COL.D_TCT].Value = listKHK[i].DiemTCT;

                    worksheet.Cells[currentRow, KHK_COL.TRUCHITIEU].Value = listKHK[i].Descrease;
                    worksheet.Cells[currentRow, KHK_COL.TONGDIEM].Value = listKHK[i].SumPoint;
                    worksheet.Cells[currentRow, KHK_COL.TANGGIAM].Value = listKHK[i].IncreasePercent;
                    worksheet.Cells[currentRow, KHK_COL.THANHTIEN].Value = listKHK[i].TotalCost;

                    currentRow += 1;
                }

            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }

            //title row
            worksheet.Cells[2, BSTTNM_COL.TONGDIEM].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, BSTTNM_COL.D_BtDuyet].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, BSTTNM_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCostKHK = listKHK.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, KHK_COL.THANHTIEN].Value = totalCostKHK;

            //money string
            worksheet.Cells[currentRow + 1, BSTTNM_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCostBSTTNM)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[BSTTNM_COL.TRUCHITIEU].Hidden = true;
            }
            #endregion

            #region setup file
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            application.Visible = true;

            worksheet.PrintPreview();
            #endregion
        }

        public void InteropPreviewReportTTNM(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.TTNM}.xlsx");
            var worksheet = (Worksheet)workbook.Worksheets[1];

            #endregion

            #region fill data

            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_Percent.TANG_GIAM_PV_BTV : Criterias_Percent.TANG_GIAM_CTV);
            worksheet.Cells[currentRow - 2, TTNM_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                    {
                        Range line = (Range)worksheet.Rows[currentRow];
                        line.Insert();
                    }
                    worksheet.Cells[currentRow, TTNM_COL.STT].Value = i + 1;
                    worksheet.Cells[currentRow, TTNM_COL.HO_TEN].Value = list[i].EmployeeName;
                    worksheet.Cells[currentRow, TTNM_COL.DON_VI].Value = list[i].Organization;
                    worksheet.Cells[currentRow, TTNM_COL.SL_TIN].Value = list[i].SoTin;
                    worksheet.Cells[currentRow, TTNM_COL.D_TIN].Value = list[i].DiemTin;
                    worksheet.Cells[currentRow, TTNM_COL.SL_PS].Value = list[i].SoTTh_Gnh;
                    worksheet.Cells[currentRow, TTNM_COL.D_PS].Value = list[i].DiemTTh_Gnh;
                    worksheet.Cells[currentRow, TTNM_COL.SL_QTin].Value = list[i].SoCde;
                    worksheet.Cells[currentRow, TTNM_COL.D_QTin].Value = list[i].DiemCde;
                    worksheet.Cells[currentRow, TTNM_COL.SL_QPsu].Value = list[i].SoPv;
                    worksheet.Cells[currentRow, TTNM_COL.D_QPsu].Value = list[i].DiemPv;
                    worksheet.Cells[currentRow, TTNM_COL.SL_Tlt].Value = list[i].SoBs_DCT;
                    worksheet.Cells[currentRow, TTNM_COL.D_Tlt].Value = list[i].DiemBs_DCT;
                    worksheet.Cells[currentRow, TTNM_COL.SL_Thop].Value = list[i].SoBt_Dd;
                    worksheet.Cells[currentRow, TTNM_COL.D_Thop].Value = list[i].DiemBt_Dd;

                    worksheet.Cells[currentRow, TTNM_COL.TRUCHITIEU].Value = list[i].Descrease;
                    worksheet.Cells[currentRow, TTNM_COL.TONGDIEM].Value = list[i].SumPoint;
                    worksheet.Cells[currentRow, TTNM_COL.TANGGIAM].Value = list[i].IncreasePercent;
                    worksheet.Cells[currentRow, TTNM_COL.THANHTIEN].Value = list[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }

            //title row
            worksheet.Cells[2, TTNM_COL.SL_Thop].Value = $"THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, TTNM_COL.SL_Tlt].Value = "(" + (role == EmployeeRole.PV ? "PV" : "CTV") + ")";


            //report date row
            worksheet.Cells[currentRow + 2, TTNM_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, TTNM_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, TTNM_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[TTNM_COL.TRUCHITIEU].Hidden = true;
            }



            #endregion

            #region setup file
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            application.Visible = true;

            worksheet.PrintPreview();
            #endregion
        }

        public void InteropPreviewReportTS_KHK(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.TSKHK}.xlsx");
            var worksheet = (Worksheet)workbook.Worksheets[1];

            #endregion

            #region fill data
            var listPV = GetReportBroadcast(startDate, endDate, EmployeeRole.PV, price, ArticleType.THOI_SU);
            var sumListPV = listPV.Sum(x => x.TotalCost);

            var listCTV = GetReportBroadcast(startDate, endDate, EmployeeRole.CTV, price, ArticleType.THOI_SU);
            var sumListCTV = listCTV.Sum(x => x.TotalCost);

            var listCriterias = _criteriaRepository.GetAll();

            int currentRow = 4;
            int count = 0;
            double total = 0;
            //BT CTTS
            Range line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var bt_ctts_percent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.BT_CTTS)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Biên tập CTTS";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{bt_ctts_percent}% x ({sumListPV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))}+{sumListCTV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))})";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = bt_ctts_percent * (sumListPV + sumListCTV);
            total += bt_ctts_percent * (sumListPV + sumListCTV);
            currentRow += 1;

            //PTV
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var ptv_precent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.PTV)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Phát thanh viên";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ptv_precent}% x ({sumListPV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))}+{sumListCTV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))}) - (720.000/4 PTV)";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = ptv_precent * (sumListPV + sumListCTV) - 720000;
            total += ptv_precent * (sumListPV + sumListCTV) - 720000;
            currentRow += 1;

            //KTD
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var ktd_precent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.KTD)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Kỹ thuật dựng";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ktd_precent}% x ({sumListPV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))}+{sumListCTV.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))})";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = ktd_precent * (sumListPV + sumListCTV);
            total += ktd_precent * (sumListPV + sumListCTV);
            currentRow += 1;

            //TP truc CTTS
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var tp_ctts_point = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.TP_TRUC_CTTS)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            var numberOfDays = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.SO_NGAY)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "TP trực CTTS";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))} đồng/điểm x {tp_ctts_point} điểm/ngày x {numberOfDays} ngày";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = price * tp_ctts_point * numberOfDays;
            total += price * tp_ctts_point * numberOfDays;
            currentRow += 1;

            //PV TD
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var pv_td_point = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.PV_TD)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Phóng viên trực dựng";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))} đồng/điểm x {pv_td_point} điểm/ngày x {numberOfDays} ngày";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = price * pv_td_point * numberOfDays;
            total += price * pv_td_point * numberOfDays;
            currentRow += 1;

            //VI TINH
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var tien_vi_tinh = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.TIEN_VI_TINH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            var nguoi_vi_tinh = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.NGUOI_VI_TINH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Khoản đánh máy vi tính";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{tien_vi_tinh.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))} đồng/người x {nguoi_vi_tinh} người";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = tien_vi_tinh * nguoi_vi_tinh;
            total += tien_vi_tinh * nguoi_vi_tinh;
            currentRow += 1;

            //DANH SÁCH
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var danh_sach_price = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.DANH_SACH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == startDate.Month && x.Configuration.Year == startDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Soạn list BTL(Kim Thoa)";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{danh_sach_price.ToString("N0", CultureInfo.GetCultureInfo("it-IT"))} đồng/người";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = danh_sach_price;
            total += danh_sach_price;
            currentRow += 1;

            //TỔNG CỘNG
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = total;

            //title row
            worksheet.Cells[2, TS_KHK_COL.THANHTIEN].Value = $"THÁNG {endDate.Month}/{endDate.Year}";


            //report date row
            worksheet.Cells[currentRow + 2, TS_KHK_COL.THANHTIEN + 1].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //money string
            worksheet.Cells[currentRow + 1, TS_KHK_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN((decimal)total)})";

            #endregion

            #region setup file
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            application.Visible = true;

            worksheet.PrintPreview();
            #endregion
        }

    }
}
