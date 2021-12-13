namespace AutoLot.Models.ViewModels.Configuration;

public class CustomerOrderViewModelConfiguration : IEntityTypeConfiguration<CustomerOrderViewModel>
{
    public void Configure(EntityTypeBuilder<CustomerOrderViewModel> builder)
    {
        builder.ToView("CustomerOrderView");
    }
}
