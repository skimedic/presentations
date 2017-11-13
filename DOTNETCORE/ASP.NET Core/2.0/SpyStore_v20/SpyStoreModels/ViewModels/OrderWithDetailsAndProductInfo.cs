using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SpyStoreModels.Models.Base;

namespace SpyStoreModels.ViewModels
{
    public class OrderWithDetailsAndProductInfo : EntityBase
    {
        public int CustomerId { get; set; }
        [DataType(DataType.Currency), Display(Name = "Total")]
        public decimal? OrderTotal { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Ordered")]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Shipped")]
        public DateTime ShipDate { get; set; }
        public IList<OrderDetailWithProductInfo> OrderDetails { get; set; }
    }

}