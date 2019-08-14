using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Repos.Base;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Models.Entities;

namespace SpyStore.Dal.Repos
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
