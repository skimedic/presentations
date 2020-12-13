// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - Location.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities
{
    [Table("Location", Schema = "Production")]
    public partial class Location
    {
        public Location()
        {
            ProductInventory = new HashSet<ProductInventory>();
            WorkOrderRouting = new HashSet<WorkOrderRouting>();
        }

        [Key] [Column("LocationID")] public short LocationId { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        [Column(TypeName = "smallmoney")] public decimal CostRate { get; set; }

        [Column(TypeName = "decimal(8, 2)")] public decimal Availability { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [InverseProperty("Location")] public virtual ICollection<ProductInventory> ProductInventory { get; set; }

        [InverseProperty("Location")] public virtual ICollection<WorkOrderRouting> WorkOrderRouting { get; set; }
    }
}