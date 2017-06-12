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
        Establish context = () => {
            _subject = new SampleService();
        };

        Because of = () => {
            _token = _subject.Authenticate("username", "password");
        };

        It should_indicate_the_users_role = () => {
            _token.UserName.ShouldEqual("username");
        };

        It should_have_a_unique_session_id = () => {
            _token.Password.ShouldNotBeNull();
        };

        static SampleService _subject;
        static SampleToken _token;
    }

    public class SampleToken
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class SampleService
    {
        public SampleToken Authenticate(string userName, string password)
        {
            return new SampleToken {UserName = userName, Password = password};
        }
    }
}
