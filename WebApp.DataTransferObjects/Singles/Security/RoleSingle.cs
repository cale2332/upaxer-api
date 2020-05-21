using System.Collections.Generic;

namespace WebApp.Services.DataTransferObjects
{
    public class RoleSingle
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public IList<AppRoleClaimSingle> Claims { get; set; }
    }

}