using TechTalk.SpecFlow;

namespace DatabaseCode.Tests.Support
{
    internal static class PersonHelper
    {
        public static Person FromTableRow(
            TableRow row,
            string firstNameKey = nameof(Person.FirstName),
            string lastNameKey = nameof(Person.LastName))
        {
            return new Person { FirstName = row[firstNameKey], LastName = row[lastNameKey] };
        }
    }
}
