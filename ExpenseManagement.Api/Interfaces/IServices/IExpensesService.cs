using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.DtoModels;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IExpensesService
    {
        Task<List<Expenses>> AllExpensesAsync();
        Task<Expenses?> ExpensesByIdAsync(long expenseId);
        Task<List<Expenses>> ExpensesByCategoryIdAync(long expenseCategoryId);
        Task<ResponseModel> AddExpensesAsync(ExpensesDto expensesDto);
        Task<ResponseModel> UpdateExpensesAsync(ExpensesDto expensesDto);
        Task<ResponseModel> ExpenseInActiveAsync(long expenseId, string changeBy);
        Task<ResponseModel> DeleteExpensesAsync(long expenseId);
    }
}
