using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Common;

namespace WebApp.Entities
{

  public class AppUser : AuditableEntity<Guid>
    {

        [Required()]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required()]
        [StringLength(255)]
        public string Password { get; set; }

        //public string CustomerId { get; set; }

        //public byte RoleId { get; set; }
        //public AppRole Role { get; set; }

        //public AppUserAuth UserAuth { get; set; }
       
        
    }
}
