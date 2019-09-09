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
        List<EmployeeViewModel> GetAllActive(bool isActive);
        string GenerateEmployeeCode(string empName);
        Position GetPositionByCode(string code);
        void AddEmployee(Employee emp);
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

        public string GenerateEmployeeCode(string empName)
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
            if (existedCount > 0)
            {
                tempCode = tempCode + (existedCount);
            }
            return tempCode;
        }

        public List<EmployeeViewModel> GetAllActive(bool isActive)
        {
            var list = employeeRepository.GetAll().Where(e => e.IsActive == isActive)
                    .Select(t => new EmployeeViewModel
                    {
                        Id = t.Id,
                        Code = t.Code,
                        Name = t.Name,
                        Organization = t.Organization.Name,
                        Position = t.Position.Code,
                        IsActive = t.IsActive
                    }).ToList();
            return list;
        }

        public Position GetPositionByCode(string code)
        {
            return positionRepository.GetMany(t => t.Code.Equals(code)).FirstOrDefault();
        }        


    }
}
