using System;

namespace SpyStore.Dal.Exceptions
{
    public class SpyStoreException:Exception
    {
        public SpyStoreException() { }
        public SpyStoreException(string message) : base(message) { }
        public SpyStoreException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
