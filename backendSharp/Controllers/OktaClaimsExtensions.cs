using System.Security.Claims;

namespace Trowoo.Controllers
{
    public static class OktaClaimsExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue("uid");
        }
    }
}