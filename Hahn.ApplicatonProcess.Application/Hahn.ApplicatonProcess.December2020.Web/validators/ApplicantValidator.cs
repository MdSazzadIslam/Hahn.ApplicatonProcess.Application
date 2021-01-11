using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Data.Handlers;

namespace Hahn.ApplicatonProcess.December2020.Web.validators
{
    public class ApplicantValidator : AbstractValidator<ApplicantVm>
    {
        public ApplicantValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please ensure you have entered the Name").MinimumLength(5).WithMessage("Name – at least 5 Characters");
            RuleFor(x => x.FamilyName).NotEmpty().WithMessage("Please ensure you have entered the Family Name").MinimumLength(5).WithMessage("FamilyName – at least 5 Characters");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Please ensure you have entered the Adress").MinimumLength(10).WithMessage("Adress – at least 10 Characters");
            RuleFor(x => x.EmailAdress).NotEmpty().WithMessage("Please ensure you have entered the Email")
                .EmailAddress().WithMessage("EmailAdress - must be an valid email");
            RuleFor(x => x.Age).InclusiveBetween(20, 60).WithMessage("Age – must be between 20 and 60"); ;
        }
    }
}
