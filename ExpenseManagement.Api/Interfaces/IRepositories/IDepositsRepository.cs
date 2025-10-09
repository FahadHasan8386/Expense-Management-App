using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IDepositsRepository
    {
        Task<List<Deposits>> GetAllDepositsAsync();
    }
}
