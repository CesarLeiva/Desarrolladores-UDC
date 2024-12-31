using Desarrolladores_UDC.DTOs;
using FluentValidation;

namespace Desarrolladores_UDC.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(u => u.EmailAdress)
                .NotEmpty().WithMessage("Email is required.");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
