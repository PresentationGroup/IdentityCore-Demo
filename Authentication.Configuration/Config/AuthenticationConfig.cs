using Domain.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Configuration.Config
{
    public class AuthenticationConfig: IAuthenticationConfig
    {
        Authentication.IdentityCoreConfiguration.IdentityCoreHelper _identityCoreHelper;
        Authentication.DapperConfiguration.DapperHelper _dapperHelper;
        public AuthenticationConfig(Authentication.IdentityCoreConfiguration.IdentityCoreHelper identityCoreHelper
                                    , Authentication.DapperConfiguration.DapperHelper dapperHelper)
        {
            _identityCoreHelper = identityCoreHelper;
            _dapperHelper = dapperHelper;
        }

        //todo.. HelperType should be a Enum
        public void RegisterUser(UserModel model, string HelperType)
        {
            if (HelperType == "Dapper")
            {
                _dapperHelper.Register(model);
            }
            else if (HelperType =="IdentityCore")
            {
                _identityCoreHelper.Register(model);
            }
        }
    }
    
}
