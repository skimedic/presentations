using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Dal.test.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int Id { get; set; }
        public byte[] TimeStamp { get; set; }
        public int MakeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        [Required]
        [StringLength(50)]
        public string PetName { get; set; }

        [ForeignKey(nameof(MakeId))]
        [InverseProperty(nameof(Makes.Inventory))]
        public virtual Makes Make { get; set; }
        [InverseProperty("Car")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
