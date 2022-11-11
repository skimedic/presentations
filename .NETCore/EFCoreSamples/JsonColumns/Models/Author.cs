// Copyright Information
// ==================================
// EFCoreExamples - 13_JsonColumns - Author.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/11
// ==================================

namespace JsonColumns.Models;

public class Author
{
    public Author(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public ContactDetails Contact { get; set; } = null!;
    public List<Post> Posts { get; } = new();
}