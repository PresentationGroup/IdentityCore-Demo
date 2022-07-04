using Domain.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Configuration.Config
{
    public interface IAuthenticationConfig
    {
        public void RegisterUser(UserModel model, string HelperType);

    }
}
