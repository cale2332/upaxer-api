using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Data.Repositories
{

    public interface ISecurityManagerRepository
    {
        Task<AppUser> GetUser(AppUser appUser);
        Task<AppUser> GetUser(Guid id);
        Task<bool> ValidateUser(string userName);
        Task<AppUser> GetUserByEmail(string email);
        Task<AppUser> GetUserByEmailAndPassword(string userName, string password);
        Task<bool> AddUser(AppUser user);
        Task<bool> UpdateUser(AppUser user);
        Task<bool> SaveUser();
    }
}
