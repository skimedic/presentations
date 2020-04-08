using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using Microsoft.Extensions.Options;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Models.ViewModels;

namespace SpyStore.Hol.Mvc.Support
{
    public class SpyStoreServiceWrapper : ISpyStoreServiceWrapper
    {
        private HttpClient _client;
        private ServiceSettings _settings;

        public SpyStoreServiceWrapper(HttpClient client, IOptionsMonitor<ServiceSettings> settings)
        {
            _client = client;
            _settings = settings.CurrentValue;
            _client.BaseAddress = new Uri(_settings.Uri);
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<IList<Category>>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}/{id}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<Category>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<IList<ProductViewModel>> GetProductsForACategoryAsync(int categoryId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}/{categoryId}/products");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<IList<ProductViewModel>>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<IList<Order>> GetOrdersAsync(int customerId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.OrdersBaseUri}/{customerId}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<IList<Order>>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<OrderWithDetailsAndProductInfo> GetOrderDetailsAsync(int orderId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.OrderDetailsBaseUri}/{orderId}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<OrderWithDetailsAndProductInfo>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<ProductViewModel> GetOneProductAsync(int productId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.ProductBaseUri}/{productId}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<ProductViewModel>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<IList<ProductViewModel>> GetFeaturedProductsAsync()
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.ProductBaseUri}/featured");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<IList<ProductViewModel>>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<IList<ProductViewModel>> SearchAsync(string searchTerm)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.SearchBaseUri}/{searchTerm}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<IList<ProductViewModel>>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<IList<CartRecordWithProductInfo>> GetCartRecordsAsync(int id)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CartRecordBaseUri}/{id}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<IList<CartRecordWithProductInfo>>(await response.Content.ReadAsStreamAsync());

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
            var uri = $"{_settings.Uri}{_settings.CartRecordBaseUri}/{customerId}";
            var response = await PostAsJson(uri, JsonSerializer.Serialize(record));
            response.EnsureSuccessStatusCode();
        }

        public async Task<CartRecordWithProductInfo> UpdateShoppingCartRecord(int recordId, ShoppingCartRecord item)
        {
            var response = await PutAsJson($"{_settings.Uri}{_settings.CartRecordBaseUri}/{recordId}", JsonSerializer.Serialize(item));

            response.EnsureSuccessStatusCode();
            var location = response.Headers.Location.OriginalString;
            var updatedResponse = await _client.GetAsync(location);
            if (updatedResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            return await JsonSerializer.DeserializeAsync<CartRecordWithProductInfo>(await response.Content.ReadAsStreamAsync());
        }

        protected StringContent CreateStringContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public async Task RemoveCartItemAsync(int id, ShoppingCartRecord item)
        {
            var json = JsonSerializer.Serialize(item);
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

            var result = await JsonSerializer.DeserializeAsync<CartWithCustomerInfo>(await response.Content.ReadAsStreamAsync());

            return result;
        }

        public async Task<string> PurchaseAsync(int customerId, Customer customer)
        {
            var uri = $"{_settings.Uri}{_settings.CartBaseUri}/{customerId}/buy";
            var response = await PostAsJson(uri, JsonSerializer.Serialize(customer));

            response.EnsureSuccessStatusCode();
            return response.Headers.Location.Segments[3];
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CustomerBaseUri}/{customerId}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<Customer>(await response.Content.ReadAsStreamAsync());

            return null;
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CustomerBaseUri}");

            response.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<IList<Customer>>(await response.Content.ReadAsStreamAsync());

            return result;
        }
        internal async Task<HttpResponseMessage> PostAsJson(string uri, string json)
        {
            return await _client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
        }
        internal async Task<HttpResponseMessage> PutAsJson(string uri, string json)
        {
            return await _client.PutAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}