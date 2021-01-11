using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.EfStructures;
using AutoLot.Models.Entities;
using AutoLot.Dal.Repos.Base;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Repos
{
    public class CustomerRepo : BaseRepo<Customer>, ICustomerRepo
    {
        public CustomerRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal CustomerRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override IEnumerable<Customer> GetAll()
            => Table.Include(c => c.Orders).OrderBy(o => o.PersonalInformation.LastName);
    }
}