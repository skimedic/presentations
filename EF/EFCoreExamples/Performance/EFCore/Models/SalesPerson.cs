using System;
using System.Collections.Generic;

namespace Performance.EFCore.Models
{
    public partial class SalesPerson
    {
        public SalesPerson()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
            SalesPersonQuotaHistory = new HashSet<SalesPersonQuotaHistory>();
            SalesTerritoryHistory = new HashSet<SalesTerritoryHistory>();
            Store = new HashSet<Store>();
        }

        public int BusinessEntityID { get; set; }
        public int? TerritoryID { get; set; }
        public decimal? SalesQuota { get; set; }
        public decimal Bonus { get; set; }
        public decimal CommissionPct { get; set; }
        public decimal SalesYTD { get; set; }
        public decimal SalesLastYear { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; }
        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
        public virtual ICollection<Store> Store { get; set; }
        public virtual Employee BusinessEntity { get; set; }
        public virtual SalesTerritory Territory { get; set; }
    }
}
