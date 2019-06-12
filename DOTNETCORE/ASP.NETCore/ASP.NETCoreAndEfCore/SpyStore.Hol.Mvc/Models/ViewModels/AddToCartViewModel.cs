using System.ComponentModel.DataAnnotations;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Validation;

namespace SpyStore.Hol.Mvc.Models.ViewModels
{
    public class AddToCartViewModel : CartRecordWithProductInfo
    {
        [Required, MustNotBeGreaterThan(nameof(UnitsInStock)), MustBeGreaterThanZero]
        public new int Quantity { get; set; }
    }
}