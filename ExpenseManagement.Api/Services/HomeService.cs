using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Api.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _HomeRepository;

        public HomeService(IHomeRepository depositsRepository)
        {
            _HomeRepository = depositsRepository;
        }

        // GET
        public async Task<HomeViewModel> GetResultSerachByUserAsync(QueryDto queryDto)
        {
            return await _HomeRepository.ExecuteResultSerachByUserAsync(queryDto);
        }
    }
}
