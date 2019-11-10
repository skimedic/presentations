using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal.Models
{
    [Table("CountryRegionCurrency", Schema = "Sales")]
    public partial class CountryRegionCurrency
    {
        [Key]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Key]
        [StringLength(3)]
        public string CurrencyCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CountryRegionCode))]
        [InverseProperty(nameof(CountryRegion.CountryRegionCurrency))]
        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        [ForeignKey(nameof(CurrencyCode))]
        [InverseProperty(nameof(Currency.CountryRegionCurrency))]
        public virtual Currency CurrencyCodeNavigation { get; set; }
    }
}
