// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Models - CreditRisk.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Models.Entities;

[Table("CreditRisks", Schema = "dbo")]
[Index(nameof(CustomerId), Name = "IX_CreditRisks_CustomerId")]
[EntityTypeConfiguration(typeof(CreditRiskConfiguration))]
public class CreditRisk : BaseEntity
{
    public Person PersonInformation { get; set; } = new Person();

    public int CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    [InverseProperty(nameof(Customer.CreditRisks))]
    public Customer CustomerNavigation { get; set; }
}