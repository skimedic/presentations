#region copyright
// // Copyright Information
// // ==============================
// // DAL - CustomDatabaseUpdateException.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;

namespace DAL.Exceptions
{
    public class CustomDatabaseUpdateException : Exception
    {
        public CustomDatabaseUpdateException(UpdateExceptionType exceptionType)
            : base()
        {
            ExceptionType = exceptionType;
        }

        public CustomDatabaseUpdateException(UpdateExceptionType exceptionType, string message)
            : base(message)
        {
            ExceptionType = exceptionType;

        }

        public CustomDatabaseUpdateException(UpdateExceptionType exceptionType, string format, params object[] args)
            : base(string.Format(format, args))
        {
            ExceptionType = exceptionType;

        }

        public CustomDatabaseUpdateException(UpdateExceptionType exceptionType, string message, Exception innerException)
            : base(message, innerException)
        {
            ExceptionType = exceptionType;

        }

        public CustomDatabaseUpdateException(UpdateExceptionType exceptionType, string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
            ExceptionType = exceptionType;

        }
        public UpdateExceptionType ExceptionType { get; set; }
    }
}
