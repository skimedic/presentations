// Copyright Information
// ==================================
// EFCoreExamples - 13_JsonColumns - PostUpdate.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/11
// ==================================

using System.Net;

namespace JsonColumns.Models;

public class PostUpdate
{
    public PostUpdate(IPAddress postedFrom, DateTime updatedOn)
    {
        PostedFrom = postedFrom;
        UpdatedOn = updatedOn;
    }
    public int Id { get; set; }
    public IPAddress PostedFrom { get; private set; }
    public string UpdatedBy { get; init; }
    public DateTime UpdatedOn { get; private set; }
    public List<Commit> Commits { get; } = new();
}