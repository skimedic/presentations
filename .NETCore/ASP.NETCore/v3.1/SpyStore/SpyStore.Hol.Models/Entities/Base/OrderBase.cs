using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpyStore.Hol.Models.Entities.Base
{
    public class OrderBase : EntityBase
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date Ordered")]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Shipped")]
        public DateTime ShipDate { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Total"),DataType(DataType.Currency)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal OrderTotal { get; set; }
    }
}