using TechTalk.SpecFlow;

namespace DatabaseCode.Tests.Support
{
    internal static class TableRowExtensions
    {
        public static Person ToPerson(this TableRow self)
            => PersonHelper.FromTableRow(self);

        public static Person ToPerson(this TableRow self, string firstNameKey, string lastNameKey)
            => PersonHelper.FromTableRow(self, firstNameKey, lastNameKey);
    }
}
