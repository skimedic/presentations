using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("StateProvince", Schema = "Person")]
    public partial class StateProvince
    {
        public StateProvince()
        {
            Address = new HashSet<Address>();
            SalesTaxRate = new HashSet<SalesTaxRate>();
        }

        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [Required]
        [StringLength(3)]
        public string StateProvinceCode { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Required]
        [Column(TypeName = "Flag")]
        public bool? IsOnlyStateProvinceFlag { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CountryRegionCode")]
        [InverseProperty("StateProvince")]
        public CountryRegion CountryRegionCodeNavigation { get; set; }
        [ForeignKey("TerritoryId")]
        [InverseProperty("StateProvince")]
        public SalesTerritory Territory { get; set; }
        [InverseProperty("StateProvince")]
        public ICollection<Address> Address { get; set; }
        [InverseProperty("StateProvince")]
        public ICollection<SalesTaxRate> SalesTaxRate { get; set; }
    }
}
