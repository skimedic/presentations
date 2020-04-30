using System.Collections.Generic;
using EntityConfiguration.Entities;

namespace EntityConfiguration.ViewModels
{
    public class CartWithCustomerInfo
    {
        public Customer Customer { get; set; }
        public IList<CartRecordWithProductInfo> CartRecords { get; set; }
        = new List<CartRecordWithProductInfo>();
    }
}
