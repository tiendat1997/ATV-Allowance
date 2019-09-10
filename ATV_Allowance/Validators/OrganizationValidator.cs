using DataService.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Validators
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Vui lòng nhập tên đơn vị");                    
        }       
    }
}
