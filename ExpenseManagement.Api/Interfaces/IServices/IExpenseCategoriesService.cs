using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IExpenseCategoriesService
    {
        Task<List<ExpenseCategories>> AllExpenseCategoriesAsync();
    }
}
