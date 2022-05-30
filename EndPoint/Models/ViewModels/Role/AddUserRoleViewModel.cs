using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Models.ViewModels.Role
{
    public class AddUserRoleViewModel
    {
       
        [Display(Name = "نام کاربر")]
        public string UserName { set; get; }
        [Display(Name = "شناسه کاربری")]
        public string Id { set; get; }
        [Display(Name = "نقش")]
        public string Role { set; get; }
        [Display(Name = " عنوان نقش")]
        public string Description { set; get; }
        [Display(Name = "لیست نقشها")]
        public List<SelectListItem> Roles { set; get; }


    }
}
