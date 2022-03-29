using BlazorWebAssemblyApp.Shared.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<User>>("/api/users");
        }

        Task<User> IUserService.AddUser(User user)
        {
            throw new NotImplementedException();
        }

        Task IUserService.DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IUserService.Search(string username, string email)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
