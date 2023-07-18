// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - PersonCreditCard.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("PersonCreditCard", Schema = "Sales")]
public partial class PersonCreditCard
{
    [Key] [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

    [Key] [Column("CreditCardID")] public int CreditCardId { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(BusinessEntityId))]
    [InverseProperty(nameof(Person.PersonCreditCard))]
    public virtual Person BusinessEntity { get; set; }

    [ForeignKey(nameof(CreditCardId))]
    [InverseProperty("PersonCreditCard")]
    public virtual CreditCard CreditCard { get; set; }
}