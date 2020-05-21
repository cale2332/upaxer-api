using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entities;
using WebApp.DataTransferObjects;
using WebApp.Services.DataTransferObjects.Responses;

namespace WebApp.Services
{
    public interface ISecurityManagerService
    {
        Task<AppUserSingle> GetUserWithClaims(AppUserSingle appUserSingle);
        Task<AppUserSingle> GetUser(Guid id);
    }
}
