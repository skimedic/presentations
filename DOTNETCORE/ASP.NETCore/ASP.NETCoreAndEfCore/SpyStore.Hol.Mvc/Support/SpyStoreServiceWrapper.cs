using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Models.ViewModels;

namespace SpyStore.Hol.Mvc.Support
{
  public class SpyStoreServiceWrapper : ISpyStoreServiceWrapper
  {
    private HttpClient _client;
    private ServiceSettings _settings;

    public SpyStoreServiceWrapper(HttpClient client, IOptionsSnapshot<ServiceSettings> settings)
    {
      _client = client;
      _settings = settings.Value;
      _client.BaseAddress = new Uri(_settings.Uri);
    }

    public async Task<IList<Category>> GetCategoriesAsync()
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<Category>>();

      return result;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}/{id}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<Category>();

      return result;
    }

    public async Task<IList<ProductViewModel>> GetProductsForACategoryAsync(int categoryId)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}/{categoryId}/products");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<ProductViewModel>>();

      return result;
    }

    public async Task<IList<Order>> GetOrdersAsync(int customerId)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.OrdersBaseUri}/{customerId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<Order>>();

      return result;
    }

    public async Task<OrderWithDetailsAndProductInfo> GetOrderDetailsAsync(int orderId)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.OrderDetailsBaseUri}/{orderId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<OrderWithDetailsAndProductInfo>();

      return result;
    }

    public async Task<ProductViewModel> GetOneProductAsync(int productId)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.ProductBaseUri}/{productId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<ProductViewModel>();

      return result;
    }

    public async Task<IList<ProductViewModel>> GetFeaturedProductsAsync()
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.ProductBaseUri}/featured");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<ProductViewModel>>();

      return result;
    }

    public async Task<IList<ProductViewModel>> SearchAsync(string searchTerm)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.SearchBaseUri}/{searchTerm}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<ProductViewModel>>();

      return result;
    }

    public async Task<IList<CartRecordWithProductInfo>> GetCartRecordsAsync(int id)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.CartRecordBaseUri}/{id}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<CartRecordWithProductInfo>>();

      return result;
    }

    public async Task AddToCartAsync(int customerId, int productId, int quantity)
    {
      var record = new ShoppingCartRecord
      {
        ProductId = productId,
        CustomerId = customerId,
        Quantity = quantity
      };
      var response =
        await _client.PostAsJsonAsync($"{_settings.Uri}{_settings.CartRecordBaseUri}/{customerId}", record);
      response.EnsureSuccessStatusCode();
    }

    public async Task<CartRecordWithProductInfo> UpdateShoppingCartRecord(int recordId, ShoppingCartRecord item)
    {
      var response = await _client.PutAsJsonAsync($"{_settings.Uri}{_settings.CartRecordBaseUri}/{recordId}", item);

      response.EnsureSuccessStatusCode();
      var location = response.Headers.Location.OriginalString;
      var updatedResponse = await _client.GetAsync(location);
      if (updatedResponse.StatusCode == HttpStatusCode.NotFound)
      {
        return null;
      }

      return await updatedResponse.Content.ReadAsAsync<CartRecordWithProductInfo>();
    }

    protected StringContent CreateStringContent(string json)
    {
      return new StringContent(json, Encoding.UTF8, "application/json");
    }

    public async Task RemoveCartItemAsync(int id, ShoppingCartRecord item)
    {
      var json = JsonConvert.SerializeObject(item);
      HttpRequestMessage request = new HttpRequestMessage
      {
        Content = CreateStringContent(json),
        Method = HttpMethod.Delete,
        RequestUri = new Uri($"{_settings.Uri}{_settings.CartRecordBaseUri}/{id}")
      };
      var response = await _client.SendAsync(request);
      response.EnsureSuccessStatusCode();
    }

    public async Task<CartWithCustomerInfo> GetCartAsync(int customerId)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.CartBaseUri}/{customerId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<CartWithCustomerInfo>();

      return result;
    }

    public async Task<string> PurchaseAsync(int customerId, Customer customer)
    {
      var response = await _client.PostAsJsonAsync($"{_settings.Uri}{_settings.CartBaseUri}/{customerId}/buy", customer);

      response.EnsureSuccessStatusCode();
      return response.Headers.Location.Segments[3];
    }

    public async Task<Customer> GetCustomerAsync(int customerId)
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.CustomerBaseUri}/{customerId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<Customer>();

      return null;
    }

    public async Task<IList<Customer>> GetCustomersAsync()
    {
      var response = await _client.GetAsync($"{_settings.Uri}{_settings.CustomerBaseUri}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<Customer>>();

      return result;
    }
  }
}