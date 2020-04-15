// Copyright Information
// ==================================
// Channel9 - EfCore - A_ChangeTracking.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/10
// See License.txt for more information
// ==================================

using System;
using System.Linq;
using EfCore.EfStructures;
using EfCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfCore
{
    public class ChangeTracking
    {
        private AwDbContext _context = null;

        public ChangeTracking()
        {
        }

        public void RunSamples()
        {
            ResetContext();
            Console.WriteLine("*** Create new entity ***");
            var person = new Person
            {
                AdditionalContactInfo = "Home",
                FirstName = "Barney",
                LastName = "Rubble",
                Title = "Neighbor"
            };
            var newEntityEntry = _context.Entry(person);
            DisplayEntityStatus(newEntityEntry);


            //Don't need to reset context since context is still clean
            //ResetContext();
            DisplayEntityStatus(GetEntity());

            ResetContext();

            DisplayEntityStatus(AddEntity(person));

            ResetContext();
            DisplayEntityStatus(DeleteEntity());

            ResetContext();
            EntityEntry entry = EditEntity();
            DisplayEntityStatus(entry);
            DisplayModifiedPropertyStatus(entry);
        }

        internal EntityEntry AddEntity(Person person)
        {
            Console.WriteLine("*** Add Entity *** ");

            _context.Person.Add(person);
            return _context.ChangeTracker.Entries().First();
        }

        internal EntityEntry DeleteEntity()
        {
            Console.WriteLine("*** Delete Entity *** ");
            var person = _context.Person.Find(1);
            //This isn't in memory -> retrieved from database
            _context.Entry(person).State = EntityState.Deleted;
            //This mus be in memory -> retrieved from database
            _context.Person.Remove(person);
            _context.SaveChanges();

            return _context.ChangeTracker.Entries().First();
        }

        internal EntityEntry EditEntity()
        {
            Console.WriteLine("*** Edit Entity *** ");
            var person = _context.Person.Find(2);
            person.LastName = "Flinstone";
            _context.Person.Update(person);
            _context.SaveChanges();
            return _context.ChangeTracker.Entries().First();
        }

        internal EntityEntry GetEntity()
        {
            Console.WriteLine("*** Get Entity *** ");
            var person = _context.Person.Find(1);
            var person2 = _context.Person.Where(x => x.BusinessEntityId == 5).AsNoTracking();
            return _context.ChangeTracker.Entries().First();
        }

        private void DisplayEntityStatus(EntityEntry entry)
        {
            Console.WriteLine($"Entity State => {entry.State}");
        }

        private void DisplayModifiedPropertyStatus(EntityEntry entry)
        {
            Console.WriteLine("*** Changed Properties");
            foreach (var prop in entry.Properties
                .Where(x => !x.IsTemporary && x.IsModified))
            {
                Console.WriteLine(
                    $"Property: {prop.Metadata.Name}\r\n\t Orig Value: {prop.OriginalValue}\r\n\t Curr Value: {prop.CurrentValue}");
            }
        }

        private void ResetContext()
        {
            _context = new AwDbContextFactory().CreateDbContext(null);
        }
    }
}