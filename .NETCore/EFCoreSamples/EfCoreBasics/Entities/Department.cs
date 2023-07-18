// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - Department.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("Department", Schema = "HumanResources")]
public partial class Department
{
    public Department()
    {
        EmployeeDepartmentHistory = new HashSet<EmployeeDepartmentHistory>();
    }

    [Key] [Column("DepartmentID")] public short DepartmentId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    [Required] [StringLength(50)] public string GroupName { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
}