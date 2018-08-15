using System.ComponentModel.DataAnnotations;

namespace EFCoreSamples.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}