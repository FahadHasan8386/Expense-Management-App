using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;
using System.Net.Http.Json;

namespace ExpenseManagement.Web.Services
{
    public class ReportApiService
    {
        private readonly HttpClient _httpClient;

        public ReportApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReportViewModel?> SearchUserAsync(QueryDto query)
        {
            var response = await _httpClient.PostAsJsonAsync("Report/SerachByUser", query);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ReportViewModel>();
        }
    }
}
