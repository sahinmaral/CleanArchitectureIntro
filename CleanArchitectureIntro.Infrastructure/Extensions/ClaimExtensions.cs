using System.Security.Claims;

namespace CleanArchitectureIntro.Infrastructure.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
