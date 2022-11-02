using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWebAssemblyApp.Shared.Common;

namespace BlazorWebAssemblyApp.Shared.Business
{
    public class BusinessRole
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
