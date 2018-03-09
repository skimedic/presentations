using SpyStore_v21.Models.CustomViewModels.Base;

namespace SpyStore_v21.Models.CustomViewModels
{
    public class AddToCartViewModel :CartViewModelBase
    {
        public int Quantity { get; set; }
    }
}