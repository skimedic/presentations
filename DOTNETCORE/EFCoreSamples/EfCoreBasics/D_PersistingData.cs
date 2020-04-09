// Copyright Information
// ==================================
// EFCoreExamples - 00_EfCoreBasics - PersistingData.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/09
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.Linq;
using EfCoreBasics.EfStructures;
using EfCoreBasics.Entities;

namespace EfCoreBasics
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
        private void ResetContext()
        {
            _context = new AwDbContextFactory().CreateDbContext(null);
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

        public void ShouldExecuteInATransaction(Action actionToExecute)
        {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    actionToExecute();
                    transaction.Rollback();
                }
        }
    }
}