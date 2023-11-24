// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - CountryRegionCurrency.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("CountryRegionCurrency", Schema = "Sales")]
public partial class CountryRegionCurrency
{
    [Key] [StringLength(3)] public string CountryRegionCode { get; set; }

    [Key] [StringLength(3)] public string CurrencyCode { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(CountryRegionCode))]
    [InverseProperty(nameof(CountryRegion.CountryRegionCurrency))]
    public virtual CountryRegion CountryRegionCodeNavigation { get; set; }

    [ForeignKey(nameof(CurrencyCode))]
    [InverseProperty(nameof(Currency.CountryRegionCurrency))]
    public virtual Currency CurrencyCodeNavigation { get; set; }
}