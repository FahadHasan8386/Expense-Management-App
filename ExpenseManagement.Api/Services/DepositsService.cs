using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Services
{
    public class DepositsService : IDepositsService
    {
        private readonly IDepositsRepository _depositsRepository;

        public DepositsService(IDepositsRepository depositsRepository)
        {
            _depositsRepository = depositsRepository;
        }

        public async Task<List<Deposits>> GetAllDepositsAsync()
        {
            var response = await _depositsRepository.GetAllDepositsAsync();
            return response;
        }
    }
}
