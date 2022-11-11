// Copyright Information
// ==================================
// EFCoreExamples - 13_JsonColumns - ContactDetails.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/11
// ==================================

namespace JsonColumns.Models;

public class ContactDetails
{
    public Address Address { get; set; } = null!;
    public string Phone { get; set; }
}