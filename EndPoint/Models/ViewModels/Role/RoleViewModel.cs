using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace  EndPoint.Models.ViewModels.Role
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "نقش")]

        public string Name { get; set; }
        [Display(Name = "توضیح")]
        public string Description { get; set; }
    }
}
