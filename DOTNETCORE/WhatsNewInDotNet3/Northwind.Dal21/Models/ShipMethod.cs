using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("ShipMethod", Schema = "Purchasing")]
    public partial class ShipMethod
    {
        public ShipMethod()
        {
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal ShipBase { get; set; }
        [Column(TypeName = "money")]
        public decimal ShipRate { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("ShipMethod")]
        public ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        [InverseProperty("ShipMethod")]
        public ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
