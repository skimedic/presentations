using System;
using System.Collections.Generic;

namespace Performance.EFCore.Models
{
    public partial class SpecialOfferProduct
    {
        public SpecialOfferProduct()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual Product Product { get; set; }
        public virtual SpecialOffer SpecialOffer { get; set; }
    }
}
