// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - PhoneNumberType.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("PhoneNumberType", Schema = "Person")]
public partial class PhoneNumberType
{
    public PhoneNumberType()
    {
        PersonPhone = new HashSet<PersonPhone>();
    }

    [Key] [Column("PhoneNumberTypeID")] public int PhoneNumberTypeId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("PhoneNumberType")] public virtual ICollection<PersonPhone> PersonPhone { get; set; }
}