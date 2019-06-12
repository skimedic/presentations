using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
  [Table("Customers", Schema = "Store")]
  public class Customer : EntityBase
  {
    [DataType(DataType.Text), MaxLength(50), Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress), MaxLength(50), Display(Name = "Email Address")]
    public string EmailAddress { get; set; }

    [Required]
    [DataType(DataType.Password), MaxLength(50)]
    public string Password { get; set; }

    [InverseProperty(nameof(Order.CustomerNavigation))]
    [JsonIgnore]
    public List<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty(nameof(ShoppingCartRecord.CustomerNavigation))]
    [JsonIgnore]
    public List<ShoppingCartRecord> ShoppingCartRecords { get; set; } = new List<ShoppingCartRecord>();
  }
}