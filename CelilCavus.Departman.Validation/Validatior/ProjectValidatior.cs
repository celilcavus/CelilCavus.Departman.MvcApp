using CelilCavus.Departman.Entity.Entity;
using FluentValidation;

namespace CelilCavus.Departman.Validation.Validatior
{
    public class ProjectValidatior : AbstractValidator<Project>
    {
        public ProjectValidatior()
        {
            RuleFor(x => x.ProjectName).NotEmpty().WithMessage("Upps! Proje Adı Boş Geçilemez.");
            RuleFor(x => x.ProjectName).MinimumLength(3).WithMessage("Upps! Proje Adı Min. 3 Karakter olmalıdır.");
            RuleFor(x => x.ProjectName).MaximumLength(50).WithMessage("Upps! Proje Adı Max. 50 Karakter olmalıdır.");


        }
    }
}
