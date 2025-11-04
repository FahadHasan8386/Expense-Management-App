using System.Data;
using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;

namespace ExpenseManagement.Api.Repository
{
    public class DepositsRepository : IDepositsRepository
    {
        private readonly IDbConnection _connection;

        public DepositsRepository(IDbConnection connection)
        {
            _connection = connection; 
        }

         
        public async Task<List<Deposits>> GetAllDepositsAsync()
        {
            var sql = @"SELECT * FROM Deposits";
            _connection.Open();
            var deposits = await _connection.QueryAsync<Deposits>(sql);
            _connection.Close();
            return deposits.ToList();
        }

        public async Task<Deposits?> GetDepositsByIdAsync(long depositId)
        {
            const string sql = @"SELECT TOP(1) * FROM Deposits WHERE DepositId = @DepositId";
            _connection.Open();
            var deposits = await _connection.QueryAsync<Deposits>(sql, new { @DepositId = depositId });
            _connection.Close();
            return deposits.FirstOrDefault();
        }

        public async Task<long> AddDepositsAsync(DepositDto depositDto)
        {
            var sql = @"INSERT INTO Deposits (DepositAmount, DepositDate, Remarks, CreatedBy)
                        OUTPUT INSERTED.DepositId
                        VALUES (@DepositAmount, @DepositDate, @Remarks, @CreatedBy)";

            _connection.Open();
            var result = await _connection.ExecuteScalarAsync<long>(sql, new
            {
                @DepositAmount = depositDto.DepositAmount,
                @DepositDate = depositDto.DepositDate,
                @Remarks = depositDto.Remarks,
                @CreatedBy = depositDto.CreatedBy
            });
            _connection.Close();

            return result;
        }

        public async Task<int> UpdateDepositsAsync(DepositDto DepositDto)
        {
            var sql = @"UPDATE Deposits SET DepositAmount = @DepositAmount,
                         Remarks = @Remarks,
                         ModifiedBy = @ModifiedBy,
                         ModifiedAt = GETDATE()
                        WHERE DepositId = @DepositId";

            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @DepositId = DepositDto.DepositId,
                @DepositAmount = DepositDto.DepositAmount,
                @Remarks = DepositDto.Remarks,
                @ModifiedBy = DepositDto.CreatedBy
            });
            _connection.Close();

            return result;
        }

        public async Task<int> UpdateDepositStatusAsync(long depositId, bool status, string changedBy)
        {
            var sql = @"UPDATE Deposits
                        SET InActive = @Status,
                             ModifiedBy = @ModifiedBy,
                            ModifiedAt = GETDATE()
                        WHERE DepositId = @DepositId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @DepositId = depositId,
                @Status = status,
                @ModifiedBy = changedBy
            });
            _connection.Close();
            return result;
        }
        
        public async Task<int> DeleteDepositsAsync(long depositId)
        {
            var sql = @"DELETE FROM Deposits WHERE DepositId = @DepositId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new {
                @DepositId = depositId
            });
            _connection.Close();
            return result;
        }

        

    }
}
