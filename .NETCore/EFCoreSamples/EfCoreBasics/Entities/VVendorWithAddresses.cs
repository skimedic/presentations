// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - VVendorWithAddresses.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities
{
    public partial class VVendorWithAddresses
    {
        [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        [Required] [StringLength(50)] public string AddressType { get; set; }

        [Required] [StringLength(60)] public string AddressLine1 { get; set; }

        [StringLength(60)] public string AddressLine2 { get; set; }

        [Required] [StringLength(30)] public string City { get; set; }

        [Required] [StringLength(50)] public string StateProvinceName { get; set; }

        [Required] [StringLength(15)] public string PostalCode { get; set; }

        [Required] [StringLength(50)] public string CountryRegionName { get; set; }
    }
}