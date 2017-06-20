// Copyright Information
// =============================
// MSpecExamples - When_authenticating_an_admin_user.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;

namespace MSpecExamples
{
    //It's bad form to put the tests and the SUT in the same file/project, but this code
    //is for teaching
    public class SampleToken
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class SampleService
    {
        public SampleToken Authenticate(string userName, string password)
        {
            return new SampleToken { UserName = userName, Password = password };
        }
    }

    [Subject("Authentication")]
    public class When_authenticating_an_admin_user
    {
        Establish _context = () => {
            _subject = new SampleService();
        };

        Because of = () => {
            _token = _subject.Authenticate("username", "password");
        };

        It Should_indicate_the_users_role = () => {
            _token.UserName.ShouldEqual("username");
        };

        It Should_have_a_unique_session_id = () => {
            _token.Password.ShouldNotBeNull();
        };

        It should_do_the_kessel_run_in_twelve_parsecs;

        static SampleService _subject;
        static SampleToken _token;
    }

}
