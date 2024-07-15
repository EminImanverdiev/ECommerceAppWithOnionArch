using OnionApi.Application.Bases;

namespace OnionApi.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("Bele bir email adress tapilmadi") { }

    }
}
