﻿// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - CreditCard.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("CreditCard", Schema = "Sales")]
public partial class CreditCard
{
    public CreditCard()
    {
        PersonCreditCard = new HashSet<PersonCreditCard>();
        SalesOrderHeader = new HashSet<SalesOrderHeader>();
    }

    [Key] [Column("CreditCardID")] public int CreditCardId { get; set; }

    [Required] [StringLength(50)] public string CardType { get; set; }

    [Required] [StringLength(25)] public string CardNumber { get; set; }

    public byte ExpMonth { get; set; }
    public short ExpYear { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("CreditCard")] public virtual ICollection<PersonCreditCard> PersonCreditCard { get; set; }

    [InverseProperty("CreditCard")] public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
}