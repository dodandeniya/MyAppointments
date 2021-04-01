using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(300)]
        public string DisplayName { get; set; }
        public int? UserType { get; set; }
        public DateTime? DOB { get; set; }
        public string Address { get; set; }
        public int? Gender { get; set; }

        [JsonIgnore]
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}