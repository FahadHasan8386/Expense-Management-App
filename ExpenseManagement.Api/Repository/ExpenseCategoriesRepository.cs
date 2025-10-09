using System.Data;
using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Repository
{
    public class ExpenseCategoriesRepository : IExpenseCategoriesRepository
    {
        private readonly IDbConnection _connection;

        public ExpenseCategoriesRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<ExpenseCategories>> AllExpenseCategoriesAsync()
        {
            var sql = @"SELECT * From ExpenseCategories";
            _connection.Open();
            var expenseCategory = await _connection.QueryAsync <ExpenseCategories>(sql);
            _connection.Close();
            var response = expenseCategory.ToList();
            return response;
        }
    }
}
