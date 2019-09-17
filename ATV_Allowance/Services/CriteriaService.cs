using ATV_Allowance.ViewModel;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Services
{

    public interface ICriteriaService
    {
        List<CriteriaViewModel> GetCriterias(int month, int year);
        List<List<CriteriaViewModel>> GetCriterias(int year);
        void UpdateCriterias(List<CriteriaViewModel> criterias);
    }

    public class CriteriaService : ICriteriaService
    {
        private ICriteriaValueRepository criteriaValueRepository;
        private ICriteriaRepository criteriaRepository;

        public CriteriaService()
        {
            criteriaValueRepository = new CriteriaValueRepository();
            criteriaRepository = new CriteriaRepository();
        }

        public List<CriteriaViewModel> GetCriterias(int month, int year)
        {
            var result = criteriaValueRepository.GetAll().Where(c => c.Configuration.Month == month && c.Configuration.Year == year).Select(c => new CriteriaViewModel
            {
                ID = c.Id,
                Name = c.Criteria.DisplayName,
                Value = c.Value.Value,
                Unit = c.Unit.Value,
                CriteriaId = c.CriteriaId.Value
            })
            .OrderBy(c => c.CriteriaId)
            .ToList();

            if (result == null || result.Count == 0)
            {
                result = criteriaRepository.GetAll().Select(c => new CriteriaViewModel
                {
                    CriteriaId = c.Id,
                    Name = c.DisplayName,
                    Value = 0,
                    Unit = 1
                })
                .OrderBy(c => c.CriteriaId)
                .ToList();

            }

            return result;
        }

        public List<List<CriteriaViewModel>> GetCriterias(int year)
        {
            List<List<CriteriaViewModel>> result = new List<List<CriteriaViewModel>>();
            for (int month = 1; month <=12; month++)
            {
                result.Add(GetCriterias(month, year));
            }

            return result;
        }

        public void UpdateCriterias(List<CriteriaViewModel> criterias)
        {
            
        }
    }
}
