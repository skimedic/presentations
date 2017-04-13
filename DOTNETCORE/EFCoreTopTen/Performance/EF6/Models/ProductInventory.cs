using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Production.ProductInventory")]
    public partial class ProductInventory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short LocationID { get; set; }

        [Required]
        [StringLength(10)]
        public string Shelf { get; set; }

        public byte Bin { get; set; }

        public short Quantity { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Location Location { get; set; }

        public virtual Product Product { get; set; }
    }
}
