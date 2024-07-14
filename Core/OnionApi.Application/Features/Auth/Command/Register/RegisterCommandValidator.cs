using FluentValidation;

namespace OnionApi.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("Ad ve Soyad");

            RuleFor(x => x.Email)
                 .NotEmpty()
                 .MaximumLength(60)
                 .MinimumLength(8)
                 .EmailAddress()
                 .WithName("Email");

            RuleFor(x => x.Password)
                 .NotEmpty()
                 .MinimumLength(6)
                 .WithName("Parol");

            RuleFor(x => x.ConfirmPassword)
                 .NotEmpty()
                 .MinimumLength(6)
                 .Equal(x=>x.Password)
                 .WithName("Testiq parolu");
        }
    }
}
