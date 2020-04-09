// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - RelatedDataAndProjections.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/09
// See License.txt for more information
// ==================================

using System.Collections.Generic;
using System.Linq;
using EfCoreBasics.EfStructures;
using EfCoreBasics.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreBasics
{
    public class RelatedDataAndProjections
    {
        private AwDbContext _context = null;

        public RelatedDataAndProjections()
        {
            ResetContext();
        }
        private void ResetContext()
        {
            _context = new AwDbContextFactory().CreateDbContext(null);
        }
        public void RunSamples()
        {
            GetPersonAndRelatedData();
            CreateProjections();
            ExplicitlyLoadRelatedData();
        }

        internal void GetPersonAndRelatedData()
        {
            //Get collections (many of many to one)
            _ = _context.Person.Include(x => x.EmailAddress);
            //Get Parent (one of many to one)
            _ = _context.Person.Include(x => x.BusinessEntity);
            //Get Chain of related
            _ = _context.Person
                .Include(x => x.Employee)
                .ThenInclude(x => x.SalesPerson);
        }

        internal void ExplicitlyLoadRelatedData()
        {
            var p = _context.Person.FirstOrDefault(x => x.BusinessEntityId == 1);
            _context.Entry(p).Reference(p=>p.Employee).Load();
            _context.Entry(p).Collection(p=>p.EmailAddress).Load();
        }
        internal void CreateProjections()
        {
            //Create list of anonymous objects
            var newAnonList = _context.Person
                .Select(x=> new
                {
                    x.FirstName,
                    x.MiddleName,
                    x.LastName
                })
                .ToList();
            IQueryable<ICollection<EmailAddress>> result1 = _context.Person.Select(x => x.EmailAddress);
            //Select Many flattens the list
            IQueryable<EmailAddress> result2 = _context.Person.SelectMany(x => x.EmailAddress);

            //Project to a ViewModel
            var newVMList = _context.Person
                .Select(x=> new PersonViewModel
                {
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName
                })
                .ToList();
        }
    }

    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}