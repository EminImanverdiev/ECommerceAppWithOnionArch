using OnionApi.Application.Bases;

namespace OnionApi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalid : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalid() : base("Istifadeci adi ve ya sifre yalnisdir ") { }
    }
}
