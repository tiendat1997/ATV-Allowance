using ATV_Allowance.ViewModel;
using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{

    public interface ICriteriaService
    {
        List<CriteriaViewModel> GetCriterias(int month, int year, int type);
        List<List<CriteriaViewModel>> GetYearlyCriterias(int year, int type);
        void UpdateCriterias(List<CriteriaViewModel> criterias, int month, int year, int articleTypeId);
        double GetCriteriaValue(int month, int year, int criteriaTypeId);
        void CopyYearlyCriterias(int year);

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

        public List<List<CriteriaViewModel>> GetYearlyCriterias(int year, int type)
        {
            List<List<CriteriaViewModel>> result = new List<List<CriteriaViewModel>>();
            for (int month = 1; month <= 12; month++)
            {
                result.Add(GetCriterias(month, year, type));
            }

            return result;
        }

        public double GetCriteriaValue(int month, int year, int criteriaTypeId)
        {
            var criteria = criteriaValueRepository.GetMany(x => x.Configuration.Month == month && x.Configuration.Year == year && x.CriteriaId == criteriaTypeId)
                                            .FirstOrDefault();
            return criteria != null ? criteria.Value.GetValueOrDefault(0) : 0;
        }

        public void UpdateCriterias(List<CriteriaViewModel> criterias, int month, int year, int articleTypeId)
        {
            var configuation = configurationRepository.Get(c => c.Year == year && c.Month == month).FirstOrDefault();
            if (configuation == null)
            {
                configuation = new Configuration
                {
                    Month = month,
                    Year = year,
                };
                configurationRepository.Add(configuation);
            }

            var newValues = criterias.Select(c => new CriteriaValue
            {
                Value = c.Value,
                CriteriaId = c.CriteriaId,
                ConfigurationId = configuation.Id
            }).ToList();

            var currentCriterias = criteriaRepository.GetIncludeCriteriaValue(articleTypeId);
            var oldCriteriaValues = currentCriterias
                                .SelectMany(c => c.CriteriaValue)
                                .Where(cv => cv.ConfigurationId == configuation.Id)
                                .ToList();
            
            criteriaValueRepository.DeleteRange(oldCriteriaValues);
            criteriaValueRepository.AddRange(newValues);          
        }

        public void CopyYearlyCriterias(int year)
        {
            var configurations = configurationRepository.GetAsNoTracking(x => x.Year == year).ToList();

            var currentYear = DateTime.Now.Year;
            var currentConfigurations = configurationRepository.GetMany(x => x.Year == currentYear).ToList();

            if (currentConfigurations != null && currentConfigurations.Count > 0)
            {
                foreach (var c in currentConfigurations)
                {
                    configurationRepository.Delete(c);
                }
            }

            var copiedConfigurations = configurations.Select(x => new Configuration
            {
                Month = x.Month,
                Year = currentYear,
                CriteriaValue = x.CriteriaValue.Select(c => new CriteriaValue
                {
                    Unit = c.Unit,
                    Value = c.Value,
                    CriteriaId = c.CriteriaId
                }).ToList()
            });


            foreach (var c in copiedConfigurations)
            {
                configurationRepository.Add(c);
            }
        }
    }
}
