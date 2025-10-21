using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models.DtoModels.DepositDto;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IDepositsRepository
    {
        Task<List<Deposits>> GetAllDepositsAsync();
        Task<List<Deposits>> GetDepositsByIdAsync(long depositId);
        Task<long> AddDepositsAsync(DepositDto deposit);
        Task<int> UpdateDepositsAsync(DepositDto DepositDto);
        Task<int> DeleteDepositsAsync(long DepositId);

    }
}
