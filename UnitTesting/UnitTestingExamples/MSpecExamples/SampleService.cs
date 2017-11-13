namespace MSpecExamples
{
    public class SampleService
    {
        public SampleToken Authenticate(string userName, string password)
        {
            return new SampleToken { UserName = userName, Password = password };
        }
    }
}