using System;
using System.Collections.Generic;

namespace PerformanceEF3.EFCore.Models
{
    public class CustomerView : CustomerBase
    {

    }

    public class CustomerQuery : CustomerBase
    {

    }

    public class CustomerBase
    {
        public int CustomerID { get; set; }
        public int? PersonID { get; set; }
        public int? StoreID { get; set; }
        public int? TerritoryID { get; set; }
        public string AccountNumber { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
    public partial class Customer : CustomerBase
    {
        public Customer()
        {
        }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } 
            = new HashSet<SalesOrderHeader>();
        public virtual Person Person { get; set; }
        public virtual Store Store { get; set; }
        public virtual SalesTerritory Territory { get; set; }
    }
}
