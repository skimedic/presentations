using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoLot.Models.Entities;
using Microsoft.Extensions.Options;

namespace AutoLot.Services.ApiWrapper
{
    public class ApiServiceWrapper : IApiServiceWrapper
    {
        private readonly HttpClient _client;
        private readonly ApiServiceSettings _settings;

        public ApiServiceWrapper(HttpClient client, IOptionsSnapshot<ApiServiceSettings> settings)
        {
            _client = client;
            _settings = settings.Value;
            _client.BaseAddress = new Uri(_settings.Uri);
        }

        public async Task<IList<Car>> GetCarsAsync()
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CarBaseUri}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IList<Car>>();
            //var result = await JsonSerializer.DeserializeAsync<IList<Category>>(await response.Content.ReadAsStreamAsync());
            return result;
        }

        public async Task<Car> GetCarAsync(int id)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CarBaseUri}/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Car>();
            return result;
        }

        public async Task<IList<Make>> GetMakesAsync()
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.MakeBaseUri}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IList<Make>>();
            return result;
        }

        public async Task<Car> UpdateCar(int id, Car entity)
        {
            var response = await PutAsJson($"{_settings.Uri}{_settings.CarBaseUri}/{id}",
                JsonSerializer.Serialize(entity));
            response.EnsureSuccessStatusCode();
            var location = response?.Headers?.Location?.OriginalString;
            var updatedResponse = await _client.GetAsync(location);
            if (updatedResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<Car>();
        }
        //    public async Task AddToCartAsync(int customerId, int productId, int quantity)
        //    {
        //        var record = new ShoppingCartRecord
        //        {
        //            ProductId = productId,
        //            CustomerId = customerId,
        //            Quantity = quantity
        //        };
        //        var uri = $"{_settings.Uri}{_settings.CartRecordBaseUri}/{customerId}";
        //        var response = await PostAsJson(uri, JsonSerializer.Serialize(record));
        //        response.EnsureSuccessStatusCode();
        //    }

        //    public async Task<CartRecordWithProductInfo> UpdateShoppingCartRecord(int recordId, ShoppingCartRecord item)
        //    {
        //        var response = await PutAsJson($"{_settings.Uri}{_settings.CartRecordBaseUri}/{recordId}", JsonSerializer.Serialize(item));

        //        response.EnsureSuccessStatusCode();
        //        var location = response.Headers.Location.OriginalString;
        //        var updatedResponse = await _client.GetAsync(location);
        //        if (updatedResponse.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            return null;
        //        }

        //        return await JsonSerializer.DeserializeAsync<CartRecordWithProductInfo>(await response.Content.ReadAsStreamAsync());
        //    }

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