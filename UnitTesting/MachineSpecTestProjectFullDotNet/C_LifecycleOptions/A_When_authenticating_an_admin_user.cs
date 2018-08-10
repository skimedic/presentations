#region Copyright
// Copyright Information
// ==================================
// UnitTesting - MachineSpecTestProjectFullDotNet - A_When_authenticating_an_admin_user.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using Machine.Specifications;

namespace MachineSpecTestProjectFullDotNet.C_LifecycleOptions
{
    [Tags("Basic Tests")]
    [Subject("Authentication")]
    public class When_authenticating_an_admin_user
    {
        static SampleService _subject;
        static SampleToken _token;

        //Arrange
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
        It Should_indicate_the_users_name = () => {
            _token.UserName.ShouldEqual("username");
        };

        It Should_have_a_unique_session_id = () => {
            _token.Password.ShouldNotBeNull();
        };
    }
}
