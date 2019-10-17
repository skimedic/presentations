using System;
using CM = System.Configuration.ConfigurationManager;

namespace DatabaseCode.Tests.Support
{
    public class DatabaseContextWrapper
        : IDisposable
    {
        public DatabaseContextWrapper()
        {
            DatabaseContext = new DatabaseContext(TestThreadId);
        }

        ~DatabaseContextWrapper()
        {
            Dispose();
        }

        public string TestThreadId => CM.AppSettings["TestThread"];

        public DatabaseContext DatabaseContext { get; }

        public void Dispose()
        {
            DatabaseContext?.Dispose();
        }
    }
}
