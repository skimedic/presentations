// Copyright Information
// ==================================
// Channel9 - EfCore - EmployeePayHistory.cs
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
    [Table("EmployeePayHistory", Schema = "HumanResources")]
    public partial class EmployeePayHistory
    {
        [Key] [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        [Key] [Column(TypeName = "datetime")] public DateTime RateChangeDate { get; set; }

        [Column(TypeName = "money")] public decimal Rate { get; set; }

        public byte PayFrequency { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Employee.EmployeePayHistory))]
        public virtual Employee BusinessEntity { get; set; }
    }
}