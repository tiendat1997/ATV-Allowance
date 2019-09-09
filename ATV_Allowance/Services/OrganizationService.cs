using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Services
{
    public interface IOrganizationService
    {
        List<Organization> GetAll();
    }
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        public OrganizationService()
        {
            organizationRepository = new OrganizationRepository();
        }

        public List<Organization> GetAll()
        {
            var list = organizationRepository.GetAll().ToList();
            return list;
        }
    }
}
