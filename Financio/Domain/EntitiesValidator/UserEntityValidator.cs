using FluentValidation;

namespace Domain.Entities.EntitiesValidator
{
    public class UserEntityValidator : AbstractValidator<UserEntity>
    {
        public UserEntityValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName can not be empty");
        }
    }
}