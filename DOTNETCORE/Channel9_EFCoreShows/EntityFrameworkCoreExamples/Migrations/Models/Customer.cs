using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Migrations.Models.Base;

namespace Migrations.Models
{
    [Table("Customers",Schema = "Dbo")]
    public partial class Customer : BaseEntity
    {
        public Person PersonalInformation { get; set; } = new Person();

        [InverseProperty(nameof(CreditRisk.CustomerNavigation))]
        public IEnumerable<CreditRisk> CreditRisks { get; set; } = new List<CreditRisk>();

        [InverseProperty(nameof(Order.CustomerNavigation))]
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        [NotMapped]
        public string FullName => $"{PersonalInformation.FirstName} {PersonalInformation.LastName}";

    }
}
