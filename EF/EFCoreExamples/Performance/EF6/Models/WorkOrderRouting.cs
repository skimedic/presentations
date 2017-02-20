using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Production.WorkOrderRouting")]
    public partial class WorkOrderRouting
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkOrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short OperationSequence { get; set; }

        public short LocationID { get; set; }

        public DateTime ScheduledStartDate { get; set; }

        public DateTime ScheduledEndDate { get; set; }

        public DateTime? ActualStartDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        public decimal? ActualResourceHrs { get; set; }

        [Column(TypeName = "money")]
        public decimal PlannedCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualCost { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Location Location { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
    }
}
