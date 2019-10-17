namespace BookShop.AcceptanceTests.Support
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceBooks = new ReferenceBookList();
        }

        public ReferenceBookList ReferenceBooks { get; set; }
    }
}
