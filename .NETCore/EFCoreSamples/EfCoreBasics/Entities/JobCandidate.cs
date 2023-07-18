// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - JobCandidate.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("JobCandidate", Schema = "HumanResources")]
public partial class JobCandidate
{
    [Key] [Column("JobCandidateID")] public int JobCandidateId { get; set; }

    [Column("BusinessEntityID")] public int? BusinessEntityId { get; set; }

    [Column(TypeName = "xml")] public string Resume { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(BusinessEntityId))]
    [InverseProperty(nameof(Employee.JobCandidate))]
    public virtual Employee BusinessEntity { get; set; }
}