// Copyright Information
// ==================================
// Channel9 - EfCore - VEmployeeDepartmentHistory.cs
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
    public partial class VEmployeeDepartmentHistory
    {
        [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        [StringLength(8)] public string Title { get; set; }

        [Required] [StringLength(50)] public string FirstName { get; set; }

        [StringLength(50)] public string MiddleName { get; set; }

        [Required] [StringLength(50)] public string LastName { get; set; }

        [StringLength(10)] public string Suffix { get; set; }

        [Required] [StringLength(50)] public string Shift { get; set; }

        [Required] [StringLength(50)] public string Department { get; set; }

        [Required] [StringLength(50)] public string GroupName { get; set; }

        [Column(TypeName = "date")] public DateTime StartDate { get; set; }

        [Column(TypeName = "date")] public DateTime? EndDate { get; set; }
    }
}