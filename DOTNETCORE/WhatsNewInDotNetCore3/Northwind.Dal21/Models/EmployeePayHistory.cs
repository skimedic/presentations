using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("EmployeePayHistory", Schema = "HumanResources")]
    public partial class EmployeePayHistory
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RateChangeDate { get; set; }
        [Column(TypeName = "money")]
        public decimal Rate { get; set; }
        public byte PayFrequency { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("EmployeePayHistory")]
        public Employee BusinessEntity { get; set; }
    }
}
