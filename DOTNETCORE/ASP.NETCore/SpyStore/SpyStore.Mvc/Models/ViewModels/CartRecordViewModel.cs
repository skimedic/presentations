using System.ComponentModel.DataAnnotations;
using SpyStore.Hol.Mvc.Validation;
using SpyStore.Models.ViewModels;

namespace SpyStore.Hol.Mvc.Models.ViewModels
{
    public class CartRecordViewModel : CartRecordWithProductInfo
    {
        [Required,MustNotBeGreaterThan(nameof(UnitsInStock))]
        public new int Quantity { get; set; }
    }
}
