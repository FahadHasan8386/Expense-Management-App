using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;
using System.Net.Http.Json;

namespace ExpenseManagement.Web.Services
{
    public class HomeApiService
    {
        private readonly HttpClient _httpClient;

        public HomeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HomeViewModel> SearchUserAsync(QueryDto query)
        {
            var response = await _httpClient.PostAsJsonAsync("api/home/SerachByUser", query);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<HomeViewModel>();
        }
    }
}
