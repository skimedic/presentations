using SpyStore_v20.Models.CustomViewModels.Base;
namespace SpyStore_v20.Models.CustomViewModels
{
    public class AddToCartViewModel :CartViewModelBase
    {
        public int Quantity { get; set; }
    }
}