using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models;
using ExpenseManagement.Api.Models.Dtos.DepositDto;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IDepositsService
    {
        Task<List<Deposits>> GetAllDepositsAsync();
        Task<List<Deposits>> GetDepositsByIdAsync(long depositId);
        Task<ResponseModel> AddDepositsAsync(DepositDto depositDto);
        Task<ResponseModel> UpdateDepositsAsync(DepositDto DepositDto);
        Task<ResponseModel> DeleteDepositsAsync(long DepositId);
        
    }
}
