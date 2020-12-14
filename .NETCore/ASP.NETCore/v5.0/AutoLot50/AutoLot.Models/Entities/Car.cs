// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Car.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AutoLot.Models.Entities.Base;

namespace AutoLot.Models.Entities
{
    [Table("Inventory", Schema = "Dbo")]
    public partial class Car : BaseEntity
    {
        [Required] [DisplayName("Make")] public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        [InverseProperty(nameof(Make.Cars))]
        public Make? MakeNavigation { get; set; }

        [StringLength(50), Required] public string Color { get; set; } = "Gold";

        [StringLength(50), Required]
        [DisplayName("Pet Name")]
        public string PetName { get; set; } = "My Precious";

        [JsonIgnore]
        [InverseProperty(nameof(Order.CarNavigation))]
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        [NotMapped] public string MakeColor => $"{MakeNavigation?.Name} ({Color})";

        public override string ToString()
        {
            // Since the PetName column could be empty, supply
            // the default name of **No Name**.
            return $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
        }
    }
}
