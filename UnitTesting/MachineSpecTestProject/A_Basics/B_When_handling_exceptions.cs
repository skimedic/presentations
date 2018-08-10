#region Copyright
// Copyright Information
// ==================================
// UnitTesting - MachineSpecTestProject - B_When_handling_exceptions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System;
using Machine.Specifications;
using MachineSpecTestProject.SystemUnderTest;

namespace MachineSpecTestProject.A_Basics
{
    [Tags("RegressionTests")]
    [Subject("Authentication")]
    public class When_handling_exceptions
    {
        static SampleService _subject;
        static Exception _exception;

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
        Because _of = () => _exception = Catch.Exception(() => _subject.Authenticate("", "password"));

        It Should_fail = () => _exception.ShouldBeOfExactType<ArgumentNullException>();
        It Should_have_a_specific_reason = () => _exception.Message.ShouldEqual("Missing userName\r\nParameter name: userName");
        It Should_have_a_specific_argument = () => ((ArgumentNullException)_exception).ParamName.ShouldEqual("userName");

    }
}