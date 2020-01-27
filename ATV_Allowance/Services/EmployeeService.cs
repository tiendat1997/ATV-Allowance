using ATV_Allowance.Common;
using ATV_Allowance.ViewModel;
using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATV_Allowance.Services
{
    public interface IEmployeeService
    {
        List<string> GetAllEmployeeCode(bool isActive);
        List<EmployeeViewModel> GetAllActive(bool isActive);
        string GenerateEmployeeCode(string empName, string currCode);
        Position GetPositionByCode(string code);
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee newEmp);
        void DeactiveEmployee(Employee emp);
        EmployeeViewModel GetEmployeeByCode(string code);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IPositionRepository positionRepository;
        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
            positionRepository = new PositionRepository();
        }

        public void AddEmployee(Employee emp)
        {
            employeeRepository.Add(emp);
        }

        public void DeactiveEmployee(Employee emp)
        {
            emp.IsActive = false;
            employeeRepository.Update(emp);
        }

        public string GenerateEmployeeCode(string empName, string currCode)
        {
            Regex regex = new Regex(@"^\d+$"); // match all numbers
            List<string> splitter = empName.Split(' ').ToList();
            string tempCode = splitter.Last();
            tempCode = Utilities.RemoveSign4VietnameseString(tempCode);
            for (int i = 0; i < splitter.Count - 1; i++)
            {
                string partName = Utilities.RemoveSign4VietnameseString(splitter[i]);
                tempCode = tempCode + partName[0];
            }
            var sameEmp = employeeRepository.GetMany(t => t.Code.Contains(tempCode)).ToList();
            int existedCount = 0;
            foreach (var emp in sameEmp)
            {
                string postFix = emp.Code.Replace(tempCode, "");
                if (postFix.Length == 0 || regex.IsMatch(postFix))
                {
                    existedCount++;
                }
            }
            if (tempCode != currCode && existedCount > 0)
            {
                tempCode = tempCode + (existedCount);
            }
            return tempCode;
        }

        public List<EmployeeViewModel> GetAllActive(bool isActive)
        {
            var list = employeeRepository
                    .GetAllEmployees(isActive)
                    .Select(t => new EmployeeViewModel
                    {
                        Id = t.Id,
                        Code = t.Code,
                        Name = t.Name,
                        Organization = t.Organization.Name,
                        OrganizationId = t.Organization.Id,
                        Position = t.Position.Code,
                        PositionId = t.Position.Id,
                        IsActive = t.IsActive,
                        CodeAndName = t.Code + " - " + t.Name
                    }).ToList();
            return list;
        }

        public List<string> GetAllEmployeeCode(bool isActive)
        {
            var list = employeeRepository
                    .GetAll().Where(e => e.IsActive == isActive)
                    .OrderBy(e => e.Code)
                    .Select(e => e.Code)
                    .ToList();
            return list;
        }

        public EmployeeViewModel GetEmployeeByCode(string code)
        {
            var emp = employeeRepository.GetMany(t => t.Code == code)
                              .Select(t => new EmployeeViewModel
                              {
                                  Id = t.Id,
                                  Code = t.Code,
                                  Name = t.Name,
                                  Organization = t.Organization.Name,
                                  OrganizationId = t.Organization.Id,
                                  Position = t.Position.Code,
                                  PositionId = t.Position.Id,
                                  IsActive = t.IsActive,
                                  CodeAndName = t.Code + " - " + t.Name
                              })
                            .FirstOrDefault();
            return emp;
        }

        public Position GetPositionByCode(string code)
        {
            return positionRepository.GetMany(t => t.Code.Equals(code)).FirstOrDefault();
        }

        public void UpdateEmployee(Employee emp)
        {
            employeeRepository.Update(emp);
        }
    }
}
