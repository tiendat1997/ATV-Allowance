using ATV_Allowance.ViewModel;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{
    public interface IReportService
    {
        List<EmployeePointViewModel> GetReportBroadcast(DateTime startDate, DateTime endDate, int role, int price);
    }
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService()
        {
            _reportRepository = new ReportRepository();
        }

        public List<EmployeePointViewModel> GetReportBroadcast(DateTime startDate, DateTime endDate, int role, int price)
        {
            var list = _reportRepository.GetReport(startDate, endDate, ReportType.PT, EmployeeRole.CTV).Result;
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

                switch (item.PointType) {
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
    }
}
