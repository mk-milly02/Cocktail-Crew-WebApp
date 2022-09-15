using CocktailApplication.Domain;
using Newtonsoft.Json;

namespace CocktailApplication.Service
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;

        public ApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Drink>?> Filter(string category)
        {
            string uri = $"www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}";
            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(result)!.Drinks;
            }

            return null;
        }

        public async Task<IEnumerable<Drink>?> GetAllIngredients()
        {
            string uri = "www.thecocktaildb.com/api/json/v1/1/list.php?i=list";
            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(result)!.Drinks;
            }

            return null;
        }

        public async Task<Drink?> Lookup()
        {
            string uri = $"www.thecocktaildb.com/api/json/v1/1/random.php";
            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(result)!.Drinks.FirstOrDefault();
            }

            return null;
        }

        public async Task<IEnumerable<Drink>?> Search(string name)
        {
            string uri = $"www.thecocktaildb.com/api/json/v1/1/search.php?s={name}";
            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(result)!.Drinks;
            }

            return null;
        }
    }
}