using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities
{
    [Table("StateProvince", Schema = "Person")]
    public partial class StateProvince
    {
        public StateProvince()
        {
            Address = new HashSet<Address>();
            SalesTaxRate = new HashSet<SalesTaxRate>();
        }

        [Key]
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [Required]
        [StringLength(3)]
        public string StateProvinceCode { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Required]
        public bool? IsOnlyStateProvinceFlag { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CountryRegionCode))]
        [InverseProperty(nameof(CountryRegion.StateProvince))]
        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(SalesTerritory.StateProvince))]
        public virtual SalesTerritory Territory { get; set; }
        [InverseProperty("StateProvince")]
        public virtual ICollection<Address> Address { get; set; }
        [InverseProperty("StateProvince")]
        public virtual ICollection<SalesTaxRate> SalesTaxRate { get; set; }
    }
}
