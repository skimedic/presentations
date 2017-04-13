using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Sales.CountryRegionCurrency")]
    public partial class CountryRegionCurrency
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string CurrencyCode { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual CountryRegion CountryRegion { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
