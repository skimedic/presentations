// Copyright Information
// ==================================
// EFCoreExamples - 13_JsonColumns - Commit.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/11
// ==================================

namespace JsonColumns.Models;

public class Commit
{
    public Commit(DateTime committedOn, string comment)
    {
        CommittedOn = committedOn;
        Comment = comment;
    }
    public int Id { get; set; }

    public DateTime CommittedOn { get; private set; }
    public string Comment { get; set; }
}