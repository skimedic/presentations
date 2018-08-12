using System.Linq;
using DatabaseCode.Tests.Support;
using FluentAssertions;

namespace DatabaseCode.Tests.Drivers
{
    public class DatabaseReadDriver
        : DatabaseDriverBase
    {
        public DatabaseReadDriver(DatabaseContextWrapper dbContext, DriverPersonState state)
            : base(dbContext, state)
        {
        }

        public void GetPerson(string firstName, string lastName)
        {
            State.StoredPerson = DbContext.DatabaseContext.Persons.Single(
                p => p.FirstName == firstName && p.LastName == lastName);
        }

        public void ShouldContainPerson(string firstName, string lastName)
        {
            DbContext.DatabaseContext.Persons.Should().Contain(
                p => p.FirstName == firstName && p.LastName == lastName);
        }

        public void ShouldBeEmpty()
        {
            DbContext.DatabaseContext.Persons.Should().BeEmpty();
        }

        public void ShouldNotContainPerson(string firstName, string lastName)
        {
            DbContext.DatabaseContext.Persons.Should().NotContain(
                p => p.FirstName == firstName && p.LastName == lastName);
        }
    }
}
