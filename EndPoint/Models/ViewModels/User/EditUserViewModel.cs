using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace  EndPoint.Models.ViewModels.User
{
    public class EditUserViewModel
    {
        public string Id { set; get; }

        [Display(Name = "نام")]
        public string FullName { set; get; }
        [Display(Name = "نام کاربری")]
        public string UserName { set; get; }
        [Display(Name = "ایمیل")]
        public string Email { set; get; }
        [Display(Name = "تلفن همراه")]
        public string PhoneNumber { set; get; }
    }
}
