using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
{
    [Table("UnitMeasure", Schema = "Production")]
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            BillOfMaterials = new HashSet<BillOfMaterials>();
            ProductSizeUnitMeasureCodeNavigation = new HashSet<Product>();
            ProductVendor = new HashSet<ProductVendor>();
            ProductWeightUnitMeasureCodeNavigation = new HashSet<Product>();
        }

        [StringLength(3)]
        public string UnitMeasureCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("UnitMeasureCodeNavigation")]
        public virtual ICollection<BillOfMaterials> BillOfMaterials { get; set; }
        [InverseProperty("SizeUnitMeasureCodeNavigation")]
        public virtual ICollection<Product> ProductSizeUnitMeasureCodeNavigation { get; set; }
        [InverseProperty("UnitMeasureCodeNavigation")]
        public virtual ICollection<ProductVendor> ProductVendor { get; set; }
        [InverseProperty("WeightUnitMeasureCodeNavigation")]
        public virtual ICollection<Product> ProductWeightUnitMeasureCodeNavigation { get; set; }
    }
}
