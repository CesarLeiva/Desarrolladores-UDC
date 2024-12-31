using DB;
using Desarrolladores_UDC.DTOs;
using Desarrolladores_UDC.Services;
using FluentValidation;
using System.Data;

namespace Desarrolladores_UDC.Validators
{
    public class UserAddValidator : AbstractValidator<UserAddDto>
    {
        private readonly UserService _userService;
        public UserAddValidator(UserService userService)
        {
            _userService = userService;

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MustAsync(async (email, cancellation) => !await _userService.EmailExists(email))
                .WithMessage("This email address is already registered.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character (e.g., @, #, ! , *).");

            RuleFor(u => u.Role)
                .IsInEnum().WithMessage("The role must be one of the valid options [Student, Teacher, or Euternal].")
                .NotEqual(UserRole.Admin).WithMessage("Admin role is not allowed.");

        }
    }
}
