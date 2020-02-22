using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal.Models
{
    [Table("SalesOrderHeaderSalesReason", Schema = "Sales")]
    public partial class SalesOrderHeaderSalesReason
    {
        [Key]
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        [Key]
        [Column("SalesReasonID")]
        public int SalesReasonId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(SalesOrderId))]
        [InverseProperty(nameof(SalesOrderHeader.SalesOrderHeaderSalesReason))]
        public virtual SalesOrderHeader SalesOrder { get; set; }
        [ForeignKey(nameof(SalesReasonId))]
        [InverseProperty("SalesOrderHeaderSalesReason")]
        public virtual SalesReason SalesReason { get; set; }
    }
}
