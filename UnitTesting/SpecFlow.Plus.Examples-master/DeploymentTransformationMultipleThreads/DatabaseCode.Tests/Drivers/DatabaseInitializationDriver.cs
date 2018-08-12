using System.Linq;
using DatabaseCode.Tests.Support;
using TechTalk.SpecFlow;

namespace DatabaseCode.Tests.Drivers
{
    public class DatabaseInitializationDriver
        : DatabaseDriverBase
    {
        public DatabaseInitializationDriver(DatabaseContextWrapper dbContext, DriverPersonState state)
            : base(dbContext, state)
        {
        }

        public void CreateEmptyDatabase()
        {
            DbContext.DatabaseContext.Persons.RemoveRange(DbContext.DatabaseContext.Persons.ToArray());
            DbContext.DatabaseContext.SaveChanges();
        }

        public void CreateDatabaseFromTable(Table personsTable)
        {
            var persons = from r in personsTable.Rows
                          select r.ToPerson();

            DbContext.DatabaseContext.Persons.AddRange(persons);
            DbContext.DatabaseContext.SaveChanges();
        }
    }
}
