using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Dal.Models.Entities.Base;

namespace AutoLot.Dal.Models.Entities
{
    [Table("Inventory",Schema = "Dbo")]
    public partial class Car : BaseEntity
    {
        public int MakeId { get; set; }
        [ForeignKey(nameof(MakeId))]
        public Make MakeNavigation { get; set; }

        [StringLength(50)]
        public string Color { get; set; }
        [StringLength(50)]
        public string PetName { get; set; }

        [InverseProperty(nameof(Order.CarNavigation))]
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        [NotMapped]
        public string MakeColor => $"{MakeNavigation?.Name} ({Color})";
        public override string ToString()
        {
            // Since the PetName column could be empty, supply
            // the default name of **No Name**.
            return $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
        }


    }
}
