using ExpenseManagement.Api.Models;
using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

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
