using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Api.Repository;

namespace ExpenseManagement.Api.Services
{
    public class ExpenseCategoriesService : IExpenseCategoriesService
    {
        public readonly IExpenseCategoriesRepository _expenseCategoriesRepository;

        public ExpenseCategoriesService (IExpenseCategoriesRepository expenseCategoriesRepository)
        {
            _expenseCategoriesRepository = expenseCategoriesRepository;
        }

        public async Task<List<ExpenseCategories>> AllExpenseCategoriesAsync()
        {
            var response = await _expenseCategoriesRepository.AllExpenseCategoriesAsync();
            return response;
        }
    }
}
