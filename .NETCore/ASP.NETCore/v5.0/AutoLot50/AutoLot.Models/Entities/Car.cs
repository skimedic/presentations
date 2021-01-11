using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AutoLot.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Models.Entities
{
    [Table("Inventory", Schema = "dbo")]
    [Index(nameof(MakeId), Name = "IX_Inventory_MakeId")]
    public partial class Car : BaseEntity
    {
        private bool? _isDrivable;
        [DisplayName("Is Drivable")]
        public bool IsDrivable
        {
            get => _isDrivable ?? false;
            set => _isDrivable = value;
        }

        [Required]
		[DisplayName("Make")] 
        public int MakeId { get; set; }
		
        [Required]
		[StringLength(50)]
        public string Color { get; set; } = "Gold";

        [Required]
		[StringLength(50)]
        [DisplayName("Pet Name")]
        public string PetName { get; set; } = "My Precious";

        [ForeignKey(nameof(MakeId))]
        [InverseProperty(nameof(Make.Cars))]
        public Make? MakeNavigation { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Order.CarNavigation))]
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        [NotMapped] 
        public string MakeName => MakeNavigation?.Name ?? "Unknown";

        public override string ToString()
        {
            // Since the PetName column could be empty, supply
            // the default name of **No Name**.
            return $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
        }
    }
}
