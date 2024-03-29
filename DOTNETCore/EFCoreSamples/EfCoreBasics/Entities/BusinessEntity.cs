﻿// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - BusinessEntity.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("BusinessEntity", Schema = "Person")]
public partial class BusinessEntity
{
    public BusinessEntity()
    {
        BusinessEntityAddress = new HashSet<BusinessEntityAddress>();
        BusinessEntityContact = new HashSet<BusinessEntityContact>();
    }

    [Key] [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

    [Column("rowguid")] public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("BusinessEntity")] public virtual Person Person { get; set; }

    [InverseProperty("BusinessEntity")] public virtual Store Store { get; set; }

    [InverseProperty("BusinessEntity")] public virtual Vendor Vendor { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
}