using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Shared.Business
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }

        // Foreign key   
        [Display(Name = "Role")]
        public virtual int RoleId { get; set; }

        //[ForeignKey("RoleId")]
        //public virtual Role Roles { get; set; }
    }
}
