namespace GlobalQueryFilters.Models;

public class Blog
{
    public bool IsDeleted { get; set; }
    public int BlogId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}