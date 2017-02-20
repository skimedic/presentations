using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Sales.SalesPersonQuotaHistory")]
    public partial class SalesPersonQuotaHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime QuotaDate { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesQuota { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual SalesPerson SalesPerson { get; set; }
    }
}
