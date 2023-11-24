// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - VStoreWithContacts.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

public partial class VStoreWithContacts
{
    [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    [Required] [StringLength(50)] public string ContactType { get; set; }

    [StringLength(8)] public string Title { get; set; }

    [Required] [StringLength(50)] public string FirstName { get; set; }

    [StringLength(50)] public string MiddleName { get; set; }

    [Required] [StringLength(50)] public string LastName { get; set; }

    [StringLength(10)] public string Suffix { get; set; }

    [StringLength(25)] public string PhoneNumber { get; set; }

    [StringLength(50)] public string PhoneNumberType { get; set; }

    [StringLength(50)] public string EmailAddress { get; set; }

    public int EmailPromotion { get; set; }
}