using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
    public partial class EmployeeDepartmentHistory
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("DepartmentID")]
        public short DepartmentId { get; set; }
        [Column("ShiftID")]
        public byte ShiftId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("EmployeeDepartmentHistory")]
        public Employee BusinessEntity { get; set; }
        [ForeignKey("DepartmentId")]
        [InverseProperty("EmployeeDepartmentHistory")]
        public Department Department { get; set; }
        [ForeignKey("ShiftId")]
        [InverseProperty("EmployeeDepartmentHistory")]
        public Shift Shift { get; set; }
    }
}
