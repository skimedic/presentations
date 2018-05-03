using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Security.Models
{
    //IRL these should be separate files

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public ApplicationUser User { get; set; }
    }

    public class ApplicationUserToken : IdentityUserToken<int>
    {
        public ApplicationUser User { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public ApplicationUser User { get; set; }
    }
    public class ApplicationUser : IdentityUser<int>
    {
        public IList<ApplicationUserRole> UserRoles { get; set; }
        public IList<ApplicationUserClaim> UserClaims { get; set; }
        public IList<ApplicationUserToken> UserTokens { get; set; }
        public IList<ApplicationUserLogin> UserLogins { get; set; }
    }
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }

    public class ApplicationRole : IdentityRole<int>
    {
        public IList<ApplicationUserRole> UserRoles { get; set; }
        public IList<ApplicationRoleClaim> RoleClaims { get; set; }
    }
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        public ApplicationRole Role { get; set; }
    }


}
