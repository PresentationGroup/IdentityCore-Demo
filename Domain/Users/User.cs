using  Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace  Domain.Users
{
    [Auditable]
    public class User: IdentityUser
    {
        public string FullName { get; set; }
        public bool IsDisable { get; set; } 
        public DateTime? DisableDate { get; set; }  
    }
}
