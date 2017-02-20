using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Sales.CurrencyRate")]
    public partial class CurrencyRate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CurrencyRate()
        {
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        public int CurrencyRateID { get; set; }

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

        public DateTime ModifiedDate { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual Currency Currency1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
