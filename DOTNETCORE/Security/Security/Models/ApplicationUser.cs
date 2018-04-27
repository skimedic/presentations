using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Security.Models
{
    public class ApplicationUserLogin : IdentityUserLogin<int>
    {

    }

    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {

    }

    public class ApplicationUserToken : IdentityUserToken<int>
    {

    }

    public class ApplicationUserClaim : IdentityUserClaim<int>
    {

    }
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
        //[InverseProperty(nameof(ApplicationUserRole.User))]
        public IList<ApplicationUserRole> UserRoles { get; set; }
    }
    public class ApplicationRole : IdentityRole<int>
    {
        //[InverseProperty(nameof(ApplicationUserRole.Role))]
        public IList<ApplicationUserRole> UserRoles { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {
        //[ForeignKey(nameof(ApplicationUserRole.UserId))]
        public ApplicationUser User { get; set; }
        //[ForeignKey(nameof(ApplicationUserRole.RoleId))]
        public ApplicationRole Role { get; set; }
    }

}
