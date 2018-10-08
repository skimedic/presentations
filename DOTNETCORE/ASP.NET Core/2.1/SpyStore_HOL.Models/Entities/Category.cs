using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpyStore_HOL.Models.Entities.Base;

namespace SpyStore_HOL.Models.Entities
{
    [Table("Categories", Schema = "Store")]
    public class Category : EntityBase
    {
        [MaxLength(50)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(Product.Category))]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}