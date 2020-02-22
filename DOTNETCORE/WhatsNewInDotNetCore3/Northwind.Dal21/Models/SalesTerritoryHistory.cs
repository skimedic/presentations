using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("SalesTerritoryHistory", Schema = "Sales")]
    public partial class SalesTerritoryHistory
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("SalesTerritoryHistory")]
        public SalesPerson BusinessEntity { get; set; }
        [ForeignKey("TerritoryId")]
        [InverseProperty("SalesTerritoryHistory")]
        public SalesTerritory Territory { get; set; }
    }
}
