using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpyStoreModels.Models.Base;

namespace SpyStoreModels.Models
{
    [Table("Orders", Schema = "Store")]
    public class Order : EntityBase
    {
        [Display(Name = "Total")]
        public decimal? OrderTotal { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Ordered")]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Shipped")]
        public DateTime ShipDate { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser Customer { get; set; }
        [InverseProperty(nameof(Order))]
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}