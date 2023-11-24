// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - CustomConcurrencyException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
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