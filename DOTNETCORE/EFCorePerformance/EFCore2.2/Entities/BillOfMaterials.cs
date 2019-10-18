using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
{
    [Table("BillOfMaterials", Schema = "Production")]
    public partial class BillOfMaterials
    {
        [Column("BillOfMaterialsID")]
        public int BillOfMaterialsId { get; set; }
        [Column("ProductAssemblyID")]
        public int? ProductAssemblyId { get; set; }
        [Column("ComponentID")]
        public int ComponentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Required]
        [StringLength(3)]
        public string UnitMeasureCode { get; set; }
        [Column("BOMLevel")]
        public short Bomlevel { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal PerAssemblyQty { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ComponentId")]
        [InverseProperty("BillOfMaterialsComponent")]
        public virtual Product Component { get; set; }
        [ForeignKey("ProductAssemblyId")]
        [InverseProperty("BillOfMaterialsProductAssembly")]
        public virtual Product ProductAssembly { get; set; }
        [ForeignKey("UnitMeasureCode")]
        [InverseProperty("BillOfMaterials")]
        public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; }
    }
}
