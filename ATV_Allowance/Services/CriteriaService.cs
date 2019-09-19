using ATV_Allowance.ViewModel;
using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{

    public interface ICriteriaService
    {
        List<CriteriaViewModel> GetCriterias(int month, int year, int type);
        List<List<CriteriaViewModel>> GetCriterias(int year, int type);
        void UpdateCriterias(List<CriteriaViewModel> criterias, int month, int year);
    }

    public class CriteriaService : ICriteriaService
    {
        private ICriteriaValueRepository criteriaValueRepository;
        private ICriteriaRepository criteriaRepository;
        private IConfigurationRepository configurationRepository;

        public CriteriaService()
        {
            criteriaValueRepository = new CriteriaValueRepository();
            criteriaRepository = new CriteriaRepository();
            configurationRepository = new ConfigurationRepository();
        }

        public List<CriteriaViewModel> GetCriterias(int month, int year, int type)
        {
            var result = criteriaValueRepository.GetAll().Where(c => c.Configuration.Month == month 
                                                                    && c.Configuration.Year == year
                                                                    && c.Criteria.ArticleTypeId == type)
                .Select(c => new CriteriaViewModel
            {
                ID = c.Id,
                Name = c.Criteria.DisplayName,
                Value = c.Value.Value,
                Unit = c.Criteria.Unit.HasValue ? c.Criteria.Unit.Value : Unit.None,
                CriteriaId = c.CriteriaId.Value
            })
            .OrderBy(c => c.CriteriaId)
            .ToList();

            if (result == null || result.Count == 0)
            {
                result = criteriaRepository.GetAll()
                    .Where(c => c.ArticleTypeId == type)
                    .Select(c => new CriteriaViewModel
                {
                    CriteriaId = c.Id,
                    Name = c.DisplayName,
                    Value = 0,
                    Unit = c.Unit.HasValue ? c.Unit.Value : Unit.None
                })
                .OrderBy(c => c.CriteriaId)
                .ToList();
            }

            return result ?? new List<CriteriaViewModel>();
        }

        public List<List<CriteriaViewModel>> GetCriterias(int year, int type)
        {
            List<List<CriteriaViewModel>> result = new List<List<CriteriaViewModel>>();
            for (int month = 1; month <=12; month++)
            {
                result.Add(GetCriterias(month, year, type));
            }

            return result;
        }

        public void UpdateCriterias(List<CriteriaViewModel> criterias, int month, int year)
        {
            var configuation = configurationRepository.Get(c => c.Year == year && c.Month == month).FirstOrDefault();
            if (configuation == null)
            {
                configurationRepository.Add(new Configuration
                {
                    Month = month,
                    Year = year,
                    CriteriaValue = criterias.Select(c => new CriteriaValue
                    {
                        Value = c.Value,
                        CriteriaId = c.CriteriaId
                    }).ToList()
                });
                
            }
            else
            {
                var oldCriterias = criteriaValueRepository.Get(cv => cv.ConfigurationId == configuation.Id);
                foreach(var c in oldCriterias)
                {
                    criteriaValueRepository.Delete(c);
                }

                foreach (var c in criterias)
                {
                    criteriaValueRepository.Add(new CriteriaValue
                    {
                        ConfigurationId = configuation.Id,
                        CriteriaId = c.CriteriaId,
                        Value = c.Value
                    });
                }
            }

            
        }
    }
}
