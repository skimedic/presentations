using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
{
    [Table("CurrencyRate", Schema = "Sales")]
    public partial class CurrencyRate
    {
        public CurrencyRate()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        [Column("CurrencyRateID")]
        public int CurrencyRateId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CurrencyRateDate { get; set; }
        [Required]
        [StringLength(3)]
        public string FromCurrencyCode { get; set; }
        [Required]
        [StringLength(3)]
        public string ToCurrencyCode { get; set; }
        [Column(TypeName = "money")]
        public decimal AverageRate { get; set; }
        [Column(TypeName = "money")]
        public decimal EndOfDayRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("FromCurrencyCode")]
        [InverseProperty("CurrencyRateFromCurrencyCodeNavigation")]
        public virtual Currency FromCurrencyCodeNavigation { get; set; }
        [ForeignKey("ToCurrencyCode")]
        [InverseProperty("CurrencyRateToCurrencyCodeNavigation")]
        public virtual Currency ToCurrencyCodeNavigation { get; set; }
        [InverseProperty("CurrencyRate")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
