using System.ComponentModel.DataAnnotations;
using SpyStore.Models.Entities.Base;

namespace SpyStore.Models.ViewModels
{
public class CartRecordWithProductInfo : ShoppingCartRecordBase
{
    public new int Id { get; set; }
    //Not supported at this time
    //public ProductDetails Details { get; set; }
    public string Description { get; set; }
    [Display(Name="Model Number")]
    public string ModelNumber { get; set; }
    [Display(Name = "Name")]
    public string ModelName { get; set; }
    public string ProductImage { get; set; }
    public string ProductImageLarge { get; set; }
    public string ProductImageThumb { get; set; }
    [Display(Name = "In Stock")]
    public int UnitsInStock { get; set; }
    [Display(Name = "Price"),DataType(DataType.Currency)]
    public decimal CurrentPrice { get; set; }
    public int CategoryId { get; set; }
    [Display(Name = "Category")]
    public string CategoryName { get; set; }
}
}
