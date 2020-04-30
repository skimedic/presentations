// Copyright Information
// ==================================
// Channel9 - EfCore - WorkOrderRouting.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/10
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    [Table("WorkOrderRouting", Schema = "Production")]
    public partial class WorkOrderRouting
    {
        [Key] [Column("WorkOrderID")] public int WorkOrderId { get; set; }

        [Key] [Column("ProductID")] public int ProductId { get; set; }

        [Key] public short OperationSequence { get; set; }

        [Column("LocationID")] public short LocationId { get; set; }

        [Column(TypeName = "datetime")] public DateTime ScheduledStartDate { get; set; }

        [Column(TypeName = "datetime")] public DateTime ScheduledEndDate { get; set; }

        [Column(TypeName = "datetime")] public DateTime? ActualStartDate { get; set; }

        [Column(TypeName = "datetime")] public DateTime? ActualEndDate { get; set; }

        [Column(TypeName = "decimal(9, 4)")] public decimal? ActualResourceHrs { get; set; }

        [Column(TypeName = "money")] public decimal PlannedCost { get; set; }

        [Column(TypeName = "money")] public decimal? ActualCost { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty("WorkOrderRouting")]
        public virtual Location Location { get; set; }

        [ForeignKey(nameof(WorkOrderId))]
        [InverseProperty("WorkOrderRouting")]
        public virtual WorkOrder WorkOrder { get; set; }
    }
}