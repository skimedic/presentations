using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal.Models
{
    public partial class VEmployee
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [StringLength(8)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string Suffix { get; set; }
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string PhoneNumberType { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        public int EmailPromotion { get; set; }
        [Required]
        [StringLength(60)]
        public string AddressLine1 { get; set; }
        [StringLength(60)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string StateProvinceName { get; set; }
        [Required]
        [StringLength(15)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(50)]
        public string CountryRegionName { get; set; }
        [Column(TypeName = "xml")]
        public string AdditionalContactInfo { get; set; }
    }
}
