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
        Task<int> DeleteDepositsAsync(long DepositId);
        Task<int> DepositInActiveAsync(DepositDto DepositDto);


    }
}
