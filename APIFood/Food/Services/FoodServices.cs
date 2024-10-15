using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Food.Models;

namespace Food.Services
{
    public class FoodService
    {
        private readonly HttpClient _httpClient;

        public FoodService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5190/"); // Đặt BaseAddress
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Foods>> GetAllFoodsAsync()
        {
            var response = await _httpClient.GetAsync("api/Food");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            // Sửa đoạn này để sử dụng đúng phương thức Deserialize
            return JsonSerializer.Deserialize<List<Foods>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}
