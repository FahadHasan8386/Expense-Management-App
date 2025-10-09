using System.Data;
using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Repository
{
    public class DepositsRepository : IDepositsRepository
    {
        private readonly IDbConnection _connection;

        public DepositsRepository (IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Deposits>> GetAllDepositsAsync()
        {
            var sql = @"SELECT * From Deposits";
            _connection.Open();
            var deposits = await _connection.QueryAsync<Deposits>(sql);
            _connection.Close();
            var responsse = deposits.ToList();
            return responsse;
        }
    }
}
