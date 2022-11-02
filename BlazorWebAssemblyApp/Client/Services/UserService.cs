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
        public async Task<IEnumerable<BusinessUser>> GetUsers()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<BusinessUser>>("/api/users");
        }

        Task<BusinessUser> IUserService.AddUser(BusinessUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserService.DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        Task<BusinessUser> IUserService.GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        Task<BusinessUser> IUserService.GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<BusinessUser>> IUserService.Search(string username, string email)
        {
            throw new NotImplementedException();
        }

        Task<BusinessUser> IUserService.UpdateUser(BusinessUser user)
        {
            throw new NotImplementedException();
        }
    }
}
