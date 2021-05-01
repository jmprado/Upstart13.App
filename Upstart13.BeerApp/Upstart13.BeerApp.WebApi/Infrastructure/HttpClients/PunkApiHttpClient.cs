using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Upstart13.BeerApp.ViewModel;

namespace Upstart13.BeerApp.Infrastructure.HttpClients
{
    public interface IPunkApiHttpClient
    {
        Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync(string cityName);
    }

    public class PunkApiHttpClient : IPunkApiHttpClient
    {
        private readonly HttpClient _client;
        private readonly PunkApiSettings _settings;

        public PunkApiHttpClient(HttpClient client, PunkApiSettings settings)
        {
            _client = client;
            _settings = settings;
            _client.BaseAddress = new Uri(_settings.BaseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync(string cityName)
        {
            var url = $"v2/beers?page=1&per_page={_settings.ItemnsPerPage}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var listBeers = JsonConvert.DeserializeObject<IEnumerable<PunkApiBeerModel>>(content);
            return listBeers;
        }
    }

    public class PunkApiSettings
    {
        public string BaseUrl { get; set; }

        public int ItemnsPerPage { get; set; }
    }
}