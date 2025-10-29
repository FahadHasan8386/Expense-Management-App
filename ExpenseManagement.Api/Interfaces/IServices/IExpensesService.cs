using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IExpensesService
    {
        Task<List<Expenses>> AllExpensesAsync();
        Task<List<Expenses>> ExpensesByIdAsync(long expenseId);
        Task<ResponseModel> AddExpensesAsync(ExpensesDto expensesDto);
        Task<ResponseModel> UpdateExpensesAsync(ExpensesDto expensesDto);
        Task<ResponseModel> DeleteExpensesAsync(long expenseId);
    }
}
