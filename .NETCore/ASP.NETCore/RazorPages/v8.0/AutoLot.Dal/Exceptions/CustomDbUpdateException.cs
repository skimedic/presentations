// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - CustomDbUpdateException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Dal.Exceptions;

public class CustomDbUpdateException : CustomException
{
    public CustomDbUpdateException()
    {
    }

    public CustomDbUpdateException(string message) : base(message)
    {
    }

    public CustomDbUpdateException(string message, DbUpdateException innerException)
        : base(message, innerException)
    {
    }
}
