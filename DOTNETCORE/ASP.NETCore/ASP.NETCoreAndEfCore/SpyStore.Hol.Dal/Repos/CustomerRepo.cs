using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Repos
{
   public class CustomerRepo : RepoBase<Customer>, ICustomerRepo
    {
        public CustomerRepo(StoreContext context) : base(context)
        {
        }

        internal CustomerRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public override IEnumerable<Customer> GetAll() => base.GetAll(x => x.FullName).ToList();

    }
}
