using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Migrations.Models.Base;

namespace Migrations.Models
{
    [Table("CreditRisks", Schema = "Dbo")]
    public partial class CreditRisk : BaseEntity
    {
        [Required]
        public int CustomerId { get; set; }

        public Person PersonalInformation { get; set; } = new Person();

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.CreditRisks))]
        public Customer CustomerNavigation { get; set; }
    }
}
