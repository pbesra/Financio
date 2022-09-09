using FluentValidation;

namespace Domain.Entities.EntitiesValidator
{
    public class UserEntityValidator : AbstractValidator<UserEntity>
    {
        public UserEntityValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName can not be empty")
                .MinimumLength(4)
                .Must(s => !s.Contains(' '))
                .WithMessage("Trailing whitespaces are not allowed.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email can not be empty.")
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth can not be empty")
                .Must(BeAValidDate)
                .WithMessage("Invalid date of birth");
        }
        private bool BeAValidDate(DateTime? value)
        {
            DateTime date;
            return DateTime.TryParse(Convert.ToString(value), out date);
        }
    }
}