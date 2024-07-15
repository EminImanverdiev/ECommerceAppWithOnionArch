using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionApi.Application.Bases;
using OnionApi.Application.Features.Auth.Rules;
using OnionApi.Application.Interfaces.AutoMapper;
using OnionApi.Application.Interfaces.Tokens;
using OnionApi.Application.Interfaces.UnitOfWorks;
using OnionApi.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static OnionApi.Application.Features.Auth.Exceptions.EmailOrPasswordShouldNotBeInvalidException;

namespace OnionApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler,IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthRules _authRules;
        private readonly ITokenService _tokenService;
        public RefreshTokenCommandHandler(IMapper mapper,AuthRules authRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ITokenService tokenService, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _authRules = authRules;
            _tokenService = tokenService;
            _userManager = userManager;
        }
        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);
            User? user = await _userManager.FindByEmailAsync(email);
            IList<string> roles = await _userManager.GetRolesAsync(user);
           
           await  _authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpireTime);
            JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user,roles  );
            string newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);
            return new ()
            { 
                AccessToken=new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken=newRefreshToken,
            };



        }
    }
}
