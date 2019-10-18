using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Entities
{
    [Table("ShipMethod", Schema = "Purchasing")]
    public partial class ShipMethod
    {
        public ShipMethod()
        {
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        [Key]
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Required]
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
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        [InverseProperty("ShipMethod")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
