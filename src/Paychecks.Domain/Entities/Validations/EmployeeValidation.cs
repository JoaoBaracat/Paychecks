using FluentValidation;

namespace Paychecks.Domain.Entities.Validations
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The {PropertyName} must be supplied")
                .MaximumLength(20).WithMessage("The {PropertyName} has a maximum length of 20 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("The {PropertyName} must be supplied")
                .MaximumLength(20).WithMessage("The {PropertyName} has a maximum length of 20 characters");

            RuleFor(x => x.CPF)
                .Must((cpf) => DocumentValidation.IsCPFValid(cpf)).WithMessage("The {PropertyName} must be valid");

            RuleFor(x => x.Sector)
                .NotEmpty().WithMessage("The {PropertyName} must be supplied")
                .MaximumLength(20).WithMessage("The {PropertyName} has a maximum length of 20 characters");

            RuleFor(x => x.GrossSalary)
                .NotEmpty().WithMessage("The {PropertyName} must be supplied")
                .GreaterThan(0).WithMessage("The {PropertyName} must be greater than 0");

            RuleFor(x => x.AdmissionDate)
                .NotEmpty().WithMessage("The {PropertyName} must be supplied");
        }
    }
}