using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Unifisio_Api.Services.Interface
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateTokenAccessToken(IEnumerable<Claim> claims, IConfiguration _config);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config);
    }
}
