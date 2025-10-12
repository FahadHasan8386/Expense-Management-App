using ExpenseManagement.Api.Models;
using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IDepositsService
    {
        Task<List<Deposits>> GetAllDepositsAsync();
        Task<ResponseModel> AddDepositsAsync(DepositDto depositDto);
        Task<ResponseModel> UpdateDepositsAsync(DepositDto depositDto);
        Task<ResponseModel> DeleteDepositsAsync(long DepositId);
        
    }
}
