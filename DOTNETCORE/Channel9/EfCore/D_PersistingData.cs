// Copyright Information
// ==================================
// Channel9 - EfCore - D_PersistingData.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/10
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using EfCore.EfStructures;
using EfCore.Entities;

namespace EfCore
{
    public class PersistingData
    {
        private AwDbContext _context = null;

        public PersistingData()
        {
            ResetContext();
        }

        public void RunSamples()
        {
            AddAnItem();
            AddItems();
            AddAnObjectGraph();
        }
        public void AddAnItem()
        {
            ShouldExecuteInATransaction(AddNewPerson);

            void AddNewPerson()
            {
                var person = new Person
                {
                    AdditionalContactInfo = "Home",
                    FirstName = "Barney",
                    LastName = "Rubble",
                    Title = "Neighbor"
                };
                _context.Person.Add(person);
                _context.SaveChanges();
            }
        }

        public void AddAnObjectGraph()
        {
            ShouldExecuteInATransaction(AddNewPerson);

            void AddNewPerson()
            {
                var person = new Person
                {
                    AdditionalContactInfo = "Home",
                    FirstName = "Barney",
                    LastName = "Rubble",
                    Title = "Neighbor"
                };
                person.EmailAddress.Add(new EmailAddress
                {
                    EmailAddress1 = "foo@foo.com"
                });
                _context.Person.Add(person);
            }
        }

        public void AddItems()
        {
            ShouldExecuteInATransaction(AddNewPerson);

            void AddNewPerson()
            {
                var list = new List<Person>
                {
                    new Person
                    {
                        AdditionalContactInfo = "Home",
                        FirstName = "Barney",
                        LastName = "Rubble",
                        Title = "Neighbor"
                    },
                    new Person
                    {
                        AdditionalContactInfo = "Home",
                        FirstName = "Barney",
                        LastName = "Rubble",
                        Title = "Neighbor"
                    }
                };
                _context.Person.AddRange(list);
            }
        }

        public void ShouldExecuteInATransaction(Action actionToExecute)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                actionToExecute();
                transaction.Rollback();
            }
        }

        private void ResetContext()
        {
            _context = new AwDbContextFactory().CreateDbContext(null);
        }
    }
}