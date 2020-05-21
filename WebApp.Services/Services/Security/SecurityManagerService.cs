using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Common.Helpers;
using WebApp.Entities;
using WebApp.DataTransferObjects;
using WebApp.Services.DataTransferObjects.Responses;
using WebApp.Services;
using WebApp.Data.Repositories;
using System;

namespace WebApp.Services
{
    public class SecurityManagerService : ISecurityManagerService
    {
        private readonly ISecurityManagerRepository _securityManagerRepository;
        private readonly IMapper _mapper;
        public SecurityManagerService(ISecurityManagerRepository securityManagerRepository, IMapper mapper)
        {
            this._securityManagerRepository = securityManagerRepository;
            this._mapper = mapper;
        }

        #region PRIVATE METHODS

        private async Task<PasswordResponse> UpdatePassword(AppUser appUser, string password, bool isAutoPassword, bool requirePasswordChange)
        {
            KeyValuePair<string, string> passwordResult;
            var response = new PasswordResponse();

            if (appUser != null)
            {
                passwordResult = RandomGenerator.EncryptPassword(password, isAutoPassword);
                appUser.Password = passwordResult.Value;
                await _securityManagerRepository.UpdateUser(appUser);
                await _securityManagerRepository.SaveUser();

                //Response
                response.Success = true;
                response.Email = appUser.UserName;
                response.Password = passwordResult.Key;
            }
            else
            {
                response.Message = "No se pudo resetear/cambiar el Password";
            }


            return response;
        }

        #endregion

        #region PUBLIC METHODS

        public async Task<AppUserSingle> GetUserWithClaims(AppUserSingle appUserSingle)
        {
            var appUserMap = _mapper.Map<AppUser>(appUserSingle);
            AppUser appUser = await this._securityManagerRepository.GetUser(appUserMap);
            if (appUser != null)
            {
                appUserSingle.Id = appUser.Id;
                appUserSingle.Active = appUser.Active;
                appUserSingle.Exist = true;
            }
            else
                appUserSingle.Exist = false;
            return appUserSingle;
        }

        public async Task<AppUserSingle> GetUser(Guid id)
        {
            
            AppUser appUser = await this._securityManagerRepository.GetUser(id);
            var appUserSingle = _mapper.Map<AppUserSingle>(appUser);
            return appUserSingle;
        }

        //public async Task<PasswordResponse> ChangePassword(ChangePasswordViewModel request)
        //{
        //    var passwordEncrypted = Protector.Encrypt(request.CurrentPassword, string.Empty);
        //    var appUser = await this._securityManagerRepository.GetUserByEmailAndPassword(request.UserName, passwordEncrypted);
        //    return await UpdatePassword(
        //       appUser,
        //       request.NewPassword,
        //       request.IsAutoPassword,
        //       false);
        //}

        //public async Task<PasswordResponse> ResetPassword(ResetPasswordViewModel request)
        //{
        //    var appUser = await this._securityManagerRepository.GetUserByEmail(request.UserName);
        //    return await UpdatePassword(
        //        appUser,
        //        request.Password,
        //        request.IsAutoPassword,
        //        request.RequirePasswordChange);
        //}

        #endregion
    }
}
