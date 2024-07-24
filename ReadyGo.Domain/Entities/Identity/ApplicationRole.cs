using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ReadyGo.Domain.Entities.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
