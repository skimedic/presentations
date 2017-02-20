using System;

namespace Performance.EFCore.Models
{
    public partial class SalesPersonQuotaHistory
    {
        public int BusinessEntityID { get; set; }
        public DateTime QuotaDate { get; set; }
        public decimal SalesQuota { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual SalesPerson BusinessEntity { get; set; }
    }
}
