using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;

namespace Concurrency.Models
{
    public class Blog
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
       
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}