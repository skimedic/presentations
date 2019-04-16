using System;

namespace SpyStore.Dal.Exceptions
{
    public class SpyStoreInvalidQuantityException : SpyStoreException
    {
        public SpyStoreInvalidQuantityException() { }
        public SpyStoreInvalidQuantityException(string message) : base(message) { }
        public SpyStoreInvalidQuantityException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}