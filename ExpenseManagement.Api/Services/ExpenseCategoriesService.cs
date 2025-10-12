using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Services
{
    public class ExpenseCategoriesService : IExpenseCategoriesService
    {
        private readonly IExpenseCategoriesRepository _expenseCategoriesRepository;

        public ExpenseCategoriesService(IExpenseCategoriesRepository expenseCategoriesRepository)
        {
            _expenseCategoriesRepository = expenseCategoriesRepository;
        }

        // Get all
        public async Task<List<ExpenseCategories>> AllExpenseCategoriesAsync()
        {
            return await _expenseCategoriesRepository.AllExpenseCategoriesAsync();
        }

        // Add new
        public async Task<ExpenseCategories> AddExpenseCategoriesAsync(ExpenseCategoriesDto category)
        {
            return await _expenseCategoriesRepository.AddExpenseCategoriesAsync(category);
        }

        // Update
        public async Task<int> UpdateExpenseCategoriesAsync(ExpenseCategoriesDto category)
        {
            return await _expenseCategoriesRepository.UpdateExpenseCategoriesAsync(category);
        }

        // Delete
        public async Task<int> DeleteExpenseCategoriesAsync(long expenseCategoryId)
        {
            return await _expenseCategoriesRepository.DeleteExpenseCategoriesAsync(expenseCategoryId);
        }
    }
}
