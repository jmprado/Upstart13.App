using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Upstart13.BeerApp.ViewModel;

namespace Upstart13.BeerApp.Infrastructure.HttpClients
{
    public interface IPunkApiHttpClient
    {
        Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync();
        Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync(int page);
        Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync(int page, int itemsPerPage);
        Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync(SearchBeerModel searchBeerModel);
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

        public async Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync()
        {
            var url = $"beers?page=1&per_page={_settings.ItemsPerPage}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var listBeers = JsonConvert.DeserializeObject<IEnumerable<PunkApiBeerModel>>(content);
            return listBeers;
        }

        public async Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync(int page)
        {
            var url = $"beers?page={page}&per_page={_settings.ItemsPerPage}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var listBeers = JsonConvert.DeserializeObject<IEnumerable<PunkApiBeerModel>>(content);
            return listBeers;
        }

        public async Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync(int page, int itemsPerPage)
        {
            var url = $"beers?page={page}&per_page={itemsPerPage}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var listBeers = JsonConvert.DeserializeObject<IEnumerable<PunkApiBeerModel>>(content);
            return listBeers;
        }

        public async Task<IEnumerable<PunkApiBeerModel>> GetBeersAsync(SearchBeerModel searchBeerModel)
        {
            var listBeers = await GetBeersAsync();

            if (searchBeerModel.AttenuationLevel.HasValue)
                listBeers = listBeers.Where(c => c.AttenuationLevel == searchBeerModel.AttenuationLevel.Value).ToList();

            if (searchBeerModel.Ph.HasValue)
                listBeers = listBeers.Where(c => c.Ph == searchBeerModel.Ph.Value).ToList();

            if (searchBeerModel.Volume.HasValue)
                listBeers = listBeers.Where(c => c.Volume.Value == searchBeerModel.Volume.Value).ToList();

            if (!string.IsNullOrEmpty(searchBeerModel.IngredientName))
                listBeers = listBeers.Where(
                    c => c.Ingredients.Hops.Any(h => h.Name == searchBeerModel.IngredientName) ||
                    c.Ingredients.Malt.Any(m => m.Name == searchBeerModel.IngredientName) ||
                    c.Ingredients.Yeast == searchBeerModel.IngredientName)
                    .ToList();

            return listBeers;
        }
    }

    public class PunkApiSettings
    {
        public string BaseUrl { get; set; }

        public int ItemsPerPage { get; set; }
    }
}