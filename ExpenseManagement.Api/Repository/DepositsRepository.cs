using System.Data;
using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models.Dtos.DepositDto;
using ExpenseManagement.Api.Models.Entities;

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

        public async Task<List<Deposits>> GetDepositsByIdAsync(long depositId)
        {
            const string sql = @"SELECT * FROM Deposits WHERE DepositId = @DepositId";

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            var deposits = await _connection.QueryAsync<Deposits>(sql, new { DepositId = depositId });

            _connection.Close();
            return deposits.ToList();
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

        public async Task<int> UpdateDepositsAsync(UpdateDepositDto updateDepositDto)
        {
            var sql = @"UPDATE Deposits SET DepositAmount = @DepositAmount,
                         Remarks = @Remarks,
                         ModifiedBy = @ModifiedBy,
                         ModifiedAt = GETDATE()
                        WHERE DepositId = @DepositId";

            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @DepositId = updateDepositDto.DepositId,
                @DepositAmount = updateDepositDto.DepositAmount,
                @Remarks = updateDepositDto.Remarks,
                @ModifiedBy = updateDepositDto.CreatedBy
            });
            _connection.Close();

            return result;
        }


        public async Task<int> DeleteDepositsAsync(long DepositId)
        {
            var sql = @"DELETE FROM Deposits WHERE DepositId = @DepositId";

            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new { DepositId });
            _connection.Close();

            return result;
        }
    }
}
