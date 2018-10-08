using System.Collections.Generic;
using SpyStore_HOL.Models.Entities;

namespace SpyStore_HOL.MVC.ViewModels
{
    public class CartViewModel
    {
        public Customer Customer { get; set; }
        public IList<CartRecordViewModel> CartRecords { get; set; }
    }
}