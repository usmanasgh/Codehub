using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHub.NetCore5.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [NotMapped]
        public string EncryptedId { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }
        [Required]
        public DepartmentEnum? Department { get; set; }
        public string Gender { get; set; }
        public string PhotoPath { get; set; }

        //public List<IFormFile> Photos { get; set; } // MUA : For multiple files
    }
}
