using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Api.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _ReportRepository;

        public ReportService(IReportRepository depositsRepository)
        {
            _ReportRepository = depositsRepository;
        }

        // GET
        public async Task<ReportViewModel> GetResultSerachByUserAsync(QueryDto queryDto)
        {
            return await _ReportRepository.ExecuteResultSerachByUserAsync(queryDto);
        }

       
    }
}
