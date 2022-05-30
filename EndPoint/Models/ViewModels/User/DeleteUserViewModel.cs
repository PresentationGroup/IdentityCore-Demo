using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Models.ViewModels.User
{
    public class DeleteUserViewModel
    {
        public string Id { set; get; }

        [Display(Name = "نام کاربری")]
        public string UserName { set; get; }
        public bool IsDisable { set; get; }
        public DateTime DisableDate { set; get; }
    }
}
