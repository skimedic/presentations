using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputedColumns.Models
{
    [Table("Orders", Schema = "Store")]
    public class Order : EntityBase
    {
        public int CustomerId { get; set; }
        //Commented out for first migration - need to create tables, add UDF, then add columns
        [Display(Name = "Total")]
        public decimal? OrderTotal { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Ordered")]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Shipped")]
        public DateTime ShipDate { get; set; }
        [InverseProperty("Order")]
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
