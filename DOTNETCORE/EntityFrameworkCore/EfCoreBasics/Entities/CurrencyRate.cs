// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - CurrencyRate.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities
{
    [Table("CurrencyRate", Schema = "Sales")]
    public partial class CurrencyRate
    {
        public CurrencyRate()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        [Key] [Column("CurrencyRateID")] public int CurrencyRateId { get; set; }

        [Column(TypeName = "datetime")] public DateTime CurrencyRateDate { get; set; }

        [Required] [StringLength(3)] public string FromCurrencyCode { get; set; }

        [Required] [StringLength(3)] public string ToCurrencyCode { get; set; }

        [Column(TypeName = "money")] public decimal AverageRate { get; set; }

        [Column(TypeName = "money")] public decimal EndOfDayRate { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(FromCurrencyCode))]
        [InverseProperty(nameof(Currency.CurrencyRateFromCurrencyCodeNavigation))]
        public virtual Currency FromCurrencyCodeNavigation { get; set; }

        [ForeignKey(nameof(ToCurrencyCode))]
        [InverseProperty(nameof(Currency.CurrencyRateToCurrencyCodeNavigation))]
        public virtual Currency ToCurrencyCodeNavigation { get; set; }

        [InverseProperty("CurrencyRate")] public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}