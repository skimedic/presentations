using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("Shift", Schema = "HumanResources")]
    public partial class Shift
    {
        public Shift()
        {
            EmployeeDepartmentHistory = new HashSet<EmployeeDepartmentHistory>();
        }

        [Column("ShiftID")]
        public byte ShiftId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Shift")]
        public ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
    }
}
