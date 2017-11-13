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
    [Subject("Authentication")]
    public class When_authenticating_an_admin_user
    {
        Establish _context = () => {
            _subject = new SampleService();
        };

        Because of = () => {
            _token = _subject.Authenticate("username", "password");
        };

        It Should_indicate_the_users_name = () => {
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
