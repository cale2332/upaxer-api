// ReSharper disable once CheckNamespace
using System;

namespace WebApp.DataTransferObjects
{
    public class AppUserSingle
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public bool IsAutoPassword { get; set; }
        //public bool RequirePasswordChange { get; set; }
        //public string CustomerId { get; set; }
        //public RoleSingle Role { get; set; }
        //public string PropertyId { get; set; }
        public bool Active { get; set; }
        public bool Exist { get; set; }

    }

    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public bool IsAutoPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAutoPassword { get; set; }
        public bool RequirePasswordChange { get; set; }
    }

    public class AppUserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte RoleId { get; set; }

    }

}