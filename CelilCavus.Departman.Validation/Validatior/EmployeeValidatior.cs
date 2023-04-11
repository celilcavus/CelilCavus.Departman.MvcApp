using CelilCavus.Departman.Entity.Entity;
using FluentValidation;

namespace CelilCavus.Departman.Validation.Validatior
{
    public class EmployeeValidatior : AbstractValidator<Employee>
    {
        public EmployeeValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Upps! Ad Alanı Boş Olamaz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Upps! Ad Alanı Minumum 3 Karakter Olmak Zorundadır.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Upps! Ad Alanı Minumum 50 Karakter Olmak Zorundadır.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Upps! soyad Alanı Boş Olamaz");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Upps! soyad Alanı Minumum 3 Karakter Olmak Zorundadır.");
            RuleFor(x => x.LastName).MaximumLength(30).WithMessage("Upps! soyad Alanı Minumum 50 Karakter Olmak Zorundadır.");

            RuleFor(x => x.JobTitle).NotEmpty().WithMessage("Upps! İş Adı Alanı Boş Olamaz");
            RuleFor(x => x.JobTitle).MinimumLength(3).WithMessage("Upps! İş Adı Alanı Minumum 3 Karakter Olmak Zorundadır.");
            RuleFor(x => x.JobTitle).MaximumLength(30).WithMessage("Upps! İş Adı Alanı Minumum 50 Karakter Olmak Zorundadır.");

            RuleFor(x => x.PhoneNo).NotEmpty().WithMessage("Upps! Telefon Numarası Alanı Boş Olamaz");
            RuleFor(x => x.PhoneNo).Length(11).WithMessage("Upps! Telefon Numarası Alanı 11 Karakter Olmak Zorundadır.");

            RuleFor(x => x.Salary).NotEmpty().WithMessage("Upps! Maaş  Alanı Boş Olamaz");
        }
    }
}
