using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("WorkOrder", Schema = "Production")]
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            WorkOrderRouting = new HashSet<WorkOrderRouting>();
        }

        [Column("WorkOrderID")]
        public int WorkOrderId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        public int OrderQty { get; set; }
        public int StockedQty { get; set; }
        public short ScrappedQty { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        [Column("ScrapReasonID")]
        public short? ScrapReasonId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("WorkOrder")]
        public Product Product { get; set; }
        [ForeignKey("ScrapReasonId")]
        [InverseProperty("WorkOrder")]
        public ScrapReason ScrapReason { get; set; }
        [InverseProperty("WorkOrder")]
        public ICollection<WorkOrderRouting> WorkOrderRouting { get; set; }
    }
}
