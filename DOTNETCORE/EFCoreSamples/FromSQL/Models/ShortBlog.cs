using System.ComponentModel.DataAnnotations.Schema;

namespace FromSQL.Models
{
    public class ShortBlog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
    }
}