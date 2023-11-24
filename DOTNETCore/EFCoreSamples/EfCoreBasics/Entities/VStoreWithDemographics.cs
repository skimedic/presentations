// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - VStoreWithDemographics.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

public partial class VStoreWithDemographics
{
    [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    [Column(TypeName = "money")] public decimal? AnnualSales { get; set; }

    [Column(TypeName = "money")] public decimal? AnnualRevenue { get; set; }

    [StringLength(50)] public string BankName { get; set; }

    [StringLength(5)] public string BusinessType { get; set; }

    public int? YearOpened { get; set; }

    [StringLength(50)] public string Specialty { get; set; }

    public int? SquareFeet { get; set; }

    [StringLength(30)] public string Brands { get; set; }

    [StringLength(30)] public string Internet { get; set; }

    public int? NumberEmployees { get; set; }
}