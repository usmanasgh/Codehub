using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHub.NetCore5.Models
{
    /// <summary>
    /// MUA : This class is created to extend IdentityUser class
    /// We are going to replace all reference of IdentityUser class in project.
    /// One can use the original IdentityUser class or derived class.
    /// </summary>
    public class CustomIdentityUser : IdentityUser
    {
        public string City { get; set; }
    }
}
