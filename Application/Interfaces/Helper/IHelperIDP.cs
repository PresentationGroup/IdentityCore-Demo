using IdentityServer4.Test;
using  Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace  Application.Interfaces.Helper
{
    public interface IHelperIDP
    {

        //
        // Summary:
        //     Automatically provisions a user.
        //
        // Parameters:
        //   provider:
        //     The provider.
        //
        //   userId:
        //     The user identifier.
        //
        //   claims:
        //     The claims.
        public User AutoProvisionUser(string provider, string userId, List<Claim> claims);
        //
        // Summary:
        //     Finds the user by external provider.
        //
        // Parameters:
        //   provider:
        //     The provider.
        //
        //   userId:
        //     The user identifier.
        public User FindByExternalProvider(string provider, string userId);
        //
        // Summary:
        //     Finds the user by subject identifier.
        //
        // Parameters:
        //   subjectId:
        //     The subject identifier.
        public User FindBySubjectId(string subjectId);
        //
        // Summary:
        //     Finds the user by username.
        //
        // Parameters:
        //   username:
        //     The username.
        public User FindByUsername(string username);
        //
        // Summary:
        //     Validates the credentials.
        //
        // Parameters:
        //   username:
        //     The username.
        //
        //   password:
        //     The password.
        public bool ValidateCredentials(string username, string password);
    }
}
