// Copyright Information
// ==================================
// Channel9 - EfCore - ContactType.cs
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
    [Table("ContactType", Schema = "Person")]
    public partial class ContactType
    {
        public ContactType()
        {
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
        }

        [Key] [Column("ContactTypeID")] public int ContactTypeId { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [InverseProperty("ContactType")]
        public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
    }
}