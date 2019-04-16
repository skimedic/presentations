using SpyStore_HOL.MVC.Validation;
using SpyStore_HOL.MVC.ViewModels.Base;

namespace SpyStore_HOL.MVC.ViewModels
{
    public class AddToCartViewModel : CartViewModelBase
    {
        [MustNotBeGreaterThan(nameof(UnitsInStock)), MustBeGreaterThanZero]
        public int Quantity { get; set; }
    }
}