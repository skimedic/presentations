using System.ComponentModel.DataAnnotations;

namespace Kcdc.Api.Data
{
    public class Speaker
    {
        [Key]
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string EmailAddress { get; set; }

        public string FullName 
        { 
            get{
                return $"{this.First} {this.Last}";
            }
        }
    }
}