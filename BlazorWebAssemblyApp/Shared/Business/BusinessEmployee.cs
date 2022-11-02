using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Shared.Business
{
    public class BusinessEmployee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "FirstName must contains at least 2 charcters")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public BusinessGender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public BusinessDepartment Department { get; set; }
    }
}
