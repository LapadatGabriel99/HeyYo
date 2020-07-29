using FluentValidation;
using HeyYo.Core.Data.ApiModels;

namespace HeyYo.Web.Server.Validators
{
    public class RegisterApiValidator : AbstractValidator<RegisterApi>
    {
        public RegisterApiValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9]*$")
                .WithMessage("Username must contain some alpha-numeric characters!")
                .MinimumLength(8)
                .WithMessage("Username must have at least 8 characters!")
                .MaximumLength(128)
                .WithMessage("Username cannot have more than 32 characters!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches("^[A-Z]{1, 32}$")
                .WithMessage("Password must have at least 1 uppercase letter!")
                .Matches("^[a-z]{1, 32}$")
                .WithMessage("Password must have at least 1 lowercase letter!")
                .Matches("^[0-9]{1, 32}$")
                .WithMessage("Password must have at least 1 numeric character!")
                .Matches(@"\W{1, 4}|{1, 4}_{1, 4}")
                .WithMessage("Password must have at least!")
                .MinimumLength(8)
                .WithMessage("Password must have at least 8 characters!")
                .MaximumLength(32)
                .WithMessage("Password cannot have more than 32 characters!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email is not valid!");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches("^[0-9]{4, 15}$")
                .WithMessage("Phone number must be between 4 and 15 characters!");
        }
    }
}
