using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models.ViewModels
{
    public class ApplicationUserViewModel
    {
        public ApplicationUser User { get;set; }
        public IList<ApplicationRole> Roles { get;set; }
        public IList<ClaimViewModel> ClaimViewModels { get;set; }
    }
}
