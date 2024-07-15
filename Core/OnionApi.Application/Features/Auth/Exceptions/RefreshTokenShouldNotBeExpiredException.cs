using OnionApi.Application.Bases;

namespace OnionApi.Application.Features.Auth.Exceptions
{
    public partial class EmailOrPasswordShouldNotBeInvalidException
    {
        public class RefreshTokenShouldNotBeExpiredException : BaseException
        {
            public RefreshTokenShouldNotBeExpiredException() : base("Yeniden login olun zehmet olmazsa :) ") { }
        }

    }
}
