using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
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
        public virtual BusinessEntity BusinessEntity { get; set; }
        [ForeignKey("ContactTypeId")]
        [InverseProperty("BusinessEntityContact")]
        public virtual ContactType ContactType { get; set; }
        [ForeignKey("PersonId")]
        [InverseProperty("BusinessEntityContact")]
        public virtual Person Person { get; set; }
    }
}
