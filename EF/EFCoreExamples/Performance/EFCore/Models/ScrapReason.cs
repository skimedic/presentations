using System;
using System.Collections.Generic;

namespace Performance.EFCore.Models
{
    public partial class ScrapReason
    {
        public ScrapReason()
        {
            WorkOrder = new HashSet<WorkOrder>();
        }

        public short ScrapReasonID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
