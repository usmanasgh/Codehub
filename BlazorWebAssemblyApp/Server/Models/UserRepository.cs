using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWebAssemblyApp.Server.Interface;
using BlazorWebAssemblyApp.Shared.Business;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyApp.Server.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<User> AddUser(User user)
        {
            if(user.Roles != null)
            {
                appDbContext.Entry(user.Roles).State = EntityState.Unchanged; // MUA: Ignore to create new entry for new roles
            }
            
            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(Guid userId)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(Guid userId)
        {
            return await appDbContext.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await appDbContext.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> Search(string username, string email)
        {
            IQueryable<User> query = appDbContext.Users;

            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(email))
            {
                query = query.Where(u => u.Username.Contains(username)
                || u.Email.Contains(email));
            }
            // MUA: if there is problem in above function, make both separate with if else

            return await query.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if(result != null)
            {
                result.Username = user.Username;
                result.Email = user.Email;
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Phone = user.Phone;
                result.RoleId = user.RoleId;
                // MUA: Check if there is any missing value

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
