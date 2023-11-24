// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - TransactionHistoryArchive.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("TransactionHistoryArchive", Schema = "Production")]
public partial class TransactionHistoryArchive
{
    [Key] [Column("TransactionID")] public int TransactionId { get; set; }

    [Column("ProductID")] public int ProductId { get; set; }

    [Column("ReferenceOrderID")] public int ReferenceOrderId { get; set; }

    [Column("ReferenceOrderLineID")] public int ReferenceOrderLineId { get; set; }

    [Column(TypeName = "datetime")] public DateTime TransactionDate { get; set; }

    [Required] [StringLength(1)] public string TransactionType { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "money")] public decimal ActualCost { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }
}