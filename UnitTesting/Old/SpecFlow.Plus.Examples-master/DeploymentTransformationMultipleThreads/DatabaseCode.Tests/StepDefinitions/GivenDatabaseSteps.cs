using DatabaseCode.Tests.Drivers;
using TechTalk.SpecFlow;

namespace DatabaseCode.Tests.StepDefinitions
{
    [Binding]
    public class GivenDatabaseSteps
    {
        private readonly DatabaseInitializationDriver _initializationDriver;
        private readonly DatabaseReadDriver _readDriver;

        public GivenDatabaseSteps(DatabaseInitializationDriver initializationDriver, DatabaseReadDriver readDriver)
        {
            _initializationDriver = initializationDriver;
            _readDriver = readDriver;
        }

        [Given(@"I have an empty database")]
        public void GivenIHaveAnEmptyDatabase()
        {
            _initializationDriver.CreateEmptyDatabase();
        }

        [Given(@"I have a database containing the following persons:")]
        public void GivenIHaveADatabaseContainingTheFollowingPersons(Table personsTable)
        {
            _initializationDriver.CreateDatabaseFromTable(personsTable);
        }

        [Given(@"I get the person '(.*)' '(.*)' from the database")]
        public void GivenIGetThePersonFromTheDatabase(string firstName, string lastName)
        {
            _readDriver.GetPerson(firstName, lastName);
        }
    }
}
