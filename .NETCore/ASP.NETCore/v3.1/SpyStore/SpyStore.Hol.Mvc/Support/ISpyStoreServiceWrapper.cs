using System.Collections.Generic;
using System.Threading.Tasks;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Models.ViewModels;

namespace SpyStore.Hol.Mvc.Support
{
    public interface ISpyStoreServiceWrapper
    {
        //CategoryController
        Task<IList<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);

        Task<IList<ProductViewModel>> GetProductsForACategoryAsync(int categoryId);

        ////Orders Controller
        Task<IList<Order>> GetOrdersAsync(int customerId);

        Task<OrderWithDetailsAndProductInfo> GetOrderDetailsAsync(int orderId);

        //Product Controller
        Task<ProductViewModel> GetOneProductAsync(int productId);

        Task<IList<ProductViewModel>> GetFeaturedProductsAsync();

        //Search Controller
        Task<IList<ProductViewModel>> SearchAsync(string searchTerm);

        //Shopping Cart Record Controller
        Task<IList<CartRecordWithProductInfo>> GetCartRecordsAsync(int id);
        Task AddToCartAsync(int customerId, int productId, int quantity);
        Task<CartRecordWithProductInfo> UpdateShoppingCartRecord(int recordId, ShoppingCartRecord item);

        Task RemoveCartItemAsync(int id, ShoppingCartRecord item);

        //Shopping Cart Controller
        Task<CartWithCustomerInfo> GetCartAsync(int customerId);

        Task<string> PurchaseAsync(int customerId, Customer customer);

        //Customer Controller
        Task<Customer> GetCustomerAsync(int customerId);
        Task<IList<Customer>> GetCustomersAsync();
    }
}