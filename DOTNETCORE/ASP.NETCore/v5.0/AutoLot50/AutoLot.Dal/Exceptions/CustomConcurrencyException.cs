// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - CustomConcurrencyException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/08/08
// See License.txt for more information
// ==================================

using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Exceptions
{
    public class CustomConcurrencyException : CustomException
    {
        public CustomConcurrencyException()
        {
        }

        public CustomConcurrencyException(string message) : base(message)
        {
        }

        public CustomConcurrencyException(string message, DbUpdateConcurrencyException innerException)
            : base(message, innerException)
        {
        }
    }
}