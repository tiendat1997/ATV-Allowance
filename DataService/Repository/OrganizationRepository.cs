using DataService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Entity;

namespace DataService.Repository
{
    public interface IOrganizationRepository : IRepository<Organization>
    {

    }
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
    }
}
