using FluentValidation;

namespace OnionApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty();
            RuleFor(x => x.AccessToken)
                .NotEmpty();
        }
    }
}
