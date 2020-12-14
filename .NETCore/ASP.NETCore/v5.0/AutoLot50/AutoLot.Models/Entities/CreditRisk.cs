// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - CreditRisk.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Models.Entities.Base;
using AutoLot.Models.Entities.Owned;

namespace AutoLot.Models.Entities
{
    [Table("CreditRisks", Schema = "Dbo")]
    public partial class CreditRisk : BaseEntity
    {
        public Person PersonalInformation { get; set; } = new Person();
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.CreditRisks))]
        public virtual Customer? CustomerNavigation { get; set; }
    }
}
