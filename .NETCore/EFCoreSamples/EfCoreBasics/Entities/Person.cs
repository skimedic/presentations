// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - Person.cs
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
    [Table("Person", Schema = "Person")]
    public partial class Person
    {
        public Person()
        {
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
            Customer = new HashSet<Customer>();
            EmailAddress = new HashSet<EmailAddress>();
            PersonCreditCard = new HashSet<PersonCreditCard>();
            PersonPhone = new HashSet<PersonPhone>();
        }

        [Key] [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        [Required] [StringLength(2)] public string PersonType { get; set; }

        public bool NameStyle { get; set; }

        [StringLength(8)] public string Title { get; set; }

        [Required] [StringLength(50)] public string FirstName { get; set; }

        [StringLength(50)] public string MiddleName { get; set; }

        [Required] [StringLength(50)] public string LastName { get; set; }

        [StringLength(10)] public string Suffix { get; set; }

        public int EmailPromotion { get; set; }

        [Column(TypeName = "xml")] public string AdditionalContactInfo { get; set; }

        [Column(TypeName = "xml")] public string Demographics { get; set; }

        [Column("rowguid")] public Guid Rowguid { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty("Person")]
        public virtual BusinessEntity BusinessEntity { get; set; }

        [InverseProperty("BusinessEntity")] public virtual Employee Employee { get; set; }

        [InverseProperty("BusinessEntity")] public virtual Password Password { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }

        [InverseProperty("Person")] public virtual ICollection<Customer> Customer { get; set; }

        [InverseProperty("BusinessEntity")] public virtual ICollection<EmailAddress> EmailAddress { get; set; }

        [InverseProperty("BusinessEntity")] public virtual ICollection<PersonCreditCard> PersonCreditCard { get; set; }

        [InverseProperty("BusinessEntity")] public virtual ICollection<PersonPhone> PersonPhone { get; set; }
    }
}