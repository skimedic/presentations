using System.Collections.Generic;
using SpyStore.Dal.Repos.Base;
using SpyStore.Models.Entities;
using SpyStore.Models.ViewModels;

namespace SpyStore.Dal.Repos.Interfaces
{
    public interface IShoppingCartRepo : IRepo<ShoppingCartRecord>
    {
        CartRecordWithProductInfo GetShoppingCartRecord(int id);
        IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId);
        CartWithCustomerInfo GetShoppingCartRecordsWithCustomer(int customerId);
        ShoppingCartRecord GetBy(int productId);
        int Update(ShoppingCartRecord entity, Product product, bool persist = true);
        int Add(ShoppingCartRecord entity, Product product, bool persist = true);
        int Purchase(int customerId);

    }
}