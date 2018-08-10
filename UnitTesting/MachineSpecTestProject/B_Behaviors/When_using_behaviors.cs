#region Copyright
// Copyright Information
// ==================================
// UnitTesting - MachineSpecTestProject - When_using_behaviors.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using Machine.Specifications;
using MachineSpecTestProject.SystemUnderTest;

namespace MachineSpecTestProject.B_Behaviors
{
    [Tags("Behaviors")]
    [Subject("Authentication")]
    public class When_using_behaviors
    {
        static SampleService _subject;
        protected static SampleToken _token;

        //Arrange - only executes once for the class
        Establish _context = () => {
            _subject = new SampleService();
        };

        private Cleanup _after = () =>
        {
            //Context Teardown
            _subject.Dispose();
        };
        //Act
        Because _of = () => {
            _token = _subject.Authenticate("username", "password");
        };
        //Asserts
        private Behaves_like<AuthenticationBehaviors> Checking_token_values;
        
    }
}