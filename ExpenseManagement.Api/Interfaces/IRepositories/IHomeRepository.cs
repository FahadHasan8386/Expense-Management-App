using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models.DtoModels;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IHomeRepository
    {
        Task<List<Deposits>> ExecuteResultSerachByUserAsync(QueryDto queryDto);
    }
}
