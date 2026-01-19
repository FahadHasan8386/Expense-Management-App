using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.DtoModels;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IHomeService
    {
        Task<List<Deposits>> GetResultSerachByUserAsync(QueryDto queryDto);
    }
}
