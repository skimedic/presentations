namespace AutoLot.Dal.Repos;

public class CreditRiskRepo : BaseRepo<CreditRisk>, ICreditRiskRepo
{
    public CreditRiskRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal CreditRiskRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
