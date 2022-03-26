using BlazorWebAssemblyApp.Shared.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Client.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Search(string username, string email);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(Guid userId);
        Task<User> GetUserByUsername(string username);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(Guid userId);
    }
}
