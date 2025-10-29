using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IExpenseCategoriesService
    {
        Task<List<ExpenseCategories>> AllExpenseCategoriesAsync();
        Task<List<ExpenseCategories>> GetExpenseCategoriesByIdAsync(long expenseCategoryId);
        Task<ResponseModel> AddExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto);
        Task<ResponseModel> UpdateExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto);
        Task<ResponseModel> DeleteExpenseCategoriesAsync(long expenseCategoryId);
    }
}
