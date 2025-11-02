using System.Net.Http.Json;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;
using ExpenseManagement.Web.Pages.ExpenseCategory;

namespace ExpenseManagement.Web.Services
{
    public class ExpenseCategoryApiService
    {
        private readonly HttpClient _httpClient;

        public ExpenseCategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExpenseCategoriesViewModel>> GetExpenseCategoriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ExpenseCategoriesViewModel>>("ExpenseCategories/AllExpenseCategories");
            return response ?? [];
        }
        public async Task<ExpenseCategoriesViewModel> GetExpenseCategoryByIdAsync(long expenseCategoryId)
        {
            var response = await _httpClient.GetFromJsonAsync<ExpenseCategoriesViewModel>($"ExpenseCategories/GetExpenseCategoriesById/{expenseCategoryId}");
            return response ?? new();
        }


        public async Task<ResponseModel> CreateExpenseCategoryAsync(ExpenseCategoriesDto expenseCategoriesDto)
        {
            var response = await _httpClient.PostAsJsonAsync("ExpenseCategories/AddExpenseCategories", expenseCategoriesDto);
            return await response.Content.ReadFromJsonAsync<ResponseModel>() ?? new();
        }


        public async Task<ResponseModel> UpdateExpenseCategoryAsync(ExpenseCategoriesDto expenseCategoriesDto)
        {
            var response = await _httpClient.PutAsJsonAsync("ExpenseCategories/UpdateExpenseCategories", expenseCategoriesDto);
            return await response.Content.ReadFromJsonAsync<ResponseModel>() ?? new();
        }

        public async Task<ResponseModel> UpdateExpenseCategoryStatusAsync(ExpenseCategoriesDto expenseCategoriesDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("ExpenseCategories/UpdateExpenseCategoryStatus", expenseCategoriesDto);
            return await response.Content.ReadFromJsonAsync<ResponseModel>() ?? new();
        }

        public async Task<ResponseModel> DeleteExpenseCategoriesAsync(long expenseCategoryId)
        {
            var response = await _httpClient.DeleteFromJsonAsync<ResponseModel>($"ExpenseCategories/DeleteExpenseCategories/{expenseCategoryId}");
            return response ?? new();
        }
    }
}
