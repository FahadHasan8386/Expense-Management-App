using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IExpensesRepository
    {
        Task<List<Expenses>> AllExpensesAsync();
        Task<Expenses?> ExpensesByIdAsync(long expenseId);
        Task<List<Expenses>> ExpenseByCategoryIdAsync(long expenseCategoryId);
        Task<long> AddExpensesAsync(ExpensesDto expensesDto);
        Task<int> UpdateExpensesAsync(ExpensesDto expensesDto);
        Task<int> UpdateExpenseStatusAsync(long expenseId, bool status, string changeBy);
        Task<int> DeleteExpensesAsync(long expenseId);
        
    }
}
