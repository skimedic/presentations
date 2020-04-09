// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - BusinessEntityContact.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities
{
    [Table("BusinessEntityContact", Schema = "Person")]
    public partial class BusinessEntityContact
    {
        [Key] [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        [Key] [Column("PersonID")] public int PersonId { get; set; }

        [Key] [Column("ContactTypeID")] public int ContactTypeId { get; set; }

        [Column("rowguid")] public Guid Rowguid { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty("BusinessEntityContact")]
        public virtual BusinessEntity BusinessEntity { get; set; }

        [ForeignKey(nameof(ContactTypeId))]
        [InverseProperty("BusinessEntityContact")]
        public virtual ContactType ContactType { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("BusinessEntityContact")]
        public virtual Person Person { get; set; }
    }
}