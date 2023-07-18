// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - VProductModelInstructions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

public partial class VProductModelInstructions
{
    [Column("ProductModelID")] public int ProductModelId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    public string Instructions { get; set; }

    [Column("LocationID")] public int? LocationId { get; set; }

    [Column(TypeName = "decimal(9, 4)")] public decimal? SetupHours { get; set; }

    [Column(TypeName = "decimal(9, 4)")] public decimal? MachineHours { get; set; }

    [Column(TypeName = "decimal(9, 4)")] public decimal? LaborHours { get; set; }

    public int? LotSize { get; set; }

    [StringLength(1024)] public string Step { get; set; }

    [Column("rowguid")] public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }
}