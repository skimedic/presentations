using System;
using System.Linq;
using DatabaseCode.Tests.Support;
using FluentAssertions;

namespace DatabaseCode.Tests.Drivers
{
    public class DatabaseModficationDriver
        : DatabaseDriverBase
    {
        private readonly DatabaseReadDriver _readDriver;

        public DatabaseModficationDriver(DatabaseContextWrapper dbContext, DriverPersonState state, DatabaseReadDriver readDriver)
            : base(dbContext, state)
        {
            _readDriver = readDriver;
        }

        public void SaveAndCommit()
        {
            DbContext.DatabaseContext.SaveChanges();
        }

        public void InsertPerson(string firstName, string lastName)
        {
            State.StoredPerson = new Person { FirstName = firstName, LastName = lastName };
            DbContext.DatabaseContext.Persons.Add(State.StoredPerson);
        }

        public void ClearPersons()
        {
            DbContext.DatabaseContext.Persons.RemoveRange(DbContext.DatabaseContext.Persons.ToArray());
        }

        public void DeletePerson(string firstName, string lastName)
        {
            _readDriver.GetPerson(firstName, lastName);
            State.StoredPerson.Should().NotBeNull();
            DbContext.DatabaseContext.Persons.Remove(State.StoredPerson);
        }

        public void ChangeFirstName(string firstName)
        {
            State.StoredPerson.FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        {
            State.StoredPerson.LastName = lastName;
        }

        public void SaveAndCommitThrowsException<T>() where T : Exception
        {
            Action action = SaveAndCommit;
            action.Should().Throw<T>();
        }
    }
}
