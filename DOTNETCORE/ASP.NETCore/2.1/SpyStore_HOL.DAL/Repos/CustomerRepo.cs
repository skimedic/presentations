using System.Collections.Generic;
using System.Linq;
using SpyStore_HOL.DAL.EfStructures;
using SpyStore_HOL.DAL.Repos.Base;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.Models.Entities;

namespace SpyStore_HOL.DAL.Repos
{
    public class CustomerRepo : RepoBase<Customer>, ICustomerRepo
    {
        public CustomerRepo() : base() { }
        public CustomerRepo(StoreContext context) : base(context) { }
        public override IList<Customer> GetAll() => Table.OrderBy(x => x.FullName).ToList();
    }
}