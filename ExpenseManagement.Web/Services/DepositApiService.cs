using System.Net.Http.Json;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.DtoModels;
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
            return response ?? new();
        }

        public async Task<DepositViewModel> GetDepositByIdAsync(long depositId)
        {
            var response = await _httpClient.GetFromJsonAsync<DepositViewModel>($"Deposits/GetDepositsById/{depositId}");
            return response ?? new();
        }

        public async Task<ResponseModel> AddDepositAsync(DepositDto depositDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Deposits/CreateDeposit", depositDto);
            return await response.Content.ReadFromJsonAsync<ResponseModel>() ?? new();
        }


        public async Task<ResponseModel> UpdateDepositAsync(DepositDto depositDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Deposits/UpdateDeposit", depositDto);
            return await response.Content.ReadFromJsonAsync<ResponseModel>() ?? new();
        }

        public async Task<ResponseModel> DeleteDepositsAsync(long depositId)
        {
            var response = await _httpClient.DeleteFromJsonAsync<ResponseModel>($"Deposits/DeleteDeposits/{depositId}");
            return response ?? new();
        }

    }
}
