using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Dal.test.Models
{
    public partial class Makes
    {
        public Makes()
        {
            Inventory = new HashSet<Inventory>();
        }

        [Key]
        public int Id { get; set; }
        public byte[] TimeStamp { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Make")]
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
