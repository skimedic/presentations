// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - CustomConcurrencyException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Dal.Exceptions;

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
