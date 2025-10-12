using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IExpenseCategoriesRepository
    {
        Task<List<ExpenseCategories>> AllExpenseCategoriesAsync();
        Task<ExpenseCategories> AddExpenseCategoriesAsync(ExpenseCategoriesDto category);
        Task<int> UpdateExpenseCategoriesAsync(ExpenseCategoriesDto category);
        Task<int> DeleteExpenseCategoriesAsync(long expenseCategoryId);
    }
}
