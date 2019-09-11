using DataService.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Validators
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(p => p.Title)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Vui lòng nhập tiêu đề cho tin");
        }
    }
}
