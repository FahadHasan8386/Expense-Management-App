using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IDepositsRepository
    {
        Task<List<Deposits>> GetAllDepositsAsync();
        Task<long> AddDepositsAsync(DepositDto deposit);
        Task<int> UpdateDepositsAsync(DepositDto deposit);
        Task<int> DeleteDepositsAsync(long DepositId);
    }
}
