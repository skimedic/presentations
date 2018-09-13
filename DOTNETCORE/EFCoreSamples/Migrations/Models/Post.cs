using System.ComponentModel.DataAnnotations.Schema;

namespace Migrations.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        [ForeignKey(nameof(BlogId))]
        [InverseProperty(nameof(Blog.Posts))]
        public Blog BlogNavigation { get; set; }
    }
}
