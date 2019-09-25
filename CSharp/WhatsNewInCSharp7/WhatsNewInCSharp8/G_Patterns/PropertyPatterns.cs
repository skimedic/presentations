namespace WhatsNewInCSharp8.B_Patterns
{
    public class Address
    {
        public string? State { get; set; }
        public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
            location switch
                {
                { State: "WA" } => salePrice * 0.06M,
                { State: "MN" } => salePrice * 0.75M,
                { State: "MI" } => salePrice * 0.05M,
                // other cases removed for brevity...
                _ => 0M
                };
    }
}