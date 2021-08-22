using System;
using Microsoft.AspNetCore.Identity;

namespace ConfArch.Web
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CareerStartedDate { get; set; }
        public string FullName { get; set; }
    }
}
