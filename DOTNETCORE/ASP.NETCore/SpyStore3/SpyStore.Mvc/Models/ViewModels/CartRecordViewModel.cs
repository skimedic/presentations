using System.ComponentModel.DataAnnotations;
using SpyStore.Models.ViewModels;
using SpyStore.Mvc.Validation;

namespace SpyStore.Mvc.Models.ViewModels
{
    public class CartRecordViewModel : CartRecordWithProductInfo
    {
        [Required,MustNotBeGreaterThan(nameof(UnitsInStock))]
        public new int Quantity { get; set; }
    }
}
