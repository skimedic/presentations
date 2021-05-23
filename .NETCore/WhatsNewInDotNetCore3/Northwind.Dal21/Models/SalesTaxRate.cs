using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("SalesTaxRate", Schema = "Sales")]
    public partial class SalesTaxRate
    {
        [Column("SalesTaxRateID")]
        public int SalesTaxRateId { get; set; }
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        public byte TaxType { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal TaxRate { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("StateProvinceId")]
        [InverseProperty("SalesTaxRate")]
        public StateProvince StateProvince { get; set; }
    }
}
