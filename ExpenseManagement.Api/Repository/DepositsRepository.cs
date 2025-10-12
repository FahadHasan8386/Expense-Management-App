using System.Data;
using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models.Dtos;
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

        public async Task<long> AddDepositsAsync(DepositDto deposit)
        {
            var sql = @"INSERT INTO Deposits (DepositAmount, DepositDate, Remarks)
                        OUTPUT INSERTED.DepositId
                        VALUES (@DepositAmount, @DepositDate, @Remarks)";

            _connection.Open();
            var result = await _connection.ExecuteScalarAsync<long>(sql, new
            {
                deposit.DepositAmount,
                deposit.DepositDate,
                deposit.Remarks
            });
            _connection.Close();

            return result;
        }

        public async Task<int> UpdateDepositsAsync(DepositDto deposit)
        {
            var sql = @"
                UPDATE Deposits
                SET DepositAmount = @DepositAmount,
                    DepositDate = @DepositDate,
                    Remarks = @Remarks
                WHERE DepositId = @DepositId";

            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                deposit.DepositAmount,
                deposit.DepositDate,
                deposit.Remarks,
                deposit.DepositId
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
