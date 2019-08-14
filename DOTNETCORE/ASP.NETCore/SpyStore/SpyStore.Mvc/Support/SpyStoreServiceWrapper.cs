using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpyStore.Models.Entities;
using SpyStore.Models.ViewModels;
using SpyStore.Mvc.Models.ViewModels;

namespace SpyStore.Mvc.Support
{
  public class SpyStoreServiceWrapper : ISpyStoreServiceWrapper
  {
    private readonly HttpClient _client;
    private readonly ServiceSettings _settings;

    public SpyStoreServiceWrapper(HttpClient client, IOptionsMonitor<ServiceSettings> settings)
    {
      _client = client;
      _settings = settings.CurrentValue;
      _client.BaseAddress = new Uri(_settings.Uri);
    }

    //Get Calls
    public async Task<CartWithCustomerInfo> GetCartAsync(int customerId)
    {
      HttpResponseMessage response = await _client.GetAsync($"{_settings.CartBaseUri}/{customerId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<CartWithCustomerInfo>();

      return result;
    }

    public async Task<IList<CartRecordWithProductInfo>> GetCartRecordsAsync(int id)
    {
      var response = await _client.GetAsync($"{_settings.CartRecordBaseUri}/{id}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<CartRecordWithProductInfo>>();

      return result;
    }

    public async Task<IList<Category>> GetCategoriesAsync()
    {
      var response = await _client.GetAsync($"{_settings.CategoryBaseUri}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<Category>>();

      return result;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
      var response = await _client.GetAsync($"{_settings.CategoryBaseUri}/{id}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<Category>();

      return result;
    }

    public async Task<Customer> GetCustomerAsync(int customerId)
    {
      var response = await _client.GetAsync($"{_settings.CustomerBaseUri}/{customerId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<Customer>();

      return null;
    }

    public async Task<IList<Customer>> GetCustomersAsync()
    {
      var response = await _client.GetAsync($"{_settings.CustomerBaseUri}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<Customer>>();

      return result;
    }

    public async Task<IList<ProductViewModel>> GetFeaturedProductsAsync()
    {
      var response = await _client.GetAsync($"{_settings.ProductBaseUri}/featured");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<ProductViewModel>>();

      return result;
    }

    public async Task<ProductViewModel> GetOneProductAsync(int productId)
    {
      var response = await _client.GetAsync($"{_settings.ProductBaseUri}/{productId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<ProductViewModel>();

      return result;
    }

    public async Task<OrderWithDetailsAndProductInfo> GetOrderDetailsAsync(int orderId)
    {
      var response = await _client.GetAsync($"{_settings.OrderDetailsBaseUri}/{orderId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<OrderWithDetailsAndProductInfo>();

      return result;
    }

    public async Task<IList<Order>> GetOrdersAsync(int customerId)
    {
      var response = await _client.GetAsync($"{_settings.OrdersBaseUri}/{customerId}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<Order>>();

      return result;
    }

    public async Task<IList<ProductViewModel>> GetProductsForACategoryAsync(int categoryId)
    {
      var response = await _client.GetAsync($"{_settings.CategoryBaseUri}/{categoryId}/products");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<ProductViewModel>>();

      return result;
    }

    public async Task<IList<ProductViewModel>> SearchAsync(string searchTerm)
    {
      var response = await _client.GetAsync($"{_settings.SearchBaseUri}/{searchTerm}");

      response.EnsureSuccessStatusCode();

      var result = await response.Content.ReadAsAsync<IList<ProductViewModel>>();

      return result;
    }


    //Post Calls
    public async Task AddToCartAsync(int customerId, int productId, int quantity)
    {
      var record = new ShoppingCartRecord
      {
        ProductId = productId,
        CustomerId = customerId,
        Quantity = quantity
      };
      var response =
        await _client.PostAsJsonAsync($"{_settings.CartRecordBaseUri}/{customerId}", record);
      response.EnsureSuccessStatusCode();
    }

    public async Task<string> PurchaseAsync(int customerId, Customer customer)
    {
      var response = await _client.PostAsJsonAsync($"{_settings.CartBaseUri}/{customerId}/buy", customer);

      response.EnsureSuccessStatusCode();
      return response.Headers.Location.Segments[3];
    }

    //Put
    public async Task<CartRecordWithProductInfo> UpdateShoppingCartRecordAsync(int recordId, ShoppingCartRecord item)
    {
      var response = await _client.PutAsJsonAsync($"{_settings.CartRecordBaseUri}/{recordId}", item);

      response.EnsureSuccessStatusCode();
      var location = response.Headers.Location.OriginalString;
      var updatedResponse = await _client.GetAsync(location);
      if (updatedResponse.StatusCode == HttpStatusCode.NotFound)
      {
        return null;
      }

      return await updatedResponse.Content.ReadAsAsync<CartRecordWithProductInfo>();
    }

    //Delete
    public async Task RemoveCartItemAsync(int id, ShoppingCartRecord item)
    {
      var json = JsonConvert.SerializeObject(item);
      HttpRequestMessage request = new HttpRequestMessage
      {
        Content = new StringContent(json, Encoding.UTF8, "application/json"),
        Method = HttpMethod.Delete,
        RequestUri = new Uri($"{_settings.CartRecordBaseUri}/{id}")
      };
      var response = await _client.SendAsync(request);
      response.EnsureSuccessStatusCode();
    }
  }
}