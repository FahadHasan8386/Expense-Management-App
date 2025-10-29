using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IExpenseCategoriesRepository
    {
        Task<List<ExpenseCategories>> AllExpenseCategoriesAsync();
        Task<List<ExpenseCategories>> GetExpenseCategoriesByIdAsync(long expenseCategoryId);
        Task<long> AddExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto);
        Task<int> UpdateExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto);
        Task<int> DeleteExpenseCategoriesAsync(long expenseCategoryId);
    }
}
