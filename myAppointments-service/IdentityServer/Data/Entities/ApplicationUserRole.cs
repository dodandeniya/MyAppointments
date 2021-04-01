using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Data.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}