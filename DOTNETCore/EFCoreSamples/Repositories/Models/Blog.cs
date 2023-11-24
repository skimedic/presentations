using Repositories.Models.Base;

namespace Repositories.Models;

public class Blog : EntityBase
{
    public int BlogId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}