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
    public interface IEmployeeService
    {
        List<EmployeeViewModel> GetAllActive(bool isActive);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
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
    }
}
