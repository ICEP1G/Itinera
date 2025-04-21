using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Helpers
{
    public static class IdentityHelper
    {
        public static ClaimsPrincipal CreateFakeClaimPrincipal(string itinerosId)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, itinerosId),
                new Claim(ClaimTypes.Name, "fakeItineros")
            };

            ClaimsIdentity identity = new(claims, "FakeAuthentication");
            ClaimsPrincipal principal = new(identity);

            return principal;
        }
    }
}
