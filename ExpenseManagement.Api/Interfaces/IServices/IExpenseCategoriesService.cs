using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IExpenseCategoriesService
    {
        Task<List<ExpenseCategories>> AllExpenseCategoriesAsync();
        Task<ExpenseCategories> AddExpenseCategoriesAsync(ExpenseCategories category);
        Task<int> UpdateExpenseCategoriesAsync(ExpenseCategories category);
        Task<int> DeleteExpenseCategoriesAsync(long expenseCategoryId);
    }
}
