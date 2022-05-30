using  EndPoint.Models.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace  EndPoint.Models.ViewModels.User
{
    public class UserRoleAssignmentViewModel
    {
        [Display(Name = "شناسه کاربر")]
        public string Id { set; get; }
        [Display(Name = "نام کاربری")]
        public string UserName { set; get; }
        [Display(Name = "نقش های تخصیص داده شده")]
        public List<RoleViewModel> CurrentRoles { set; get; }
    }
}
