using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;
using System.Data;

namespace ExpenseManagement.Api.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly IDbConnection _connection;

        public HomeRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task<QueryResultViewModel> ExecuteResultSerachByUserAsync(QueryDto queryDto)
        {
            var sql = @"SELECT * FROM Deposits";
            _connection.Open();
            var deposits = await _connection.QueryAsync<Deposits>(sql);
            _connection.Close();
            return deposits.ToList();
        }

        public async Task<Deposits?> ExecuteDeposistSearch(long FromAmount, long ToAmount, DateTime FromDate, DateTime ToDate)
        {
            const string sql = @"SELECT TOP(1) * FROM Deposits WHERE DepositId = @DepositId";
            _connection.Open();
            var deposits = await _connection.QueryAsync<Deposits>(sql, new { @DepositId = depositId });
            _connection.Close();
            return deposits.FirstOrDefault();
        }

    }
}
