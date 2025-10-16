using System.Data;
using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models.Dtos;
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

        //GET
        public async Task<List<ExpenseCategories>> AllExpenseCategoriesAsync()  
        {
            const string sql = @"SELECT * FROM ExpenseCategories";

            _connection.Open();
            var expenseCategories = await _connection.QueryAsync<ExpenseCategories>(sql);
            _connection.Close();

            return expenseCategories.ToList();
        }

        // POST
        public async Task<long> AddExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto)
        {
            var sql = @"INSERT INTO ExpenseCategories (ExpenseCategoryName, Remarks, CreatedBy)
                        OUTPUT INSERTED.ExpenseCategoryId
                        VALUES (@ExpenseCategoryName, @Remarks, @CreatedBy)";

            _connection.Open();
            var result = await _connection.QuerySingleAsync<long>(sql, new
            {
                @ExpenseCategoryName = categoryDto.ExpenseCategoryName,
                @Remarks = categoryDto.Remarks,
                @CreatedBy = categoryDto.@CreatedBy
            });
            _connection.Close();

            return result; 
        }

        //PUT 
        public async Task<int> UpdateExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto)
        {
            var sql = @"UPDATE ExpenseCategories SET 
                        ExpenseCategoryName = @ExpenseCategoryName,
                        Remarks = @Remarks,
                        ModifiedBy = @ModifiedBy,
                        ModifiedAt = GETDATE()
                        WHERE ExpenseCategoryId = @ExpenseCategoryId";

            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @ExpenseCategoryId = categoryDto.ExpenseCategoryId,
                @ExpenseCategoryName = categoryDto.ExpenseCategoryName,
                @Remarks = categoryDto.Remarks,
                @ModifiedBy = categoryDto.CreatedBy

            });
            _connection.Close();

            return result; 
        }

        //DELETE
        public async Task<int> DeleteExpenseCategoriesAsync(long expenseCategoryId)
        {
            var sql = @"DELETE FROM ExpenseCategories WHERE ExpenseCategoryId = @ExpenseCategoryId";

            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new{expenseCategoryId});
            _connection.Close();

            return result; 
        }
    }
}
