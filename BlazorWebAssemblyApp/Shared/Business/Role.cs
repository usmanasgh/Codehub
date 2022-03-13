using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWebAssemblyApp.Shared.Common;

namespace BlazorWebAssemblyApp.Shared.Business
{
    public class Role
    {
        public Enums.Role Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
