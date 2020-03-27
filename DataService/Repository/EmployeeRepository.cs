using DataService.Entity;
using DataService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAllEmployees(bool isActive);
    }
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository()
        {

        }

        public IEnumerable<Employee> GetAllEmployees(bool isActive)
        {
            var list = dbSet.Where(e => e.IsActive == isActive)
                            .Include(e => e.Organization1)
                            .Include(e => e.Position)
                            .ToList();
            return list;
        }
    }
}
