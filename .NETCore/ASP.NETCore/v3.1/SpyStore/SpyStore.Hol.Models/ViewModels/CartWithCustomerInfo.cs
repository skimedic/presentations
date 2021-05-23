using System.Collections.Generic;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Models.ViewModels
{
    public class CartWithCustomerInfo
    {
        public Customer Customer { get; set; }
        public IList<CartRecordWithProductInfo> CartRecords { get; set; }
        = new List<CartRecordWithProductInfo>();
    }
}
