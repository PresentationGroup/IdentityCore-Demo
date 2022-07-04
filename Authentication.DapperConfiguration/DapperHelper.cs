using Domain.BusinessObjects;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DapperConfiguration
{
    public class DapperHelper
    {
        public DapperHelper()
        {

        }
        public void Register(UserModel model)
        {
            //Validate model

            //Create IdentityUser
            User user = new User()
            {
                UserName = model.UserName,
                FullName = model.FullName,
                //Email = model.Email,
                //PhoneNumber = model.PhoneNumber,
                IsDisable = false,
                SecPW = HashMD5(model.SecPW)
            };


            var result = new User();

            //Create and insert Identity User with Dapper

        }



        static string HashMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
