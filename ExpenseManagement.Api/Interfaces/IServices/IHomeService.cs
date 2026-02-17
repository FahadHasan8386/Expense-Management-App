using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Api.Interfaces.IServices
{
    public interface IHomeService
    {
        Task<ReportViewModel> GetResultSerachByUserAsync(QueryDto queryDto);
        
    }
}
