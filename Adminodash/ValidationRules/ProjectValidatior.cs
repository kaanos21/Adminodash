using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Adminodash.Entities;

namespace Adminodash.ValidationRules
{
    public class ProjectValidatior :AbstractValidator<Project>
    {
        public ProjectValidatior()
        {
            RuleFor(x => x.ProjectName).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.ProjectName).MinimumLength(3).WithMessage("En az 3 karakter giriniz");
            RuleFor(x => x.ProjectProgress).LessThan(101).WithMessage("Lütfen 0 ile 100 arasında bir değer giriniz");
        }
    }
}