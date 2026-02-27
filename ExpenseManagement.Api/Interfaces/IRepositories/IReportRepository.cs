using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Api.Interfaces.IRepositories
{
    public interface IReportRepository
    {
        Task<ReportViewModel> ExecuteResultSerachByUserAsync(QueryDto queryDto);
    }
}
