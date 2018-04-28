namespace Security.Services
{
    public class EmailSettings
    {
        public EmailSettings()
        {
        }

        public string EmailId { get; set; }
        public string EmailPassword { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool UseSsl { get; set; }
        public string BccList { get; set; }
    }
}