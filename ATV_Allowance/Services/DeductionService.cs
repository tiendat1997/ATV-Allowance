using ATV_Allowance.ViewModel;
using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Services
{
    public interface IDeductionService
    {
        List<EmployeeDeductionViewModel> GetDeductionPV(int month, int year, int articleType);
        List<EmployeeDeductionViewModel> GetDeductionPTV(int month, int year, int articleType);
        List<EmployeeDeductionViewModel> GetDeductions(int month, int year, int employeeRole, int articleType);
        double GetEmployeeDeduction(int employeeId, int articleId, int month, int year);
        void UpdateDeduction(int employeeId, int deductionType, int month, int year, int employeeRole, int articleType);
    }
    public class DeductionService : IDeductionService
    {
        private IDeductionRepository deductionRepository;
        private ArticleEmployeeRepository articleEmployeeRepository;
        private IEmployeeRepository employeeRepository;

        public DeductionService()
        {
            deductionRepository = new DeductionRepository();
            articleEmployeeRepository = new ArticleEmployeeRepository();
            employeeRepository = new EmployeeRepository();
        }

        public List<EmployeeDeductionViewModel> GetDeductionPTV(int month, int year, int articleType)
        {
            // Get all "Phát Thanh Viên" ( roleId = 1 ) belongs to "Phòng thời sự" (organizationId = 24)
            var employees = employeeRepository
                    .Get(e => e.IsActive == true && e.RoleId == 3 && (e.OrganizationId == 22 || e.OrganizationId == 32))
                    .Select(e => new EmployeeDeductionViewModel
                    {
                        EmployeeId = e.Id,
                        EmployeeName = e.Name,
                        Deduction = 0,
                        DeductionType = 1
                    }).ToList();

            var deductions = deductionRepository.Get(d => d.Month == month && d.Year == year && d.ArticleTypeId == articleType)
                               .Select(d => new EmployeeDeductionViewModel
                               {
                                   EmployeeId = d.EmployeeId.Value,
                                   EmployeeName = d.Employee.Name,
                                   DeductionType = d.DeductionTypeId.Value,
                                   Deduction = d.DeductionType.Amount.Value
                               }).ToList();

            foreach (var emp in employees)
            {
                var existedDeduction = deductions.Where(e => e.EmployeeId == emp.EmployeeId).FirstOrDefault();
                if (existedDeduction != null)
                {
                    emp.Deduction = existedDeduction.Deduction;
                }
            }

            return deductions;
        }

        public List<EmployeeDeductionViewModel> GetDeductionPV(int month, int year, int articleType)
        {
            // Get all "Phóng viên" ( roleId = 1 ) belongs to "Phòng thời sự" (organizationId = 24)
            var employees = employeeRepository
                    .Get(e => e.IsActive == true && e.RoleId == 1 && e.OrganizationId == 24)
                    .Select(e => new EmployeeDeductionViewModel
                    {
                        EmployeeId = e.Id,
                        EmployeeName = e.Name,
                        Deduction = 0,
                        DeductionType = 1
                    }).ToList();

            var deductions = deductionRepository.Get(d => d.Month == month && d.Year == year && d.ArticleTypeId == articleType)
                               .Select(d => new EmployeeDeductionViewModel
                               {
                                   EmployeeId = d.EmployeeId.Value,
                                   EmployeeName = d.Employee.Name,
                                   DeductionType = d.DeductionTypeId.Value,
                                   Deduction = d.DeductionType.Amount.Value
                               }).ToList();

            foreach (var emp in employees)
            {
                var existedDeduction = deductions.Where(e => e.EmployeeId == emp.EmployeeId).FirstOrDefault();
                if (existedDeduction != null)
                {
                    emp.Deduction = existedDeduction.Deduction;
                }                
            }

            return deductions;
        }

        public List<EmployeeDeductionViewModel> GetDeductions(int month, int year, int employeeRole, int articleType)
        {
            var result = deductionRepository.Get(d => d.Month == month && d.Year == year && d.Employee.RoleId == employeeRole && d.ArticleTypeId == articleType)
                                .Select(d => new EmployeeDeductionViewModel
                                {
                                    EmployeeId = d.EmployeeId.Value,
                                    EmployeeName = d.Employee.Name,
                                    DeductionType = d.DeductionTypeId.Value,
                                    Deduction = d.DeductionType.Amount.Value
                                }).ToList();

            
            var artEmpList = articleEmployeeRepository.Get(d => d.Article.Date.Month == month && d.Article.Date.Year == year
                                                            && d.Employee.RoleId == employeeRole && d.Article.TypeId == articleType)
                                                   .Select(d => new EmployeeDeductionViewModel
                                                   {
                                                       EmployeeId = d.EmployeeId.Value,
                                                       EmployeeName = d.Employee.Name,
                                                       Deduction = 0,
                                                       DeductionType = 1
                                                   })
                                                   .Distinct()
                                                   .ToList();
            
            foreach(var emp in artEmpList)
            {
                if (!result.Any(e => e.EmployeeId == emp.EmployeeId))
                {
                    result.Add(emp);
                }
            }

            return result;
        }

        public double GetEmployeeDeduction(int employeeId, int articleTypeId, int month, int year)
        {
            var empDeduction = deductionRepository.GetMany(x => x.EmployeeId == employeeId
                                                                && x.ArticleTypeId == articleTypeId
                                                                && x.Month == month
                                                                && x.Year == year
                                                           ).FirstOrDefault();
            return empDeduction != null ? empDeduction.DeductionType.Amount.Value : 0;
        }

        public void UpdateDeduction(int employeeId, int deductionType, int month, int year, int employeeRole, int articleType)
        {
            var empDeduction = deductionRepository.Get(d => d.EmployeeId.Value == employeeId
                                                            && d.Month.Value == month
                                                            && d.Employee.RoleId.Value == employeeRole
                                                            && d.ArticleTypeId.Value == articleType)
                                                   .FirstOrDefault();

            if (empDeduction == null)
            {
                deductionRepository.Add(new Deduction
                {
                    ArticleTypeId = articleType,
                    EmployeeId = employeeId,
                    DeductionTypeId = deductionType,
                    Month = month,
                    Year = year
                });
            }
            else
            {
                empDeduction.DeductionTypeId = deductionType;
                deductionRepository.Update(empDeduction);
            }

        }
    }
}
