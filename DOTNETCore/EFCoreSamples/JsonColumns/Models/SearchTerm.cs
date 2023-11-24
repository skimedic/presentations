// Copyright Information
// ==================================
// EFCoreExamples - 13_JsonColumns - SearchTerm.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/11
// ==================================

using System.ComponentModel.DataAnnotations;

namespace JsonColumns.Models;

public class SearchTerm
{
    public SearchTerm(string term, int count)
    {
        Term = term;
        Count = count;
    }
    [Key]
    public int Id { get; set; }
    public string Term { get; private set; }
    public int Count { get; private set; }
}