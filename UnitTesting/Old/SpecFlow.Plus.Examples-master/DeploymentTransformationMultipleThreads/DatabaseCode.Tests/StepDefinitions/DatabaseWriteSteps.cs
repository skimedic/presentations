using System;
using DatabaseCode.Tests.Drivers;
using TechTalk.SpecFlow;

namespace DatabaseCode.Tests.StepDefinitions
{
    [Binding]
    public class DatabaseWriteSteps
    {
        private readonly DatabaseModficationDriver _writeDriver;
        private readonly DatabaseReadDriver _readDriver;

        public DatabaseWriteSteps(DatabaseModficationDriver writeDriver, DatabaseReadDriver readDriver)
        {
            _writeDriver = writeDriver;
            _readDriver = readDriver;
        }

        [When(@"I insert a person '(.*)' '(.*)' into the database")]
        public void WhenIInsertAPersonCalledIntoTheDatabase(string firstName, string lastName)
        {
            _writeDriver.InsertPerson(firstName, lastName);
        }

        [When(@"I delete a person called '(.*)' '(.*)'")]
        public void WhenIDeleteAPersonCalled(string firstName, string lastName)
        {
            _writeDriver.DeletePerson(firstName, lastName);
        }

        [When(@"I change its first name to '(.*)'")]
        public void WhenIChangeItsFirstNameTo(string firstName)
        {
            _writeDriver.ChangeFirstName(firstName);
        }

        [When(@"I change its last name to '(.*)'")]
        public void WhenIChangeItsLastNameTo(string lastName)
        {
            _writeDriver.ChangeLastName(lastName);
        }

        [When(@"I remove all persons")]
        public void WhenIRemoveAllPersons()
        {
            _writeDriver.ClearPersons();
        }

        [When(@"I save and commit the changes to the database")]
        public void WhenISaveAndCommitTheChanges()
        {
            _writeDriver.SaveAndCommit();
        }

        [Then(@"the database should contain a person called '(.*)' '(.*)'\.")]
        public void ThenTheDatabaseShouldContainAPersonCalled(string firstName, string lastName)
        {
            _readDriver.ShouldContainPerson(firstName, lastName);
        }

        [Then(@"the database should not contain any person\.")]
        public void ThenTheDatabaseShouldNotContainAnyPerson()
        {
            _readDriver.ShouldBeEmpty();
        }

        [Then(@"the database should not contain a person called '(.*)' '(.*)'\.")]
        public void ThenTheDatabaseShouldNotContainAPersonCalled(string firstName, string lastName)
        {
            _readDriver.ShouldNotContainPerson(firstName, lastName);
        }

        [Then(@"saving and committing should throw an exception\.")]
        public void ThenSavingAndCommittingShouldThrowAnException()
        {
            _writeDriver.SaveAndCommitThrowsException<InvalidOperationException>();
        }
    }
}
