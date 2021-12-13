namespace AutoLot.Models.Entities;

[Table("CreditRisks", Schema = "dbo")]
[Index(nameof(CustomerId), Name = "IX_CreditRisks_CustomerId")]
[EntityTypeConfiguration(typeof(CreditRiskConfiguration))]
public partial class CreditRisk : BaseEntity
{
    public Person PersonInformation { get; set; } = new Person();

    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    [InverseProperty(nameof(Customer.CreditRisks))]
    public virtual Customer CustomerNavigation { get; set; }
}
