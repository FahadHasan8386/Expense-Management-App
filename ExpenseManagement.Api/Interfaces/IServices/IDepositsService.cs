using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IDepositsService
    {
        Task<List<Deposits>> GetAllDepositsAsync();
        Task<Deposits> AddDepositsAsync(Deposits deposit);
        Task<int> UpdateDepositsAsync(Deposits deposit);
        Task<int> DeleteDepositsAsync(long DepositId);

    }
}
