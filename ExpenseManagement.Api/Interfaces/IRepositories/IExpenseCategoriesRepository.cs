using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IExpenseCategoriesRepository
    {
        Task<List<ExpenseCategories>> AllExpenseCategoriesAsync();
        Task<long> AddExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto);
        Task<int> UpdateExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto);
        Task<int> DeleteExpenseCategoriesAsync(long expenseCategoryId);
    }
}
