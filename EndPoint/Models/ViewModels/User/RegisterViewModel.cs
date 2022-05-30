using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace  EndPoint.Models.ViewModels.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="لطفا نام و نام خانوادگی را وارد نمایید.")]
        [Display(Name ="نام و نام خانوادگی")]
        [MaxLength(100, ErrorMessage ="نام و نام خانوادگی نمی نواند بیش از 100 کاراکتر باشد!")]
        public string FullName { get; set; }
       
        [Required(ErrorMessage = "نام کاربری را وارد نمایید")]
        [DataType(DataType.Text)]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage = "پسورد را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار پسورد را وارد نمایید")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "پسورد و تکرار آن باید برابر باشد")]
        [Display(Name = "تکرار پسورد")]
        public string RePassword { get; set; }


        [Required(ErrorMessage = "شماره موبایل را وارد نمایید")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره موبایل")] 
        public string PhoneNumber { get; set; }


    }
}
