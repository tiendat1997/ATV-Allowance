using ATV_Allowance.ViewModel;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Services
{
    public interface IDeductionTypeService
    {
        List<DeductionTypeViewModel> GetDeductionTypes();
    }

    public class DeductionTypeService : IDeductionTypeService
    {
        private IDeductionTypeRepository deductionTypeRepository;

        public DeductionTypeService()
        {
            deductionTypeRepository = new DeductionTypeRepository();
        }
        public List<DeductionTypeViewModel> GetDeductionTypes()
        {
            return deductionTypeRepository.GetAll().Select(d => new DeductionTypeViewModel
            {
                Id = d.Id,
                Name = d.Code,
                Value = d.Amount.Value
            })
            .OrderBy(d => d.Id)
            .ToList();
        }
    }
}
