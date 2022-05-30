using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace  EndPoint.Models.ViewModels.User
{
    public class RolesInUserListViewModel
    {
        [Display(Name = "شناسه نقش")]
        public string Id { set; get; }
        [Display(Name = "نام کاربری")]
        public string UserName { set; get; }
        [Display(Name = "نام نقش")]
        public string RoleName { set; get; }
        [Display(Name = "توضیح نقش")]
        public string RoleDescription { set; get; }
        [Display(Name ="وضعیت نقش")]
        public bool IsDisable { set; get; }
    }
}
