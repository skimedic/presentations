using System;

namespace Kcdc.Api.Data
{
    public class Registration
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public DateTime Date { get; set; }
    }
}