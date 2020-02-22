using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("Store", Schema = "Sales")]
    public partial class Store
    {
        public Store()
        {
            Customer = new HashSet<Customer>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("SalesPersonID")]
        public int? SalesPersonId { get; set; }
        [Column(TypeName = "xml")]
        public string Demographics { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("Store")]
        public BusinessEntity BusinessEntity { get; set; }
        [ForeignKey("SalesPersonId")]
        [InverseProperty("Store")]
        public SalesPerson SalesPerson { get; set; }
        [InverseProperty("Store")]
        public ICollection<Customer> Customer { get; set; }
    }
}
