using CelilCavus.Departman.Entity.Entity;
using FluentValidation;

namespace CelilCavus.Departman.Validation.Validatior
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.DepartmanName).MinimumLength(2).WithMessage("Uppss! Departman Adı Minumum 2 Karakter Olmalıdır...");
            RuleFor(x => x.DepartmanName).MaximumLength(50).WithMessage("Uppss! Departman Adı Maksimum 50 Karakter Olmalıdır...");
            RuleFor(x => x.DepartmanName).NotEmpty().WithMessage("Upps! Sanırım Departman Adını Boş Bıraktınız Orası Boş Olamaz.!");
        }
    }
}
