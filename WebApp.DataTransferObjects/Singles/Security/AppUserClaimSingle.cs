﻿namespace WebApp.Services.DataTransferObjects
{
    public class AppRoleClaimSingle
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public byte RoleId { get; set; }


    }
}
