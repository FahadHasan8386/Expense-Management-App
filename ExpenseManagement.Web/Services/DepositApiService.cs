using System.Net.Http.Json;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Web.Services
{
    public class DepositApiService
    {
        private readonly HttpClient _httpClient;

        public DepositApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DepositViewModel>> GetDepositAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DepositViewModel>>("Deposits/GetAllDeposits");

            return response is null ? [] : response.ToList();
        }

        public async Task<DepositViewModel> GetDepositByIdAsync(long depositId)
        {
            var response = await _httpClient.GetFromJsonAsync<DepositViewModel>($"Deposits/GetDepositsById/{depositId}");

            return response is null ? new() : response;
        }

    }
}
