// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - WorkOrder.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("WorkOrder", Schema = "Production")]
public partial class WorkOrder
{
    public WorkOrder()
    {
        WorkOrderRouting = new HashSet<WorkOrderRouting>();
    }

    [Key] [Column("WorkOrderID")] public int WorkOrderId { get; set; }

    [Column("ProductID")] public int ProductId { get; set; }

    public int OrderQty { get; set; }
    public int StockedQty { get; set; }
    public short ScrappedQty { get; set; }

    [Column(TypeName = "datetime")] public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")] public DateTime? EndDate { get; set; }

    [Column(TypeName = "datetime")] public DateTime DueDate { get; set; }

    [Column("ScrapReasonID")] public short? ScrapReasonId { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("WorkOrder")]
    public virtual Product Product { get; set; }

    [ForeignKey(nameof(ScrapReasonId))]
    [InverseProperty("WorkOrder")]
    public virtual ScrapReason ScrapReason { get; set; }

    [InverseProperty("WorkOrder")] public virtual ICollection<WorkOrderRouting> WorkOrderRouting { get; set; }
}