﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Models;

namespace CodeHub.NetCore5.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
    }
}