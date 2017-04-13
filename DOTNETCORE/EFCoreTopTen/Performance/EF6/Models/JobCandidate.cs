using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("HumanResources.JobCandidate")]
    public partial class JobCandidate
    {
        public int JobCandidateID { get; set; }

        public int? BusinessEntityID { get; set; }

        [Column(TypeName = "xml")]
        public string Resume { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
