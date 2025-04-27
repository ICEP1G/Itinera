using Itinera.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Models
{
    public static class CurrentItinerosSession
    {
        public static ClaimsPrincipal Session { get; private set; }
        static CurrentItinerosSession()
        {
            Session = IdentityHelper.CreateFakeClaimPrincipal("1");
        }


        public static string CurrentItinerosId
        {
            get
            {
                Claim? claim = Session.FindFirst(ClaimTypes.NameIdentifier);
                return claim?.Value;
            }
            set { Session = IdentityHelper.CreateFakeClaimPrincipal("1"); }
        }


        public static void SetClaimsPrincipal(ClaimsPrincipal claimsPrincipal) => Session = claimsPrincipal;
    }
}
