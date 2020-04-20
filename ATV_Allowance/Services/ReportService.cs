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
using System.Threading;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{
    public interface IReportService
    {
        List<EmployeePointViewModel> GetReportBroadcast(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        void InteropPreviewReportTS(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread);
        void InteropPreviewReportPT(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread);
        void InteropPreviewReportPTTT(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread);
        void InteropPreviewReportBSTTNM(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread);
        void InteropPreviewReportTTNM(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread);
        //void InteropPreviewReportKHK(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        void InteropPreviewReportTS_KHK(DateTime startDate, DateTime endDate, int role, int price, int reportType, Thread flashScreenThread);

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
                    employeePointVM.RoleId = item.RoleId;
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{bt_ctts_percent}% x ({sumListPV.ToString("n0")}+{sumListCTV.ToString("n0")})";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ptv_precent}% x ({sumListPV.ToString("n0")}+{sumListCTV.ToString("n0")}) - (720.000/4 PTV)";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ktd_precent}% x ({sumListPV.ToString("n0")}+{sumListCTV.ToString("n0")})";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("n0")} đồng/điểm x {tp_ctts_point} điểm/ngày x {numberOfDays} ngày";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("n0")} đồng/điểm x {pv_td_point} điểm/ngày x {numberOfDays} ngày";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{tien_vi_tinh.ToString("n0")} đồng/người x {nguoi_vi_tinh} người";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{danh_sach_price.ToString("n0")} đồng/người";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = danh_sach_price;
            total += danh_sach_price;
            currentRow += 1;

            //TỔNG CỘNG
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = total;

            //title row
            worksheet.Cells[2, TS_KHK_COL.THANHTIEN].Value = $"THÁNG {endDate.Month}/{endDate.Year}";


            //report date row
            worksheet.Cells[currentRow + 2, TS_KHK_COL.THANHTIEN + 1].Value = $"An Giang, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

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

        public void InteropPreviewReportTS(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.TS}.xlsx");
            var worksheetPV = (Worksheet)workbook.Worksheets[1];
            var worksheetCTV = (Worksheet)workbook.Worksheets[2];
            var worksheetKHK = (Worksheet)workbook.Worksheets[3];
            #endregion

            long totalPricePV = 0;
            long totalPriceCTV = 0;
            FillDataIntoWorksheetTS(worksheetCTV, startDate, endDate, EmployeeRole.CTV, price, ref totalPriceCTV);
            FillDataIntoWorksheetTS(worksheetPV, startDate, endDate, EmployeeRole.PV, price, ref totalPricePV);
            FillDataIntoWorksheetTSKHK(worksheetKHK, startDate, endDate, price, totalPricePV, totalPriceCTV);
            flashScreenThread.Abort();
            #region setup file
            worksheetPV.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            worksheetCTV.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            application.Visible = true;

            worksheetCTV.PrintPreview();
            worksheetPV.PrintPreview();
            worksheetKHK.PrintPreview();
            application.ScreenUpdating = true;
            #endregion
        }

        public void InteropPreviewReportPT(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.PT}.xlsx");
            var worksheetPV = (Worksheet)workbook.Worksheets[1];
            var worksheetCTV = (Worksheet)workbook.Worksheets[2];

            #endregion

            long costOfRole = 0;
            FillDataIntoWorksheetPT(worksheetCTV, startDate, endDate, EmployeeRole.CTV, price, ref costOfRole);
            FillDataIntoWorksheetPT(worksheetPV, startDate, endDate, EmployeeRole.PV, price, ref costOfRole);
            flashScreenThread.Abort();

            #region setup file
            application.Visible = true;

            worksheetPV.PrintPreview();
            worksheetCTV.PrintPreview();
            application.ScreenUpdating = true;
            #endregion
        }

        public void InteropPreviewReportPTTT(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.PTTT}.xlsx");
            var worksheetPV = (Worksheet)workbook.Worksheets[1];
            var worksheetCTV = (Worksheet)workbook.Worksheets[2];
            #endregion

            long costOfRole = 0;
            FillDataIntoWorksheetPTTT(worksheetCTV, startDate, endDate, EmployeeRole.CTV, price, ref costOfRole);
            FillDataIntoWorksheetPTTT(worksheetPV, startDate, endDate, EmployeeRole.PV, price, ref costOfRole);
            flashScreenThread.Abort();

            #region setup file
            application.Visible = true;

            worksheetPV.PrintPreview();
            worksheetCTV.PrintPreview();
            application.ScreenUpdating = true;
            #endregion
        }

        public void InteropPreviewReportBSTTNM(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.BSTTNM}.xlsx");
            var worksheetPV = (Worksheet)workbook.Worksheets[1];
            //var worksheetCTV = (Worksheet)workbook.Worksheets[2];

            #endregion

            FillDataIntoWorksheetBSTTNM(worksheetPV, startDate, endDate, EmployeeRole.PV, price);
            //FillDataIntoWorksheetBSTTNM(worksheetCTV, startDate, endDate, EmployeeRole.CTV, price);
            flashScreenThread.Abort();
            #region setup file
            application.Visible = true;

            worksheetPV.PrintPreview();
            //worksheetCTV.PrintPreview();
            application.ScreenUpdating = true;
            #endregion
        }

        public void InteropPreviewReportTTNM(DateTime startDate, DateTime endDate, int price, Thread flashScreenThread)
        {
            #region create excel file with template
            Application application = new Application();

            var workbook = application.Workbooks.Add(AppDomain.CurrentDomain.BaseDirectory + $"Templates\\{Tempate.TTNM}.xlsx");
            var worksheetPV = (Worksheet)workbook.Worksheets[1];
            var worksheetCTV = (Worksheet)workbook.Worksheets[2];

            #endregion

            double totalPoint = 0;
            FillDataIntoWorksheetTTNM(worksheetCTV, startDate, endDate, EmployeeRole.CTV, price, ref totalPoint);
            FillDataIntoWorksheetTTNM(worksheetPV, startDate, endDate, EmployeeRole.PV, price, ref totalPoint);

            flashScreenThread.Abort();

            #region setup file
            application.Visible = true;

            worksheetPV.PrintPreview();
            worksheetCTV.PrintPreview();
            application.ScreenUpdating = true;
            #endregion
        }

        public void InteropPreviewReportTS_KHK(DateTime startDate, DateTime endDate, int role, int price, int reportType, Thread flashScreenThread)
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{bt_ctts_percent}% x ({sumListPV.ToString("n0")}+{sumListCTV.ToString("n0")})";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ptv_precent}% x ({sumListPV.ToString("n0")}+{sumListCTV.ToString("n0")}) - (720.000/4 PTV)";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ktd_precent}% x ({sumListPV.ToString("n0")}+{sumListCTV.ToString("n0")})";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("n0")} đồng/điểm x {tp_ctts_point} điểm/ngày x {numberOfDays} ngày";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("n0")} đồng/điểm x {pv_td_point} điểm/ngày x {numberOfDays} ngày";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{tien_vi_tinh.ToString("n0")} đồng/người x {nguoi_vi_tinh} người";
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
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{danh_sach_price.ToString("n0")} đồng/người";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = danh_sach_price;
            total += danh_sach_price;
            currentRow += 1;

            //TỔNG CỘNG
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = total;

            //title row
            worksheet.Cells[2, TS_KHK_COL.THANHTIEN].Value = $"THÁNG {endDate.Month}/{endDate.Year}";


            //report date row
            worksheet.Cells[currentRow + 2, TS_KHK_COL.THANHTIEN + 1].Value = $"An Giang, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //money string
            worksheet.Cells[currentRow + 1, TS_KHK_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN((decimal)total)})";

            #endregion
            flashScreenThread.Abort();
            #region setup file
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            application.Visible = true;

            worksheet.PrintPreview();
            #endregion
        }

        #region private function
        private void FillDataIntoWorksheetTS(Worksheet worksheet, DateTime startDate, DateTime endDate, int role, int price, ref long totalPrice)
        {
            #region fill data here

            var list = GetReportBroadcast(startDate, endDate, role, price, ArticleType.THOI_SU);

            int currentRow = 5;

            var percent = _criteriaService.GetCriteriaValue(endDate.Month, endDate.Year, role == EmployeeRole.PV ? Criterias_THOI_SU.PV_PTV : Criterias_THOI_SU.CTV);
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
                    worksheet.Cells[currentRow, TS_COL.DON_VI].Value = list[i].Organization;
                    if (list[i].SoTin != 0) worksheet.Cells[currentRow, TS_COL.TIN].Value = list[i].SoTin;
                    if (list[i].DiemTin != 0) worksheet.Cells[currentRow, TS_COL.TIN_DIEM].Value = list[i].DiemTin;
                    if (list[i].SoPsu != 0) worksheet.Cells[currentRow, TS_COL.PHSU].Value = list[i].SoPsu;
                    if (list[i].DiemPsu != 0) worksheet.Cells[currentRow, TS_COL.PHSU_DIEM].Value = list[i].DiemPsu;
                    if (list[i].SoQtin != 0) worksheet.Cells[currentRow, TS_COL.QTIN].Value = list[i].SoQtin;
                    if (list[i].DiemQtin != 0) worksheet.Cells[currentRow, TS_COL.QTIN_DIEM].Value = list[i].DiemQtin;
                    if (list[i].SoQPsu != 0) worksheet.Cells[currentRow, TS_COL.QPSU].Value = list[i].SoQPsu;
                    if (list[i].DiemQPsu != 0) worksheet.Cells[currentRow, TS_COL.QPSU_DIEM].Value = list[i].DiemQPsu;

                    if (list[i].SumPoint != 0) worksheet.Cells[currentRow, TS_COL.CONG].Value = list[i].SumPoint;
                    if (list[i].Deduction != 0) worksheet.Cells[currentRow, TS_COL.TRUCHITIEU].Value = list[i].Deduction;
                    if (list[i].IncreasePercent != 0) worksheet.Cells[currentRow, TS_COL.TANGGIAM].Value = list[i].IncreasePercent;
                    if (list[i].TotalPoint != 0) worksheet.Cells[currentRow, TS_COL.TONGCONG].Value = list[i].TotalPoint;
                    if (list[i].TotalCost != 0) worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = list[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }

            //sum row
            worksheet.Cells[currentRow, TS_COL.TIN].Value = list.Sum(e => e.SoTin);
            worksheet.Cells[currentRow, TS_COL.TIN_DIEM].Value = list.Sum(e => e.DiemTin);
            worksheet.Cells[currentRow, TS_COL.PHSU].Value = list.Sum(e => e.SoPsu);
            worksheet.Cells[currentRow, TS_COL.PHSU_DIEM].Value = list.Sum(e => e.DiemPsu);
            worksheet.Cells[currentRow, TS_COL.QTIN].Value = list.Sum(e => e.SoQtin);
            worksheet.Cells[currentRow, TS_COL.QTIN_DIEM].Value = list.Sum(e => e.DiemQtin);
            worksheet.Cells[currentRow, TS_COL.QPSU].Value = list.Sum(e => e.SoQPsu);
            worksheet.Cells[currentRow, TS_COL.QPSU_DIEM].Value = list.Sum(e => e.DiemQPsu);
            worksheet.Cells[currentRow, TS_COL.CONG].Value = list.Sum(e => e.SumPoint);
            worksheet.Cells[currentRow, TS_COL.TRUCHITIEU].Value = list.Sum(e => e.Deduction);
            worksheet.Cells[currentRow, TS_COL.TANGGIAM].Value = list.Sum(e => e.IncreasePercent);
            worksheet.Cells[currentRow, TS_COL.TONGCONG].Value = list.Sum(e => e.TotalPoint);
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = totalCost;

            totalPrice = totalCost;
            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[TS_COL.TRUCHITIEU].Hidden = true;
            }
            else
            {
                //currentRow += 3;
                //FillDataIntoWorksheetTSKHK(worksheet, startDate, endDate, role, price, ref totalCost, totalPriceCTV, ref currentRow);
                //currentRow += 1;
                ////total row
                //worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = totalCost;
            }

            //title row
            var textRole = (role == EmployeeRole.PV ? "PV" : "CTV");
            worksheet.Cells[2, TS_COL.STT].Value = $"{ReportName.TS} ({textRole}) THÁNG {endDate.Month}/{endDate.Year}";

            //money string
            worksheet.Cells[currentRow + 1, TS_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //report date row
            worksheet.Cells[currentRow + 2, TS_COL.THANHTIEN + 1].Value = $"An Giang, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            #endregion
        }

        private void FillDataIntoWorksheetPT(Worksheet worksheet, DateTime startDate, DateTime endDate, int role, int price, ref long costOfRole)
        {
            var list = GetReportBroadcast(startDate, endDate, role, price, ArticleType.PHAT_THANH);

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_PT.PV_PTV : Criterias_PT.CTV);
            worksheet.Cells[currentRow - 2, PT_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            percent = percent / 100;

            int i = 0;
            if (list != null && list.Count > 0)
            {
                for (i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                    {
                        Range line = (Range)worksheet.Rows[currentRow];
                        line.Insert();
                    }
                    worksheet.Cells[currentRow, PT_COL.STT].Value = i + 1;
                    worksheet.Cells[currentRow, PT_COL.HO_TEN].Value = list[i].EmployeeName;
                    worksheet.Cells[currentRow, PT_COL.DON_VI].Value = list[i].Organization;
                    if (list[i].SoTin != 0) worksheet.Cells[currentRow, PT_COL.SL_TIN].Value = list[i].SoTin;
                    if (list[i].DiemTin != 0) worksheet.Cells[currentRow, PT_COL.D_TIN].Value = list[i].DiemTin;
                    if (list[i].SoBai != 0) worksheet.Cells[currentRow, PT_COL.SL_BAI].Value = list[i].SoBai;
                    if (list[i].DiemBai != 0) worksheet.Cells[currentRow, PT_COL.D_BAI].Value = list[i].DiemBai;
                    if (list[i].SoCd != 0) worksheet.Cells[currentRow, PT_COL.SL_CD].Value = list[i].SoCd;
                    if (list[i].DiemCd != 0) worksheet.Cells[currentRow, PT_COL.D_CD].Value = list[i].DiemCd;
                    if (list[i].SoPv != 0) worksheet.Cells[currentRow, PT_COL.SL_PV].Value = list[i].SoPv;
                    if (list[i].DiemPv != 0) worksheet.Cells[currentRow, PT_COL.D_PV].Value = list[i].DiemPv;
                    if (list[i].SoTLT != 0) worksheet.Cells[currentRow, PT_COL.SL_TLT].Value = list[i].SoTLT;
                    if (list[i].DiemTLT != 0) worksheet.Cells[currentRow, PT_COL.D_TLT].Value = list[i].DiemTLT;
                    if (list[i].SoSD != 0) worksheet.Cells[currentRow, PT_COL.SL_SD].Value = list[i].SoSD;
                    if (list[i].DiemSD != 0) worksheet.Cells[currentRow, PT_COL.D_SD].Value = list[i].DiemSD;

                    if (list[i].Deduction != 0) worksheet.Cells[currentRow, PT_COL.TRUCHITIEU].Value = list[i].Deduction;
                    if (list[i].SumPoint - list[i].Deduction != 0) worksheet.Cells[currentRow, PT_COL.TONGDIEM].Value = list[i].SumPoint - list[i].Deduction;
                    if (list[i].IncreasePercent != 0) worksheet.Cells[currentRow, PT_COL.TANGGIAM].Value = list[i].IncreasePercent;
                    if (list[i].TotalCost != 0) worksheet.Cells[currentRow, PT_COL.THANHTIEN].Value = list[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }

            var totalCost = list.Sum(e => e.TotalCost);

            worksheet.Range[worksheet.Cells[4, PT_COL.STT], worksheet.Cells[currentRow - 1, PT_COL.THANHTIEN + 1]].Borders.LineStyle = XlLineStyle.xlContinuous;
            //sum row
            worksheet.Cells[currentRow, PT_COL.THANHTIEN].Value = list.Sum(x => x.TotalCost);

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[PT_COL.TRUCHITIEU].Hidden = true;
                costOfRole += list.Sum(x => x.TotalCost);
            }
            else
            {
                var CTVCost = costOfRole;
                var PVCost = list.Sum(x => x.TotalCost);
                var BBTPercent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, Criterias_PTTT.BBT);

                var BBTCost = (CTVCost + PVCost) * (BBTPercent / 100);
                totalCost += (long)Math.Round(BBTCost);

                //fill header
                worksheet.Cells[currentRow + 2, PTTT_COL.STT].Value = PTTT_COL.GetBBTHeader(BBTPercent, CTVCost, PVCost);

                //fill value
                worksheet.Cells[currentRow + 2, PTTT_COL.TANGGIAM].Value = BBTCost;
                worksheet.Cells[currentRow + 3, PTTT_COL.TANGGIAM].Value = totalCost;
                currentRow += 3;

            }

            //title row
            var textRole = (role == EmployeeRole.PV ? "PV" : "CTV");
            worksheet.Cells[2, PT_COL.STT].Value = $"{ReportName.PT} ({textRole}) THÁNG {endDate.Month}/{endDate.Year}";

            //report date row
            worksheet.Cells[currentRow + 2, PT_COL.THANHTIEN + 1].Value = $"An Giang, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
           
            //money string
            worksheet.Cells[currentRow + 1, PT_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";


        }

        private void FillDataIntoWorksheetPTTT(Worksheet worksheet, DateTime startDate, DateTime endDate, int role, int price, ref long costOfRole)
        {
            #region fill data
            var list = GetReportBroadcast(startDate, endDate, role, price, ArticleType.PHAT_THANH_TT);

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_PTTT.PV_PTV : Criterias_PTTT.CTV);
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
                    if (list[i].SoTin != 0) worksheet.Cells[currentRow, PTTT_COL.SL_TIN].Value = list[i].SoTin;
                    if (list[i].DiemTin != 0) worksheet.Cells[currentRow, PTTT_COL.D_TIN].Value = list[i].DiemTin;
                    if (list[i].SoTTh_Gnh != 0) worksheet.Cells[currentRow, PTTT_COL.SL_TT].Value = list[i].SoTTh_Gnh;
                    if (list[i].DiemTTh_Gnh != 0) worksheet.Cells[currentRow, PTTT_COL.D_TT].Value = list[i].DiemTTh_Gnh;
                    if (list[i].SoCde != 0) worksheet.Cells[currentRow, PTTT_COL.SL_CD].Value = list[i].SoCde;
                    if (list[i].DiemCde != 0) worksheet.Cells[currentRow, PTTT_COL.D_CD].Value = list[i].DiemCde;
                    if (list[i].SoPv != 0) worksheet.Cells[currentRow, PTTT_COL.SL_PV].Value = list[i].SoPv;
                    if (list[i].DiemPv != 0) worksheet.Cells[currentRow, PTTT_COL.D_PV].Value = list[i].DiemPv;
                    if (list[i].SoBs_DCT != 0) worksheet.Cells[currentRow, PTTT_COL.SL_BS].Value = list[i].SoBs_DCT;
                    if (list[i].DiemBs_DCT != 0) worksheet.Cells[currentRow, PTTT_COL.D_BS].Value = list[i].DiemBs_DCT;
                    if (list[i].SoBt_Dd != 0) worksheet.Cells[currentRow, PTTT_COL.SL_BT].Value = list[i].SoBt_Dd;
                    if (list[i].DiemBt_Dd != 0) worksheet.Cells[currentRow, PTTT_COL.D_BT].Value = list[i].DiemBt_Dd;

                    if (list[i].Deduction != 0) worksheet.Cells[currentRow, PTTT_COL.TRUCHITIEU].Value = list[i].Deduction;
                    if (list[i].SumPoint - list[i].Deduction != 0) worksheet.Cells[currentRow, PTTT_COL.TONGDIEM].Value = list[i].SumPoint - list[i].Deduction;
                    if (list[i].IncreasePercent != 0) worksheet.Cells[currentRow, PTTT_COL.TANGGIAM].Value = list[i].IncreasePercent;
                    if (list[i].TotalCost != 0) worksheet.Cells[currentRow, PTTT_COL.THANHTIEN].Value = list[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }
            worksheet.Range[worksheet.Cells[4, PTTT_COL.STT], worksheet.Cells[currentRow, PTTT_COL.THANHTIEN + 1]].Borders.LineStyle = XlLineStyle.xlContinuous;

            //title row
            var textRole = (role == EmployeeRole.PV ? "PV" : "CTV");
            worksheet.Cells[2, PTTT_COL.STT].Value = $"{ReportName.PTTT} ({textRole}) THÁNG {endDate.Month}/{endDate.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, PTTT_COL.THANHTIEN].Value = totalCost;

            if (role == EmployeeRole.CTV)
            {
                worksheet.Rows[currentRow + 1].Hidden = true;
                worksheet.Rows[currentRow + 2].Hidden = true;
                worksheet.Rows[currentRow + 3].Hidden = true;
                worksheet.Rows[currentRow + 4].Hidden = true;

                costOfRole += list.Sum(x => x.TotalCost);
            }
            else
            {
                var CTVCost = costOfRole;
                var PVCost = list.Sum(x => x.TotalCost);
                var toBaAm = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, Criterias_PTTT.ToBaAm);
                var daysOfMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
                var BBTPercent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, Criterias_PTTT.BBT);

                var toBaAmCost = toBaAm * daysOfMonth * price * (1 + percent);
                //var BBTPoint = totalPoint * (BBTPercent / 100) * (1 + percent);
                //BBTPoint = Math.Round(BBTPoint, 2);
                //var BBTCost = BBTPoint * price;
                var BBTCost = (CTVCost + PVCost) * (BBTPercent / 100);
                totalCost += (long)Math.Round(toBaAmCost) + (long)Math.Round(BBTCost);
                
                //fill header
                worksheet.Cells[currentRow + 2, PTTT_COL.STT].Value = PTTT_COL.GetToBaAmHeader(toBaAm, daysOfMonth);
                worksheet.Cells[currentRow + 3, PTTT_COL.STT].Value = PTTT_COL.GetBBTHeader(BBTPercent, CTVCost, PVCost);

                //fill value
                worksheet.Cells[currentRow + 2, PTTT_COL.TANGGIAM].Value = toBaAmCost;
                worksheet.Cells[currentRow + 3, PTTT_COL.TANGGIAM].Value = BBTCost;
                worksheet.Cells[currentRow + 4, PTTT_COL.TANGGIAM].Value = totalCost;
            }

            currentRow += 4;

            //money string
            worksheet.Cells[currentRow + 1, PTTT_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //report date row
            worksheet.Cells[currentRow + 2, PTTT_COL.THANHTIEN + 1].Value = $"An Giang, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[PTTT_COL.TRUCHITIEU].Hidden = true;
            }
            #endregion
        }

        private void FillDataIntoWorksheetTTNM(Worksheet worksheet, DateTime startDate, DateTime endDate, int role, int price, ref double totalPoint)
        {
            #region fill data

            var list = GetReportBroadcast(startDate, endDate, role, price, ArticleType.PV_TTNM);

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_TTNM.PV_PTV : Criterias_TTNM.CTV);
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
                    if (list[i].SoTin != 0) worksheet.Cells[currentRow, TTNM_COL.SL_TIN].Value = list[i].SoTin;
                    if (list[i].DiemTin != 0) worksheet.Cells[currentRow, TTNM_COL.D_TIN].Value = list[i].DiemTin;
                    if (list[i].SoPsu != 0) worksheet.Cells[currentRow, TTNM_COL.SL_PS].Value = list[i].SoPsu;
                    if (list[i].DiemPsu != 0) worksheet.Cells[currentRow, TTNM_COL.D_PS].Value = list[i].DiemPsu;
                    if (list[i].SoQtin != 0) worksheet.Cells[currentRow, TTNM_COL.SL_QTin].Value = list[i].SoQtin;
                    if (list[i].DiemQtin != 0) worksheet.Cells[currentRow, TTNM_COL.D_QTin].Value = list[i].DiemQtin;
                    if (list[i].SoQPsu != 0) worksheet.Cells[currentRow, TTNM_COL.SL_QPsu].Value = list[i].SoQPsu;
                    if (list[i].DiemQPsu != 0) worksheet.Cells[currentRow, TTNM_COL.D_QPsu].Value = list[i].DiemQPsu;
                    if (list[i].SoTLT != 0) worksheet.Cells[currentRow, TTNM_COL.SL_Tlt].Value = list[i].SoTLT;
                    if (list[i].DiemTLT != 0) worksheet.Cells[currentRow, TTNM_COL.D_Tlt].Value = list[i].DiemTLT;
                    if (list[i].SoThop != 0) worksheet.Cells[currentRow, TTNM_COL.SL_Thop].Value = list[i].SoThop;
                    if (list[i].DiemThop != 0) worksheet.Cells[currentRow, TTNM_COL.D_Thop].Value = list[i].DiemThop;

                    if (list[i].Deduction != 0) worksheet.Cells[currentRow, TTNM_COL.TRUCHITIEU].Value = list[i].Deduction;
                    if (list[i].SumPoint - list[i].Deduction != 0) worksheet.Cells[currentRow, TTNM_COL.TONGDIEM].Value = list[i].SumPoint - list[i].Deduction;
                    if (list[i].IncreasePercent != 0) worksheet.Cells[currentRow, TTNM_COL.TANGGIAM].Value = list[i].IncreasePercent;
                    if (list[i].TotalCost != 0) worksheet.Cells[currentRow, TTNM_COL.THANHTIEN].Value = list[i].TotalCost;

                    currentRow += 1;
                }
            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }

            //title row
            var textRole = (role == EmployeeRole.PV ? "PV" : "CTV");
            worksheet.Cells[2, TTNM_COL.STT].Value = $"{ReportName.TTNM} ({textRole}) THÁNG {endDate.Month}/{endDate.Year}";

            //sum row
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, TTNM_COL.SL_TIN].Value = totalCost;

            if (role == EmployeeRole.CTV)
            {
                worksheet.Rows[currentRow + 1].Hidden = true;
                worksheet.Rows[currentRow + 2].Hidden = true;
                worksheet.Rows[currentRow + 3].Hidden = true;
                worksheet.Rows[currentRow + 4].Hidden = true;
                worksheet.Rows[currentRow + 5].Hidden = true;

                totalPoint += list.Sum(x => x.TotalPoint);
            }
            else
            {
                var BBT = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, Criterias_TTNM.BBT);
                var PTV = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, Criterias_TTNM.PTV);
                var KTD = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, Criterias_TTNM.KTD);

                totalPoint += list.Sum(e => e.TotalPoint);
                var BBTPoint = totalPoint * (BBT / 100);
                var BBTCost = BBTPoint * price;

                var PTVPoint = totalPoint * (PTV / 100);
                var PTVCost = PTVPoint * price;

                var KTDPoint = totalPoint * (KTD / 100);
                var KTDCost = KTDPoint * price;

                totalCost += (long)BBTCost + (long)PTVCost + (long)KTDCost;

                //fill header
                worksheet.Cells[currentRow + 2, TTNM_COL.HO_TEN].Value = TTNM_COL.GetBBTHeader(BBT);
                worksheet.Cells[currentRow + 3, TTNM_COL.HO_TEN].Value = TTNM_COL.GetPTVHeader(PTV);
                worksheet.Cells[currentRow + 4, TTNM_COL.HO_TEN].Value = TTNM_COL.GetKTDHeader(KTD);

                //fill value
                worksheet.Cells[currentRow + 2, TTNM_COL.SL_TIN].Value = totalPoint * price;
                worksheet.Cells[currentRow + 3, TTNM_COL.SL_TIN].Value = totalPoint * price;
                worksheet.Cells[currentRow + 4, TTNM_COL.SL_TIN].Value = totalPoint * price;

                worksheet.Cells[currentRow + 2, TTNM_COL.THANHTIEN].Value = BBTCost;
                worksheet.Cells[currentRow + 3, TTNM_COL.THANHTIEN].Value = PTVCost;
                worksheet.Cells[currentRow + 4, TTNM_COL.THANHTIEN].Value = KTDCost;
                worksheet.Cells[currentRow + 5, TTNM_COL.THANHTIEN].Value = totalCost;
            }
            currentRow += 5;

            //money string
            worksheet.Cells[currentRow + 1, TTNM_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";

            //report date row
            worksheet.Cells[currentRow + 2, TTNM_COL.THANHTIEN + 1].Value = $"An Giang, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[TTNM_COL.TRUCHITIEU].Hidden = true;
            }



            #endregion
        }

        private void FillDataIntoWorksheetBSTTNM(Worksheet worksheet, DateTime startDate, DateTime endDate, int role, int price)
        {
            #region fill data
            var listBSTTNM = GetReportBroadcast(startDate, endDate, role, price, ArticleType.BIENSOAN_TTNM);
            var listKHK = GetReportBroadcast(startDate, endDate, role, price, ArticleType.KHOIHK_TTNM);

            int currentRow = 5;
            var percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, role == EmployeeRole.PV ? Criterias_BSTTNM.PV_PTV : 0);
            worksheet.Cells[currentRow - 2, BSTTNM_COL.TANGGIAM].Value = "Tăng " + percent + "%";
            //percent = percent / 100;

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
                    if (listBSTTNM[i].SoBs_TTN != 0) worksheet.Cells[currentRow, BSTTNM_COL.SL_BS_TTN].Value = listBSTTNM[i].SoBs_TTN;
                    if (listBSTTNM[i].DiemBs_TTN != 0) worksheet.Cells[currentRow, BSTTNM_COL.D_BS_TTN].Value = listBSTTNM[i].DiemBs_TTN;
                    if (listBSTTNM[i].SoBt_Duyet != 0) worksheet.Cells[currentRow, BSTTNM_COL.SL_BtDuyet].Value = listBSTTNM[i].SoBt_Duyet;
                    if (listBSTTNM[i].DiemBt_Duyet != 0) worksheet.Cells[currentRow, BSTTNM_COL.D_BtDuyet].Value = listBSTTNM[i].DiemBt_Duyet;
                    if (listBSTTNM[i].SoKThinh != 0) worksheet.Cells[currentRow, BSTTNM_COL.SL_Kthinh].Value = listBSTTNM[i].SoKThinh;
                    if (listBSTTNM[i].DiemKThinh != 0) worksheet.Cells[currentRow, BSTTNM_COL.D_Kthinh].Value = listBSTTNM[i].DiemKThinh;
                    if (listBSTTNM[i].SoBs_Sapo != 0) worksheet.Cells[currentRow, BSTTNM_COL.SL_Sapo].Value = listBSTTNM[i].SoBs_Sapo;
                    if (listBSTTNM[i].DiemBs_Sapo != 0) worksheet.Cells[currentRow, BSTTNM_COL.D_Sapo].Value = listBSTTNM[i].DiemBs_Sapo;
                    if (listBSTTNM[i].SoTFile != 0) worksheet.Cells[currentRow, BSTTNM_COL.SL_Tfile].Value = listBSTTNM[i].SoTFile;
                    if (listBSTTNM[i].DiemTFile != 0) worksheet.Cells[currentRow, BSTTNM_COL.D_Tfile].Value = listBSTTNM[i].DiemTFile;

                    if (listBSTTNM[i].Deduction != 0) worksheet.Cells[currentRow, BSTTNM_COL.TRUCHITIEU].Value = listBSTTNM[i].Deduction;
                    if (listBSTTNM[i].SumPoint - listBSTTNM[i].Deduction != 0) worksheet.Cells[currentRow, BSTTNM_COL.TONGDIEM].Value = listBSTTNM[i].SumPoint - listBSTTNM[i].Deduction;
                    if (listBSTTNM[i].IncreasePercent != 0) worksheet.Cells[currentRow, BSTTNM_COL.TANGGIAM].Value = listBSTTNM[i].IncreasePercent;
                    if (listBSTTNM[i].TotalCost != 0) worksheet.Cells[currentRow, BSTTNM_COL.THANHTIEN].Value = listBSTTNM[i].TotalCost;

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

            currentRow += 3;
            worksheet.Cells[currentRow - 1, KHK_COL.TANGGIAM].Value = "Tăng " + percent + "%";

            long totalCostKHK = 0;

            if (role == EmployeeRole.PV)
            {
                var BBTPrecent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, Criterias_BSTTNM.BBT);
                currentRow += 1;
                worksheet.Cells[currentRow, KHK_COL.HO_TEN] = KHK_COL.GetBBTHeader(BBTPrecent);
                worksheet.Cells[currentRow, KHK_COL.SL_DCT] = totalCostBSTTNM;
                worksheet.Cells[currentRow, KHK_COL.THANHTIEN] = (BBTPrecent / 100) * totalCostBSTTNM;
                totalCostKHK += (long)((BBTPrecent / 100) * totalCostBSTTNM);
            }
            currentRow += 1;
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
                    if (listKHK[i].SoDCT != 0) worksheet.Cells[currentRow, KHK_COL.SL_DCT].Value = listKHK[i].SoDCT;
                    if (listKHK[i].DiemDCT != 0) worksheet.Cells[currentRow, KHK_COL.D_DCT].Value = listKHK[i].DiemDCT;
                    if (listKHK[i].SoKTD != 0) worksheet.Cells[currentRow, KHK_COL.SL_KTD].Value = listKHK[i].SoKTD;
                    if (listKHK[i].DiemKTD != 0) worksheet.Cells[currentRow, KHK_COL.D_KTD].Value = listKHK[i].DiemKTD;
                    if (listKHK[i].SoKT_TH != 0) worksheet.Cells[currentRow, KHK_COL.SL_KTTH].Value = listKHK[i].SoKT_TH;
                    if (listKHK[i].DiemKT_TH != 0) worksheet.Cells[currentRow, KHK_COL.D_KTTH].Value = listKHK[i].DiemKT_TH;
                    if (listKHK[i].SoTCT != 0) worksheet.Cells[currentRow, KHK_COL.SL_TCT].Value = listKHK[i].SoTCT;
                    if (listKHK[i].DiemTCT != 0) worksheet.Cells[currentRow, KHK_COL.D_TCT].Value = listKHK[i].DiemTCT;

                    if (listKHK[i].Deduction != 0) worksheet.Cells[currentRow, KHK_COL.TRUCHITIEU].Value = listKHK[i].Deduction;
                    worksheet.Range[worksheet.Cells[currentRow, KHK_COL.TONGDIEM], worksheet.Cells[currentRow, KHK_COL.TONGDIEM + 1]].Merge(true);
                    if (listKHK[i].SumPoint - listKHK[i].Deduction != 0) worksheet.Cells[currentRow, KHK_COL.TONGDIEM].Value = listKHK[i].SumPoint - listKHK[i].Deduction;
                    worksheet.Range[worksheet.Cells[currentRow, KHK_COL.TANGGIAM], worksheet.Cells[currentRow, KHK_COL.TANGGIAM + 1]].Merge(true);
                    if (listKHK[i].IncreasePercent != 0) worksheet.Cells[currentRow, KHK_COL.TANGGIAM].Value = listKHK[i].IncreasePercent;
                    if (listKHK[i].TotalCost != 0) worksheet.Cells[currentRow, KHK_COL.THANHTIEN].Value = listKHK[i].TotalCost;

                    currentRow += 1;
                }

            }
            else
            {
                worksheet.Rows[currentRow].Delete();
            }

            //hide deduction of CTV
            if (role == EmployeeRole.CTV)
            {
                worksheet.Columns[BSTTNM_COL.TRUCHITIEU].Hidden = true;
            }

            //title row
            var textRole = (role == EmployeeRole.PV ? "PV" : "CTV");
            //worksheet.Cells[2, BSTTNM_COL.STT].Value = $"{ReportName.BSTTNM} ({textRole}) THÁNG {endDate.Month}/{endDate.Year}";
            worksheet.Cells[2, BSTTNM_COL.STT].Value = $"{ReportName.BSTTNM} THÁNG {endDate.Month}/{endDate.Year}";


            //report date row
            worksheet.Cells[currentRow + 3, BSTTNM_COL.THANHTIEN + 1].Value = $"An Giang, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            totalCostKHK += listKHK.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, KHK_COL.THANHTIEN].Value = totalCostKHK;

            //sum 2 report

            var totalCost = totalCostBSTTNM + totalCostKHK;
            worksheet.Cells[currentRow + 1, KHK_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 2, BSTTNM_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";


            #endregion
        }

        private void FillDataIntoWorksheetTSKHK(Worksheet worksheet, DateTime startDates, DateTime endDate, int price, long sumListPV, long sumListCTV)
        {
            //var listPV = GetReportBroadcast(startDate, endDate, EmployeeRole.PV, price, ArticleType.THOI_SU);
            //var sumListPV = listPV.Sum(x => x.TotalCost);

            //var listCTV = GetReportBroadcast(startDate, endDate, EmployeeRole.CTV, price, ArticleType.THOI_SU);
            //var sumListCTV = listCTV.Sum(x => x.TotalCost);

            var listCriterias = _criteriaRepository.GetAsNoTracking().ToList();

            int currentRow = 4;
            int count = 0;
            double total = 0;
            //BT CTTS
            Range line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var bt_ctts_percent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.BT_CTTS)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Biên tập CTTS";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{bt_ctts_percent}% x ({sumListPV.ToString("n0")} + {sumListCTV.ToString("n0")})";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = (bt_ctts_percent / 100) * (sumListPV + sumListCTV);
            total += (bt_ctts_percent / 100) * (sumListPV + sumListCTV);
            currentRow += 1;

            //PTV
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var ptvListDeduction = _deductionService.GetDeductionPTV(endDate.Month, endDate.Year, ArticleType.THOI_SU);
            var totalPtv = ptvListDeduction.Count();
            var totalPtvDeduction = ptvListDeduction.Sum(x => x.Deduction);
            var ptvDeductionCost = totalPtvDeduction * price;
            var ptv_precent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.PTV)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Phát thanh viên";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ptv_precent}% x ({sumListPV.ToString("n0")} + {sumListCTV.ToString("n0")}) - ({ptvDeductionCost.ToString("n0")}/{totalPtv} PTV)";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = (ptv_precent / 100) * (sumListPV + sumListCTV) - ptvDeductionCost;
            total += (ptv_precent / 100) * (sumListPV + sumListCTV) - ptvDeductionCost;
            currentRow += 1;

            //KTD
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var ktdListDeduction = _deductionService.GetDeductionKTD(endDate.Month, endDate.Year, ArticleType.THOI_SU);
            var totalKtd = ktdListDeduction.Count();
            var totalKtdDeduction = ktdListDeduction.Sum(x => x.Deduction);
            var ktdDeductionCost = totalKtdDeduction * price;
            var ktd_precent = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.KTD)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Kỹ thuật dựng";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{ktd_precent}% x ({sumListPV.ToString("n0")} + {sumListCTV.ToString("n0")} - ({ktdDeductionCost.ToString("n0")}/{totalKtd} KTD)";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = (ktd_precent / 100) * (sumListPV + sumListCTV) - ktdDeductionCost;
            total += (ktd_precent / 100) * (sumListPV + sumListCTV) - ktdDeductionCost;
            currentRow += 1;

            //TP truc CTTS
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var tp_ctts_point = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.TP_TRUC_CTTS)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            var numberOfDays = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.SO_NGAY)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            //var numberOfDays = _criteriaRepository.GetAsNoTracking(x => x.Id == Criterias_THOI_SU.SO_NGAY).FirstOrDefault()
            //    .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year).Value
            //    .GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "TP trực CTTS";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("n0")} đồng/điểm x {tp_ctts_point} điểm/ngày x {numberOfDays} ngày";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = price * tp_ctts_point * numberOfDays;
            total += price * tp_ctts_point * numberOfDays;
            currentRow += 1;

            //PV TD
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var pv_td_point = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.PV_TD)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Phóng viên trực dựng";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{price.ToString("n0")} đồng/điểm x {pv_td_point} điểm/ngày x {numberOfDays} ngày";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = price * pv_td_point * numberOfDays;
            total += price * pv_td_point * numberOfDays;
            currentRow += 1;

            //VI TINH
            line = (Range)worksheet.Rows[currentRow];
            line.Insert();
            count += 1;
            var tien_vi_tinh = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.TIEN_VI_TINH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            var nguoi_vi_tinh = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.NGUOI_VI_TINH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Khoản đánh máy vi tính";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{tien_vi_tinh.ToString("n0")} đồng/người x {nguoi_vi_tinh} người";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = tien_vi_tinh * nguoi_vi_tinh;
            total += tien_vi_tinh * nguoi_vi_tinh;
            currentRow += 1;

            //DANH SÁCH
            //line = (Range)worksheet.Rows[currentRow];
            //line.Insert();
            count += 1;
            var danh_sach_price = (listCriterias.FirstOrDefault(x => x.Id == Criterias_THOI_SU.DANH_SACH)
                .CriteriaValue.FirstOrDefault(x => x.Configuration.Month == endDate.Month && x.Configuration.Year == endDate.Year)?
                .Value).GetValueOrDefault(0);
            worksheet.Cells[currentRow, TS_KHK_COL.STT].Value = count;
            worksheet.Cells[currentRow, TS_KHK_COL.BO_PHAN].Value = "Soạn list BTL(Kim Thoa)";
            worksheet.Cells[currentRow, TS_KHK_COL.CONG_THUC].Value = $"{danh_sach_price.ToString("n0")} đồng/người";
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = danh_sach_price;
            total += danh_sach_price;
            currentRow += 1;

            //TỔNG CỘNG
            worksheet.Cells[currentRow, TS_KHK_COL.THANHTIEN].Value = total;

            //title row
            worksheet.Cells[2, TS_COL.STT].Value = $"{ReportName.TSKHK} THÁNG {endDate.Month}/{endDate.Year}";

            //report date row
            worksheet.Cells[currentRow + 2, TS_KHK_COL.THANHTIEN + 1].Value = $"An Giang, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //money string
            worksheet.Cells[currentRow + 1, TS_KHK_COL.THANHTIEN + 1].Value = $"(Thành tiền bằng chữ: {NumberToTextVN((decimal)total)})";

            //sumListPV += (long)total;
        }

        private void CalculateCost(List<EmployeePointViewModel> list, int price, int reportType, int employeeRole, DateTime startDate)
        {
            if (reportType == ArticleType.THOI_SU)
            {
                startDate = startDate.AddMonths(1).AddDays(-1);
            }
            double percent = 0;
            var employeeIds = list.Select(x => x.EmployeeId).ToList();
            int articleType = reportType;
            if (reportType == ArticleType.KHOIHK_TTNM)
            {
                articleType = ArticleType.BIENSOAN_TTNM;
            }
            var employeesDeduction = _deductionService.GetEmployeesDeduction(employeeIds, articleType, startDate.Month, startDate.Year);
            for (int i = 0; i < list.Count; i++)
            {
                double sumPoint = 0;
                if (reportType == ArticleType.THOI_SU)
                {
                    sumPoint = list[i].DiemTin + list[i].DiemPsu + list[i].DiemQtin + list[i].DiemQPsu;
                    percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, employeeRole == EmployeeRole.PV ? Criterias_THOI_SU.PV_PTV : Criterias_THOI_SU.CTV) / 100;
                }
                else if (reportType == ArticleType.PHAT_THANH)
                {
                    sumPoint = list[i].DiemTin + list[i].DiemBai + list[i].DiemCd + list[i].DiemPv + list[i].DiemTLT + list[i].DiemSD;
                    percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, employeeRole == EmployeeRole.PV ? Criterias_PT.PV_PTV : Criterias_PT.CTV) / 100;
                }
                else if (reportType == ArticleType.PHAT_THANH_TT)
                {
                    sumPoint = list[i].DiemTin + list[i].DiemTTh_Gnh + list[i].DiemCde + list[i].DiemPv + list[i].DiemBs_DCT + list[i].DiemBt_Dd;
                    percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, employeeRole == EmployeeRole.PV ? Criterias_PTTT.PV_PTV : Criterias_PTTT.CTV) / 100;
                }
                else if (reportType == ArticleType.PV_TTNM)
                {
                    sumPoint = list[i].DiemTin + list[i].DiemPsu + list[i].DiemQtin + list[i].DiemQPsu + list[i].DiemTLT + list[i].DiemThop;
                    percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, employeeRole == EmployeeRole.PV ? Criterias_TTNM.PV_PTV : Criterias_TTNM.CTV) / 100;
                }
                else if (reportType == ArticleType.BIENSOAN_TTNM)
                {
                    sumPoint = list[i].DiemBs_TTN + list[i].DiemBs_Sapo + list[i].DiemKThinh + list[i].DiemTFile + list[i].DiemBt_Duyet;
                    percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, employeeRole == EmployeeRole.PV ? Criterias_BSTTNM.PV_PTV : 0) / 100;
                }
                else if (reportType == ArticleType.KHOIHK_TTNM)
                {
                    sumPoint = list[i].DiemDCT + list[i].DiemKTD + list[i].DiemTCT + list[i].DiemKT_TH;
                    percent = _criteriaService.GetCriteriaValue(startDate.Month, startDate.Year, employeeRole == EmployeeRole.PV ? Criterias_BSTTNM.PV_PTV : 0) / 100;
                }

                var deduction = (employeesDeduction.FirstOrDefault(x => x.EmployeeId == list[i].EmployeeId)?.Deduction).GetValueOrDefault(0);
                list[i].SumPoint = sumPoint;
                if (articleType == ArticleType.THOI_SU && (list[i].RoleId == (int) EmployeeRole.KTD || list[i].RoleId == (int)EmployeeRole.PTV))
                {
                    deduction = 0;
                }
                list[i].Deduction = deduction;
                list[i].IncreasePercent = Math.Round((percent * (sumPoint - deduction)), 2);
                list[i].TotalPoint = list[i].SumPoint - list[i].Deduction + list[i].IncreasePercent;
                list[i].TotalCost = (long)Math.Round(((float)list[i].TotalPoint * price));
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

        private void CopyWorksheetToWorksheet(Worksheet source, Worksheet dest)
        {
            source.UsedRange.Copy(Type.Missing);
            dest.UsedRange._PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
        }
        #endregion

    }
}
