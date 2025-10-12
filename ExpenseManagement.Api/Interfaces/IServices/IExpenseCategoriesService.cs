using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IExpenseCategoriesService
    {
        Task<List<ExpenseCategories>> AllExpenseCategoriesAsync();
        Task<ExpenseCategories> AddExpenseCategoriesAsync(ExpenseCategoriesDto category);
        Task<int> UpdateExpenseCategoriesAsync(ExpenseCategoriesDto category);
        Task<int> DeleteExpenseCategoriesAsync(long expenseCategoryId);
    }
}
