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
                
            
        }
    }
}