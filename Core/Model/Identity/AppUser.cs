using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Addres { get; set; }
    }
}
