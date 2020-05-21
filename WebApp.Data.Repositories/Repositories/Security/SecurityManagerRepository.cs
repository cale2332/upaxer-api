using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Common.Helpers;
using WebApp.Data.Repository.Repositories;
using WebApp.Entities;

namespace WebApp.Data.Repositories
{
    public class SecurityManagerRepository : GenericRepository<AppUser>, ISecurityManagerRepository
    {
        public SecurityManagerRepository(DbContext context)
           : base(context)
        {

        }

        public async Task<AppUser> GetUser(AppUser appUser)
        {
            // Attempt to validate user
            var passwordEncrypted = Protector.Encrypt(appUser.Password, string.Empty);
            var userClaims =  FindEntityBy(u => u.UserName.ToLower() == appUser.UserName.ToLower()
               && u.Password == passwordEncrypted);

            return userClaims;
        }

        public async Task<AppUser> GetUser(Guid id)
        {
            // Attempt to validate user
            var userClaims = FindEntityBy(u => u.Id == id);

            return userClaims;
        }

        public async Task<bool> ValidateUser(string userName)
        {
            // validate user
            var user =  FindEntityBy(u => u.UserName.ToLower() == userName.ToLower());
            return user != null;
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            var user =  FindEntityBy(u => u.UserName.ToLower() == email.ToLower());
            return user;
        }

        public async Task<AppUser> GetUserByEmailAndPassword(string email, string password)
        {
            var user =  FindEntityBy(u => u.UserName.ToLower() == email.ToLower() && u.Password == password);
            return user;
        }

        public async Task<bool> AddUser(AppUser user)
        {
            this.Add(user);
            return true;
        }

        public async Task<bool> UpdateUser(AppUser user)
        {
            this.Edit(user);
            return true;
        }
        public async Task<bool> SaveUser()
        {
            this.Save();
            return true;
        }
    }


}
