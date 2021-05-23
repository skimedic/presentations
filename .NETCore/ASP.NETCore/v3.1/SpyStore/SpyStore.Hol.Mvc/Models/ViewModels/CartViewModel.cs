using System.Collections.Generic;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Mvc.Models.ViewModels
{
    public class CartViewModel
    {
        public Customer Customer { get; set; }
        public IList<CartRecordViewModel> CartRecords { get; set; }
    }
}