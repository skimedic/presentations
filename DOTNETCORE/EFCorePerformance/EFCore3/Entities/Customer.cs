using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Entities
{
    [Table("Customer", Schema = "Sales")]
    public partial class Customer
    {
        public Customer()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
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

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("Customer")]
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Customer")]
        public virtual Store Store { get; set; }
        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(SalesTerritory.Customer))]
        public virtual SalesTerritory Territory { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
