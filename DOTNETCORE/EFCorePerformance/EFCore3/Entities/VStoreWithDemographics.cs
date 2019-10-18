using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Entities
{
    public partial class VStoreWithDemographics
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal? AnnualSales { get; set; }
        [Column(TypeName = "money")]
        public decimal? AnnualRevenue { get; set; }
        [StringLength(50)]
        public string BankName { get; set; }
        [StringLength(5)]
        public string BusinessType { get; set; }
        public int? YearOpened { get; set; }
        [StringLength(50)]
        public string Specialty { get; set; }
        public int? SquareFeet { get; set; }
        [StringLength(30)]
        public string Brands { get; set; }
        [StringLength(30)]
        public string Internet { get; set; }
        public int? NumberEmployees { get; set; }
    }
}
