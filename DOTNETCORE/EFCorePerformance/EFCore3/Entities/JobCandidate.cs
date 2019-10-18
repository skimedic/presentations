using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Entities
{
    [Table("JobCandidate", Schema = "HumanResources")]
    public partial class JobCandidate
    {
        [Key]
        [Column("JobCandidateID")]
        public int JobCandidateId { get; set; }
        [Column("BusinessEntityID")]
        public int? BusinessEntityId { get; set; }
        [Column(TypeName = "xml")]
        public string Resume { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Employee.JobCandidate))]
        public virtual Employee BusinessEntity { get; set; }
    }
}
