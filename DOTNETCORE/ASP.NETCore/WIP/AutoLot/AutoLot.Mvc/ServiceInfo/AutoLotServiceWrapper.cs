using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Models.Entities.Base;
using Microsoft.Extensions.Options;

namespace AutoLot.Mvc.ServiceInfo
{
    public class AutoLotServiceWrapper : IAutoLotServiceWrapper
    {
        private readonly HttpClient _client;
        private readonly ServiceSettings _settings;

        public AutoLotServiceWrapper(HttpClient client, IOptionsMonitor<ServiceSettings> settings)
        {
            _settings = settings.CurrentValue;
            _client = client;
        }

        internal string GetBaseUri<T>(T entity) where T : BaseEntity, new()
            => entity switch
            {
                Car c => $"{_settings.BaseUri}/{_settings.CarBaseUri}",
                CreditRisk cr => $"{_settings.BaseUri}/{_settings.CreditRiskBaseUri}",
                Customer cu => $"{_settings.BaseUri}/{_settings.CustomerBaseUri}",
                Make m => $"{_settings.BaseUri}/{_settings.MakeBaseUri}",
                Order o => $"{_settings.BaseUri}/{_settings.OrderBaseUri}",
                _ => null
            };
        internal async Task<HttpResponseMessage> PostAsJsonAsync(string uri, string json)
            => await _client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));

        internal async Task<HttpResponseMessage> PutAsJsonAsync(string uri, string json)
            => await _client.PutAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));

        internal async Task<HttpResponseMessage> DeleteAsJsonAsync(string uri, string json)
        {
            var request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(uri)
            };
            return await _client.SendAsync(request);
        }

        public async Task<List<T>> GetAllAsync<T>() where T : BaseEntity, new()
        {
            string uri = GetBaseUri(new T());
            if (uri == null)
            {
                return null;
            }
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<List<T>>(await response.Content.ReadAsStreamAsync());
        }
        public async Task<T> GetOneAsync<T>(int id) where T : BaseEntity, new()
        {
            string uri = GetBaseUri(new T());
            if (uri == null)
            {
                return null;
            }
            var response = await _client.GetAsync($"{uri}/{id}");
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
        }
        public async Task<List<Car>> GetCarsByMakeAsync(int makeId)
        {
            var response = await _client.GetAsync($"{_settings.BaseUri}/{_settings.CarBaseUri}/bymake/{makeId}");
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<List<Car>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<T> AddOneAsync<T>(T entity) where T : BaseEntity, new()
        {
            string uri = GetBaseUri(entity);
            if (uri == null)
            {
                return null;
            }
            var response = await PostAsJsonAsync($"{uri}", JsonSerializer.Serialize(entity));
            response.EnsureSuccessStatusCode();
            //OPTIONAL: Get Header Information
            return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
        }
        public async Task<T> UpdateOneAsync<T>(T entity) where T : BaseEntity, new()
        {
            string uri = GetBaseUri(entity);
            if (uri == null)
            {
                return null;
            }
            var response = await PutAsJsonAsync($"{uri}/{entity.Id}", JsonSerializer.Serialize(entity));
            response.EnsureSuccessStatusCode();
            var result = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
            return result;
        }

        public async Task DeleteOneAsync<T>(T entity) where T : BaseEntity, new()
        {
            string uri = GetBaseUri(entity);
            if (uri == null)
            {
                return;
            }
            var response = await DeleteAsJsonAsync($"{uri}/{entity.Id}", JsonSerializer.Serialize(entity));
            response.EnsureSuccessStatusCode();
        }
    }
}
