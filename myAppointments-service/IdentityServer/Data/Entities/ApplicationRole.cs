using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityServer.Data.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
