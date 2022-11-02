using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWebAssemblyApp.Server.Interface;
using BlazorWebAssemblyApp.Shared.Business;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyApp.Server.Models
{
    public class BusinessUserRepository : IBusinessUserRepository
    {
        private readonly AppDbContext appDbContext;
        public BusinessUserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<BusinessUser> AddUser(BusinessUser user)
        {
            if(user.Roles != null)
            {
                appDbContext.Entry(user.Roles).State = EntityState.Unchanged; // MUA: Ignore to create new entry for new roles
            }
            
            var result = await appDbContext.BusinessUsers.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(Guid userId)
        {
            var result = await appDbContext.BusinessUsers
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (result != null)
            {
                appDbContext.BusinessUsers.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<BusinessUser> GetUser(Guid userId)
        {
            return await appDbContext.BusinessUsers.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<BusinessUser> GetUserByUsername(string username)
        {
            return await appDbContext.BusinessUsers.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<BusinessUser>> GetUsers()
        {
            return await appDbContext.BusinessUsers.ToListAsync();
        }

        public async Task<IEnumerable<BusinessUser>> Search(string username, string email)
        {
            IQueryable<BusinessUser> query = appDbContext.BusinessUsers;

            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(email))
            {
                query = query.Where(u => u.Username.Contains(username)
                || u.Email.Contains(email));
            }
            // MUA: if there is problem in above function, make both separate with if else

            return await query.ToListAsync();
        }

        public async Task<BusinessUser> UpdateUser(BusinessUser user)
        {
            var result = await appDbContext.BusinessUsers
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
