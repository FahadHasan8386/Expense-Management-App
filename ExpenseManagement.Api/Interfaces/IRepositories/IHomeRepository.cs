using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IHomeRepository
    {
        Task<HomeViewModel> ExecuteResultSerachByUserAsync(QueryDto queryDto);
    }
}
