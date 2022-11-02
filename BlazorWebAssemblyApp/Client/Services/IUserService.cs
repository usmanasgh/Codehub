﻿using BlazorWebAssemblyApp.Shared.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Client.Services
{
    public interface IUserService
    {
        Task<IEnumerable<BusinessUser>> Search(string username, string email);
        Task<IEnumerable<BusinessUser>> GetUsers();
        Task<BusinessUser> GetUser(Guid userId);
        Task<BusinessUser> GetUserByUsername(string username);
        Task<BusinessUser> AddUser(BusinessUser user);
        Task<BusinessUser> UpdateUser(BusinessUser user);
        Task DeleteUser(Guid userId);
    }
}
