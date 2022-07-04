using Domain.BusinessObjects;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.IdentityCoreConfiguration
{
    public class IdentityCoreHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public IdentityCoreHelper(UserManager<User> userManager,
                                  SignInManager<User> signInManager,
                                  RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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


            var result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                result.ToString();
            }
            else
            {
                result.ToString();
            }

            foreach (var item in result.Errors)
            {
               
            }
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
