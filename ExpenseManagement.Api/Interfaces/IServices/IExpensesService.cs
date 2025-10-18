using ExpenseManagement.Api.Models;
using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

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
