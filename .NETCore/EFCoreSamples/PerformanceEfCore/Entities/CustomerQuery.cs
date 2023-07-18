// 

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities;

public partial class CustomerQuery
{
    public CustomerQuery()
    {
    }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }
    [Column("PersonID")]
    public int? PersonId { get; set; }
    [Column("StoreID")]
    public int? StoreId { get; set; }
    [Column("TerritoryID")]
    public int? TerritoryId { get; set; }
    [Required]
    [StringLength(10)]
    public string AccountNumber { get; set; }
    [Column("rowguid")]
    public Guid Rowguid { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}