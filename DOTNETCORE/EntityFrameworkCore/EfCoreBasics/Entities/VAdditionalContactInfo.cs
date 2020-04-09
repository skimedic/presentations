// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - VAdditionalContactInfo.cs
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
    public partial class VAdditionalContactInfo
    {
        [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        [Required] [StringLength(50)] public string FirstName { get; set; }

        [StringLength(50)] public string MiddleName { get; set; }

        [Required] [StringLength(50)] public string LastName { get; set; }

        [StringLength(50)] public string TelephoneNumber { get; set; }

        public string TelephoneSpecialInstructions { get; set; }

        [StringLength(50)] public string Street { get; set; }

        [StringLength(50)] public string City { get; set; }

        [StringLength(50)] public string StateProvince { get; set; }

        [StringLength(50)] public string PostalCode { get; set; }

        [StringLength(50)] public string CountryRegion { get; set; }

        public string HomeAddressSpecialInstructions { get; set; }

        [Column("EMailAddress")]
        [StringLength(128)]
        public string EmailAddress { get; set; }

        [Column("EMailSpecialInstructions")] public string EmailSpecialInstructions { get; set; }

        [Column("EMailTelephoneNumber")]
        [StringLength(50)]
        public string EmailTelephoneNumber { get; set; }

        [Column("rowguid")] public Guid Rowguid { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }
    }
}