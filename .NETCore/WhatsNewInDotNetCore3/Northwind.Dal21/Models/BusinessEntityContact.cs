using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("BusinessEntityContact", Schema = "Person")]
    public partial class BusinessEntityContact
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("PersonID")]
        public int PersonId { get; set; }
        [Column("ContactTypeID")]
        public int ContactTypeId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("BusinessEntityContact")]
        public BusinessEntity BusinessEntity { get; set; }
        [ForeignKey("ContactTypeId")]
        [InverseProperty("BusinessEntityContact")]
        public ContactType ContactType { get; set; }
        [ForeignKey("PersonId")]
        [InverseProperty("BusinessEntityContact")]
        public Person Person { get; set; }
    }
}
