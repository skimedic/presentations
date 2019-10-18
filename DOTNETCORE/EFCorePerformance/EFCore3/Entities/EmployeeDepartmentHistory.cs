using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Entities
{
    [Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
    public partial class EmployeeDepartmentHistory
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column("DepartmentID")]
        public short DepartmentId { get; set; }
        [Key]
        [Column("ShiftID")]
        public byte ShiftId { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Employee.EmployeeDepartmentHistory))]
        public virtual Employee BusinessEntity { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("EmployeeDepartmentHistory")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(ShiftId))]
        [InverseProperty("EmployeeDepartmentHistory")]
        public virtual Shift Shift { get; set; }
    }
}
