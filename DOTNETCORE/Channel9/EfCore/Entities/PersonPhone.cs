// Copyright Information
// ==================================
// Channel9 - EfCore - PersonPhone.cs
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
    [Table("PersonPhone", Schema = "Person")]
    public partial class PersonPhone
    {
        [Key] [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        [Key] [StringLength(25)] public string PhoneNumber { get; set; }

        [Key] [Column("PhoneNumberTypeID")] public int PhoneNumberTypeId { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Person.PersonPhone))]
        public virtual Person BusinessEntity { get; set; }

        [ForeignKey(nameof(PhoneNumberTypeId))]
        [InverseProperty("PersonPhone")]
        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }
}