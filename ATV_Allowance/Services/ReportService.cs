using ATV_Allowance.Helpers;
using ATV_Allowance.ViewModel;
using DataService.Repository;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{
    public interface IReportService
    {
        List<EmployeePointViewModel> GetReportBroadcast(DateTime startDate, DateTime endDate, int role, int price, int reportType);
        byte[] GetReportTS(DateTime startDate, DateTime endDate, int role, int price, int reportType);
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
                    employeePointVM.DiemQtin = item.TotalPoint;
                }
                else if (item.PointType == PointType_ThoiSu.QPs)
                {
                    employeePointVM.DiemQPsu = item.TotalPoint;
                }

            }

            CalculateCost(result, price);

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

                var sum = list[i].DiemTin + list[i].DiemPsu + list[i].DiemQtin + list[i].DiemQPsu;
                var deduction = 0;
                var tongcong = (sum - deduction) * 1.1;
                worksheet.Cells[currentRow, TS_COL.CONG].Value = sum;
                worksheet.Cells[currentRow, TS_COL.TRUCHITIEU].Value = deduction;
                worksheet.Cells[currentRow, TS_COL.TANGGIAM].Value = (sum - deduction) * 0.1;
                worksheet.Cells[currentRow, TS_COL.TONGCONG].Value = tongcong;
                worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = tongcong * price;

                currentRow += 1;
            }

            //title row
            worksheet.Cells[2, 13].Value = $"{endDate.Month}/{endDate.Year}";

            
            //report date row
            worksheet.Cells[currentRow + 2, 14].Value = $"Long Xuyên, Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

            //sum row
            worksheet.Cells[currentRow, TS_COL.TIN].Value = list.Sum(e => e.SoTin);
            worksheet.Cells[currentRow, TS_COL.TIN_DIEM].Value = list.Sum(e => e.DiemTin);
            worksheet.Cells[currentRow, TS_COL.PHSU].Value = list.Sum(e => e.SoPsu);
            worksheet.Cells[currentRow, TS_COL.PHSU_DIEM].Value = list.Sum(e => e.DiemPsu);
            worksheet.Cells[currentRow, TS_COL.QTIN_DIEM].Value = list.Sum(e => e.DiemQtin);
            worksheet.Cells[currentRow, TS_COL.QPSU_DIEM].Value = list.Sum(e => e.DiemQPsu);
            worksheet.Cells[currentRow, TS_COL.CONG].Value = list.Sum(e => e.Sum);
            worksheet.Cells[currentRow, TS_COL.TRUCHITIEU].Value = list.Sum(e => e.Descrease);
            worksheet.Cells[currentRow, TS_COL.TANGGIAM].Value = list.Sum(e => e.IncreasePercent);
            worksheet.Cells[currentRow, TS_COL.TONGCONG].Value = list.Sum(e => e.TotalPoint);
            var totalCost = list.Sum(e => e.TotalCost);
            worksheet.Cells[currentRow, TS_COL.THANHTIEN].Value = totalCost;

            //money string
            worksheet.Cells[currentRow + 1, 14].Value = $"(Thành tiền bằng chữ: {NumberToTextVN(totalCost)})";


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

        private void CalculateCost(List<EmployeePointViewModel> list, int price)
        {
            for(int i =0; i < list.Count; i++)
            {
                var percent = 0.1;
                var sum = list[i].DiemTin + list[i].DiemPsu + list[i].DiemQtin + list[i].DiemQPsu;
                var deduction = 0;
                var tongcong = (sum - deduction) * (1 + percent);
                list[i].Sum = sum;
                list[i].Descrease = 0;
                list[i].IncreasePercent = percent * (sum - deduction);
                list[i].TotalPoint = tongcong;
                list[i].TotalCost = (int)(tongcong * price);
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
                string[] u = { "", "mươi", "trăm", "ngàn", "", "", "triệu", "", "", "tỷ", "", "", "ngàn", "", "", "triệu" };
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

    }
}
