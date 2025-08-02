// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - CustomConcurrencyException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Dal.Exceptions;

public class CustomConcurrencyException : CustomException
{
    public CustomConcurrencyException() { }
    public CustomConcurrencyException(string message) : base(message) { }
    public CustomConcurrencyException(string message, DbUpdateConcurrencyException innerException)
        : base(message, innerException) { }
}