using System.Collections.Generic;

namespace WebApp.Services.DataTransferObjects.Responses
{
    public class AppUserAuth
    {
        public AppUserAuth() : base()
        {
        UserName = "Not authorized";
        BearerToken = string.Empty;
        }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; } 
        public string CustomerId { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }

        public List<AppRoleClaimSingle> Claims { get; set; }
  }

    public class PasswordResponse: BaseResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
