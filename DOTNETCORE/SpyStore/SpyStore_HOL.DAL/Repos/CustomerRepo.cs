using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore_HOL.DAL.EF;
using SpyStore_HOL.DAL.Repos.Base;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.Models.Entities;

namespace SpyStore_HOL.DAL.Repos
{
    public class CustomerRepo : RepoBase<Customer>, ICustomerRepo
    {
        public CustomerRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public CustomerRepo() : base()
        {
        }

        public override IEnumerable<Customer> GetAll()
            => Table.OrderBy(x => x.FullName);

        public override IEnumerable<Customer> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.FullName), skip, take);

    }
}
