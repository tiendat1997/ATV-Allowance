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
    public interface IOrganizationService
    {
        List<Organization> GetAll();
        List<OrganizationViewModel> GetAllIsActive(bool isActive);
        void AddOrganization(Organization org);
    }
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        public OrganizationService()
        {
            organizationRepository = new OrganizationRepository();
        }

        public void AddOrganization(Organization org)
        {
            organizationRepository.Add(org);
        }

        public List<Organization> GetAll()
        {
            var list = organizationRepository.GetMany(t => t.IsActive == true).ToList();
            return list;
        }

        public List<OrganizationViewModel> GetAllIsActive(bool isActive)
        {
            var list = organizationRepository.GetAll().Where(e => e.IsActive == isActive)
                   .Select(t => new OrganizationViewModel
                   {
                       Id = t.Id,                    
                       Name = t.Name,                       
                       IsActive = t.IsActive ?? false
                   }).ToList(); 
            return list;
        }
    }
}
