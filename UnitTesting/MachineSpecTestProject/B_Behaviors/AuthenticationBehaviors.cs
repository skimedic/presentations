#region Copyright
// Copyright Information
// ==================================
// UnitTesting - MachineSpecTestProject - AuthenticationBehaviors.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Machine.Specifications;
using MachineSpecTestProject.SystemUnderTest;

namespace MachineSpecTestProject.B_Behaviors
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
