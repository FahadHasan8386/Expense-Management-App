using System.Net.Http.Json;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Web.Services
{
    public class ExpenseApiService
    {
        private readonly HttpClient _httpClient;

        public ExpenseApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExpensesViewModel>> GetExpensesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ExpensesViewModel>>("Expenses/AllExpenses");
            return response ?? [];
        }

        public async Task<ExpensesViewModel> GetExpenseByIdAsync(long ExpenseId)
        {
            var response = await _httpClient.GetFromJsonAsync<ExpensesViewModel>($"Expenses/ExpensesById/{ExpenseId}");
            return response ?? new();
        }

        public async Task<ResponseModel> CreateExpenseAsync(ExpensesDto expensesDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Expenses/AddExpenses", expensesDto);
            Console.WriteLine($"Raw Response: {response}");
            return await response.Content.ReadFromJsonAsync<ResponseModel>() ?? new();
        }

        public async Task<ResponseModel> UpdateExpenseAsync(ExpensesDto expensesDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Expenses/UpdateExpenses", expensesDto);
            return await response.Content.ReadFromJsonAsync<ResponseModel>() ?? new();
        }

        public async Task<ResponseModel> DeleteExpensesAsync(long ExpenseId)
        {
            var response = await _httpClient.DeleteFromJsonAsync<ResponseModel>($"Expenses/DeleteExpenses/{ExpenseId}");
            return response ?? new();
        }

    }
}
    