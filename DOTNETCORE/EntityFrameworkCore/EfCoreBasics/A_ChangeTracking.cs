// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ChangeTracking.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfCoreBasics.EfStructures;
using EfCoreBasics.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfCoreBasics
{
    public class ChangeTracking
    {
        private AwDbContext _context = null;

        public ChangeTracking()
        {
        }

        public void ProcessCrudOperations()
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
            _context.Person.Remove(person);
            return _context.ChangeTracker.Entries().First();
        }

        internal EntityEntry EditEntity()
        {
            Console.WriteLine("*** Edit Entity *** ");
            var person = _context.Person.Find(2);
            person.LastName = "Flinstone";
            return _context.ChangeTracker.Entries().First();
        }

        internal EntityEntry GetEntity()
        {
            Console.WriteLine("*** Get Entity *** ");
            var person = _context.Person.Find(1);
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