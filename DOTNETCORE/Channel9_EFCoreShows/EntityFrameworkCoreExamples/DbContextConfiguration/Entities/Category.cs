using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityConfiguration.Entities.Base;

namespace EntityConfiguration.Entities
{
  [Table("Categories", Schema = "Store")]
  public class Category : EntityBase
  {
    [DataType(DataType.Text), MaxLength(50)]
    public string CategoryName { get; set; }

    [InverseProperty(nameof(Product.CategoryNavigation))]
    public List<Product> Products { get; set; } = new List<Product>();
  }
}