using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace  EndPoint.Models.ViewModels.Role
{
    public class UsersInRoleListViewModel
    {
        [Display(Name = "شناسه کاربر")]
        public string Id { set; get; }
        [Display(Name = "نام کامل")]
        public string FullName { set; get; }
        [Display(Name = "نام کاربری")]
        public string UserName { set; get; }
        [Display(Name = "ایمیل")]
        public string Email { set; get; }
        [Display(Name = "تلفن همراه")]
        public string PhoneNumber { set; get; }
        [Display(Name = "نام نقش")]
        public string RoleName { set; get; }
        [Display(Name = "توضیح نقش")]
        public string RoleDescription { set; get; }
    }
}
