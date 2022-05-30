using  Domain.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace  Infrastructure.IdentityConfigs
{
    public class ClaimsCustomization: IClaimsTransformation
    {
        private readonly UserManager<User> _userManager;
        public ClaimsCustomization( UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal == null)
                return null;
            var identity = principal.Identity as ClaimsIdentity;
            if (identity == null) return null;
            
            //Fetch Claims {now is hardCode but should fetch from DB //todo.. }
            //Add Claims

            var user =_userManager.FindByNameAsync(identity.Name).Result;
            identity.AddClaim(new Claim("FullName", user.FullName, ClaimValueTypes.String));
          
            return Task.FromResult(principal);
        }
    }
}
