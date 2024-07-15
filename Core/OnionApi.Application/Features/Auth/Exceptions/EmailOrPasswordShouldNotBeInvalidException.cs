using OnionApi.Application.Bases;

namespace OnionApi.Application.Features.Auth.Exceptions
{
    public partial class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Istifadeci adi ve ya sifre yalnisdir ") { }

    }
}
