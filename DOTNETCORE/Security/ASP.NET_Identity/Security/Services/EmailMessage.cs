using System.Collections.Generic;

namespace Security.Services
{
    public class EmailMessage
    {
        public string FromEmailAddress { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public List<(string Name, string Email)> ToAddresses { get; set; } = new List<(string Name, string Email)>();
        public List<string> BccAddresses { get; set; } = new List<string>();
        public string Body { get; set; }

    }
}