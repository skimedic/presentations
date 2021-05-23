using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
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

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [StringLength(2)]
        public string PersonType { get; set; }
        [Column(TypeName = "NameStyle")]
        public bool NameStyle { get; set; }
        [StringLength(8)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        [Column(TypeName = "xml")]
        public string AdditionalContactInfo { get; set; }
        [Column(TypeName = "xml")]
        public string Demographics { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("Person")]
        public BusinessEntity BusinessEntity { get; set; }
        [InverseProperty("BusinessEntity")]
        public Employee Employee { get; set; }
        [InverseProperty("BusinessEntity")]
        public Password Password { get; set; }
        [InverseProperty("Person")]
        public ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
        [InverseProperty("Person")]
        public ICollection<Customer> Customer { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<EmailAddress> EmailAddress { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<PersonCreditCard> PersonCreditCard { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<PersonPhone> PersonPhone { get; set; }
    }
}
