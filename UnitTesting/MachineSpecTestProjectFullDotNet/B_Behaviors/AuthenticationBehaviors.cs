#region Copyright
// Copyright Information
// ==================================
// UnitTesting - MachineSpecTestProjectFullDotNet - AuthenticationBehaviors.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using Machine.Specifications;

namespace MachineSpecTestProjectFullDotNet.B_Behaviors
{
    [Behaviors]
    public class AuthenticationBehaviors
    {
        protected static SampleToken _token;
        It Should_indicate_the_users_name = () => {
            _token.UserName.ShouldEqual("username");
        };

        It Should_have_a_unique_session_id = () => {
            _token.Password.ShouldNotBeNull();
        };
    }
}
