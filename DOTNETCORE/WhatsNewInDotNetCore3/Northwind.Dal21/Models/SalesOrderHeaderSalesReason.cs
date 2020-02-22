using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("SalesOrderHeaderSalesReason", Schema = "Sales")]
    public partial class SalesOrderHeaderSalesReason
    {
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        [Column("SalesReasonID")]
        public int SalesReasonId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("SalesOrderId")]
        [InverseProperty("SalesOrderHeaderSalesReason")]
        public SalesOrderHeader SalesOrder { get; set; }
        [ForeignKey("SalesReasonId")]
        [InverseProperty("SalesOrderHeaderSalesReason")]
        public SalesReason SalesReason { get; set; }
    }
}
