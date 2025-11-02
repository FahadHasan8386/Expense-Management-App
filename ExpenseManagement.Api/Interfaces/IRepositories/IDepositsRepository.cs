using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models.DtoModels;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IDepositsRepository
    {
        Task<List<Deposits>> GetAllDepositsAsync();
        Task<Deposits?> GetDepositsByIdAsync(long depositId);
        Task<long> AddDepositsAsync(DepositDto deposit);
        Task<int> UpdateDepositsAsync(DepositDto DepositDto);
        Task<int> UpdateDepositStatusAsync(long depositId, bool status, string changedBy);
        Task<int> DeleteDepositsAsync(long depositId);
        

    }
}
