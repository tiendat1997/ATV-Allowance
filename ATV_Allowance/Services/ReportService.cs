using ATV_Allowance.Helpers;
using ATV_Allowance.ViewModel;
using DataService.Repository;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{
    public interface IReportService
    {
        List<EmployeePointViewModel> GetReportBroadcast(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        void GetReportTS(DateTime startDate, DateTime endDate, int role, int price, int reportType);
    }
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService()
        {
            _reportRepository = new ReportRepository();
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

                switch (item.PointType)
                {
                    case (int)PointType.Tin:
                        employeePointVM.ArticlePoint = item.PointType;
                        employeePointVM.ArticlePoint = item.Amount;
                        break;
                    case (int)PointType.Bai:
                        employeePointVM.ArticlePoint = item.PointType;
                        employeePointVM.ArticlePoint = item.Amount;
                        break;
                    case (int)PointType.PV:
                        employeePointVM.PVPoint = item.PointType;
                        employeePointVM.PVAmount = item.Amount;
                        break;
                    case (int)PointType.Tlt:
                        employeePointVM.MajorPoint = item.PointType;
                        employeePointVM.MajorAmount = item.Amount;
                        break;
                    case (int)PointType.SD:
                        employeePointVM.BSPoint = item.PointType;
                        employeePointVM.BSAmount = item.Amount;
                        break;
                    case (int)PointType.CD_CM:
                        employeePointVM.BTPoint = item.PointType;
                        employeePointVM.BTAmount = item.Amount;
                        break;
                }

            }

            return result;
        }

        public void GetReportTS(DateTime startDate, DateTime endDate, int role, int price, int reportType)
        {
            var list = GetReportBroadcast(startDate, endDate, role, price, reportType);
            ExcelHelper helper = new ExcelHelper();
            var worksheet = helper.GetWorksheet(Tempate.TS);

            int currentRow = 5;
            for (int i = 0; i < list.Count; i++)
            {
                worksheet.InsertRow(currentRow, 1);
                worksheet.Cells[currentRow, TS_COL.STT].Value = i + 1;
                worksheet.Cells[currentRow, TS_COL.HO_TEN].Value = list[i].EmployeeName;

                currentRow += 1;
            }

            //border
            worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[5, 1, currentRow - 1, 14].Style.Border.Left.Style = ExcelBorderStyle.Thin;

            helper.Save(@"E:\", "test");

        }
    }
}
