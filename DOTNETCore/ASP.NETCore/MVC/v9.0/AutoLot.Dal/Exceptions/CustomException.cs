﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - CustomException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Dal.Exceptions;

public class CustomException : Exception
{
    public CustomException()
    {
    }

    public CustomException(string message) : base(message)
    {
    }

    public CustomException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}