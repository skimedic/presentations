// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - OrderRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.EfStructures;
using AutoLot.Models.Entities;
using AutoLot.Dal.Repos.Base;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Repos
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        public OrderRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal OrderRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public IEnumerable<Order> GetOrdersByMake(int makeId)
        {
            var orderByMake = Table
                .IgnoreQueryFilters()
                .Include(c => c.CarNavigation).ThenInclude(m=>m.MakeNavigation)
                .Where(o=>o.CarNavigation.MakeNavigation.Id == makeId);
            var q = orderByMake.ToQueryString();
            return orderByMake;
        }

    }
}