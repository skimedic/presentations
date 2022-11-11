// Copyright Information
// ==================================
// EFCoreExamples - 13_JsonColumns - Blog.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/11
// ==================================

namespace JsonColumns.Models;

public class Blog
{
    public Blog(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; set; }
    public List<Post> Posts { get; } = new();
}