using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AutoLot.Dal.Models.Entities.Base;

namespace AutoLot.Dal.Models.Entities
{
    [Table("Inventory", Schema = "dbo")]
    public partial class Car : BaseEntity
    {
        [Required]
        public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        [InverseProperty(nameof(Make.Cars))]
        public Make? MakeNavigation { get; set; }

        [StringLength(50),Required] 
        public string Color { get; set; }
        [StringLength(50),Required]
        public string PetName { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Order.CarNavigation))]
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
