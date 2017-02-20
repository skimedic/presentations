using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Purchasing.ProductVendor")]
    public partial class ProductVendor
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        public int AverageLeadTime { get; set; }

        [Column(TypeName = "money")]
        public decimal StandardPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? LastReceiptCost { get; set; }

        public DateTime? LastReceiptDate { get; set; }

        public int MinOrderQty { get; set; }

        public int MaxOrderQty { get; set; }

        public int? OnOrderQty { get; set; }

        [Required]
        [StringLength(3)]
        public string UnitMeasureCode { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }

        public virtual UnitMeasure UnitMeasure { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
