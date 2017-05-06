using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpyStore_HOL.Models.Entities.Base;

namespace SpyStore_HOL.Models.Entities
{
    [Table("ShoppingCartRecords", Schema = "Store")]
    public class ShoppingCartRecord : EntityBase
    {

        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public int Quantity { get; set; }

        public decimal LineItemTotal { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}