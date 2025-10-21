using ExpenseManagement.Api.Models;
using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models.DtoModels;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IDepositsService
    {
        Task<List<Deposits>> GetAllDepositsAsync();
        Task<Deposits?> GetDepositsByIdAsync(long depositId);
        Task<ResponseModel> AddDepositsAsync(DepositDto depositDto);
        Task<ResponseModel> UpdateDepositsAsync(DepositDto DepositDto);
        Task<ResponseModel> DeleteDepositsAsync(long DepositId);

    }
}
