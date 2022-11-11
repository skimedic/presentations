// Copyright Information
// ==================================
// EFCoreExamples - 13_JsonColumns - PostMetadata.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/11
// ==================================

namespace JsonColumns.Models;

public class PostMetadata
{
    public PostMetadata(int views)
    {
        Views = views;
    }
    public int Id { get; set; }
    public int Views { get; set; }
    public List<SearchTerm> TopSearches { get; } = new();
    public List<Visits> TopGeographies { get; } = new();
    public List<PostUpdate> Updates { get; } = new();
}