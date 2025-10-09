using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IExpenseCategoriesRepository
    {
        Task<List<ExpenseCategories>> AllExpenseCategoriesAsync();
    }
}
