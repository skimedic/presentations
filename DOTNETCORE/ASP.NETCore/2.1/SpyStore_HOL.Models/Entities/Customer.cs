using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpyStore_HOL.Models.Entities.Base;

namespace SpyStore_HOL.Models.Entities
{
    [Table("Customers", Schema = "Store")]
    public class Customer : EntityBase
    {
        [MaxLength(50), ConcurrencyCheck]
        [DataType(DataType.Text), Display(Name = "Full Name")]
        public string FullName { get; set; }
        [MaxLength(50), Required]
        [EmailAddress, DataType(DataType.EmailAddress), Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [MaxLength(50), Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [InverseProperty(nameof(Order.Customer))]
        public List<Order> Orders { get; set; } = new List<Order>();
        [InverseProperty(nameof(ShoppingCartRecord.Customer))]
        public List<ShoppingCartRecord> ShoppingCartRecords { get; set; } = new List<ShoppingCartRecord>();
    }
}