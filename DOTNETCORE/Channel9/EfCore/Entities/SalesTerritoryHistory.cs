// Copyright Information
// ==================================
// Channel9 - EfCore - SalesTerritoryHistory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/10
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    [Table("SalesTerritoryHistory", Schema = "Sales")]
    public partial class SalesTerritoryHistory
    {
        [Key] [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        [Key] [Column("TerritoryID")] public int TerritoryId { get; set; }

        [Key] [Column(TypeName = "datetime")] public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime")] public DateTime? EndDate { get; set; }

        [Column("rowguid")] public Guid Rowguid { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(SalesPerson.SalesTerritoryHistory))]
        public virtual SalesPerson BusinessEntity { get; set; }

        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(SalesTerritory.SalesTerritoryHistory))]
        public virtual SalesTerritory Territory { get; set; }
    }
}