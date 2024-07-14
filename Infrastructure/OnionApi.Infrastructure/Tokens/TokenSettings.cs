namespace OnionApi.Infrastructure.Tokens
{
    public class TokenSettings
    { 
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public string TokenValidityInMinutues { get; set; }
    }
}
