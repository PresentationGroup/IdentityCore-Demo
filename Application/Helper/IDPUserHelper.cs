using IdentityServer4.Test;
using Application.Interfaces.Helper;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public class IDPUserHelper : IHelperIDP
    {
        public IDPUserHelper(List<User> users) { }
        public User AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public User FindByExternalProvider(string provider, string userId)
        {
            throw new NotImplementedException();
        }

        public User FindBySubjectId(string subjectId)
        {
            throw new NotImplementedException();
        }

        public User FindByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public bool ValidateCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
