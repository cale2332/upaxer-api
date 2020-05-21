
using System.Collections.Generic;
using WebApp.Common;

namespace WebApp.Domain.Entities
{
    public class AppRole : AuditableEntity<byte>
    {
        public string Description { get; set; }
        public IList<AppRoleClaim> Claims { get; set; }
    }
}
