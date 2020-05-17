using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Dal.Models.Entities.Base;

namespace AutoLot.Dal.Models.Entities
{
    [Table("CreditRisks",Schema = "Dbo")]
    public partial class CreditRisk : BaseEntity
    {
        public int CustomerId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.CreditRisks))]
        public Customer CustomerNavigation { get; set; }
    }
}
