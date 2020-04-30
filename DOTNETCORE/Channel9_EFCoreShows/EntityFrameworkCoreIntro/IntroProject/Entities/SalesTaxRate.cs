// Copyright Information
// ==================================
// Channel9 - EfCore - SalesTaxRate.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/10
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    [Table("SalesTaxRate", Schema = "Sales")]
    public partial class SalesTaxRate
    {
        [Key] [Column("SalesTaxRateID")] public int SalesTaxRateId { get; set; }

        [Column("StateProvinceID")] public int StateProvinceId { get; set; }

        public byte TaxType { get; set; }

        [Column(TypeName = "smallmoney")] public decimal TaxRate { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        [Column("rowguid")] public Guid Rowguid { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(StateProvinceId))]
        [InverseProperty("SalesTaxRate")]
        public virtual StateProvince StateProvince { get; set; }
    }
}