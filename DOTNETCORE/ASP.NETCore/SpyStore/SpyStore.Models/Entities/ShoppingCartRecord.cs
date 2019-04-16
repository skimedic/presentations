using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SpyStore.Models.Entities.Base;

namespace SpyStore.Models.Entities
{
  [Table("ShoppingCartRecords", Schema = "Store")]
  public class ShoppingCartRecord : ShoppingCartRecordBase
  {
    [JsonIgnore]
    [ForeignKey(nameof(CustomerId))]
    public Customer CustomerNavigation { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(ProductId))]
    public Product ProductNavigation { get; set; }
  }
}