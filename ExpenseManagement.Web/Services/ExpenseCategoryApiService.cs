using System.Net.Http.Json;
using ExpenseManagement.Shared.Models.ViewModel;

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
            return response ?? new();
        }
        public async Task<ExpenseCategoriesViewModel> GetExpenseCategoryByIdAsync(long expenseCategoryId)
        {
            var response = await _httpClient.GetFromJsonAsync<ExpenseCategoriesViewModel>($"/ExpenseCategories/GetExpenseCategoriesById/{expenseCategoryId}");
            return response ?? new();
        }
    }
}
