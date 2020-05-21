using System;
using System.ComponentModel.DataAnnotations;
using WebApp.Common;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Entities
{
    //[Table("UserClaim", Schema = "Security")]
    public class AppRoleClaim : AuditableEntity<string>
    {

        [Required()]
        public byte RoleId { get; set; }

        [Required()]
        public string ClaimType { get; set; }

        [Required()]
        public string ClaimValue { get; set; }

        

    }
}
