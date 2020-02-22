using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("ProductCostHistory", Schema = "Production")]
    public partial class ProductCostHistory
    {
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ProductCostHistory")]
        public Product Product { get; set; }
    }
}
