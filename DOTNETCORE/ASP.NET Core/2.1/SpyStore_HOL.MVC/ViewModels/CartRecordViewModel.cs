using SpyStore_HOL.MVC.Validation;
using SpyStore_HOL.MVC.ViewModels.Base;

namespace SpyStore_HOL.MVC.ViewModels
{
    public class CartRecordViewModel : CartViewModelBase
    {
        [MustNotBeGreaterThan(nameof(UnitsInStock))]
        public int Quantity { get; set; }
    }
}