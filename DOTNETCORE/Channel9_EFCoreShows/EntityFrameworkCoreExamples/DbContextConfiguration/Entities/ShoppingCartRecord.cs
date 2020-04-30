using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityConfiguration.Entities.Base;

namespace EntityConfiguration.Entities
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