using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Domain.Helpers
{
    public static class ClaimsPrincipleHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        public static List<Claim> generateClaimsList(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
        }

        public static string GetClaim(string claimType)
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value ?? string.Empty;
        }

        public static List<Claim>? GetClaims()
        {
            return _httpContextAccessor.HttpContext.User.Claims.ToList();
        }
    }
}
