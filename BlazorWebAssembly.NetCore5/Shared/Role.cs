using System;
using System.Collections.Generic;
using System.Text;
using BlazorWebAssembly.NetCore5.Shared.Common;

namespace BlazorWebAssembly.NetCore5.Shared
{
    public class Role
    {
        public Enums.Role Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
