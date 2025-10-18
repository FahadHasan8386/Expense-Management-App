using System.Data;
using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Repository
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly IDbConnection _connection;

        public ExpensesRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        // Get all Expenses
        public async Task<List<Expenses>> AllExpensesAsync()
        {
            const string sql = @"SELECT * FROM Expenses";
            _connection.Open();
            var expenses = await _connection.QueryAsync<Expenses>(sql);
            _connection.Close();

            return expenses.ToList();
        }

        // Get Expenses By Id
        public async Task<List<Expenses>> ExpensesByIdAsync(long expenseId)
        {
            const string sql = @"SELECT * FROM Expenses WHERE ExpenseId = @ExpenseId";

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            // Pass the expenseId parameter to Dapper
            var expenses = await _connection.QueryAsync<Expenses>(sql, new { ExpenseId = expenseId });

            _connection.Close();
            return expenses.ToList();
        }


        //Add
        public async Task<long> AddExpensesAsync(ExpensesDto expensesDto)
        {
            var sql = @"INSERT INTO Expenses 
                        (ExpenseCategoryId, ExpenseAmount, ExpenseDate, PaymentMethod, Remarks, CreatedBy)
                        OUTPUT INSERTED.ExpenseId
                        VALUES (@ExpenseCategoryId, @ExpenseAmount, @ExpenseDate, @PaymentMethod, @Remarks, @CreatedBy)";

            _connection.Open();
            var result = await _connection.QuerySingleAsync<long>(sql, new
            {
                @ExpenseCategoryId = expensesDto.ExpenseCategoryId,
                @ExpenseAmount = expensesDto.ExpenseAmount,
                @ExpenseDate = expensesDto.ExpenseDate,
                @PaymentMethod = expensesDto.PaymentMethod,
                @Remarks = expensesDto.Remarks,
                @CreatedBy = expensesDto.CreatedBy
            });
            _connection.Close();

            return result;
        }

        //Update
        public async Task<int> UpdateExpensesAsync(ExpensesDto expensesDto)
        {
            var sql = @"UPDATE Expenses SET
                        ExpenseCategoryId = @ExpenseCategoryId,
                        ExpenseAmount = @ExpenseAmount,
                        ExpenseDate = @ExpenseDate,
                        PaymentMethod = @PaymentMethod,
                        Remarks = @Remarks,
                        ModifiedBy = @ModifiedBy,
                        ModifiedAt = GETDATE()
                        WHERE ExpenseId = @ExpenseId";

            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @ExpenseCategoryId = expensesDto.ExpenseCategoryId,
                @ExpenseAmount = expensesDto.ExpenseAmount,
                @ExpenseDate = expensesDto.ExpenseDate,
                @PaymentMethod = expensesDto.PaymentMethod,
                @Remarks = expensesDto.Remarks,
                @ModifiedBy = expensesDto.ModifiedBy,
                @ExpenseId = expensesDto.ExpenseId
            });
            _connection.Close();

            return result;
        }

        //Delete
        public async Task<int> DeleteExpensesAsync(long expenseId)
        {
            var sql = @"DELETE FROM Expenses WHERE ExpenseId = @ExpenseId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new { ExpenseId = expenseId });
            _connection.Close();

            return result;
        }
    }
}
