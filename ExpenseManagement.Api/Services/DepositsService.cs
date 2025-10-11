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

        // GET all
        public async Task<List<Deposits>> GetAllDepositsAsync()
        {
            return await _depositsRepository.GetAllDepositsAsync();
        }

        // POST
        public async Task<Deposits> AddDepositsAsync(Deposits deposit)
        {
            return await _depositsRepository.AddDepositsAsync(deposit);
        }

        // PUT
        public async Task<Deposits> UpdateDepositsAsync(Deposits deposit)
        {
            var result = await _depositsRepository.UpdateDepositsAsync(deposit);
            if (result > 0)
                return deposit;
            else
                throw new Exception("Update failed");
        }

        // DELETE
        public async Task<Deposits> DeleteDepositsAsync(Deposits deposit)
        {
            var result = await _depositsRepository.DeleteDepositsAsync(deposit.DepositId);
            if (result > 0)
                return deposit;
            else
                throw new Exception("Delete failed");
        }
    }
}
