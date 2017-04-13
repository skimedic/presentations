using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace Concurrency.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}