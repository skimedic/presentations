// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Models - CustomException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/10
// ==================================

namespace AutoLot.Models.Exceptions.Base;
public class CustomException : Exception
{
  public CustomException() {}
  public CustomException(string message) : base(message) {}
  public CustomException(string message, Exception innerException)
    : base(message, innerException) {}
}
