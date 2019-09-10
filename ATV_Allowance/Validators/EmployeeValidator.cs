using DataService.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Vui lòng nhập họ và tên");

            RuleFor(p => p.OrganizationId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(p => p > 0).WithMessage("Không xác định được đơn vị");

            RuleFor(p => p.Code)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Không xác định được mã nhân viên");            
        }       
    }
}
