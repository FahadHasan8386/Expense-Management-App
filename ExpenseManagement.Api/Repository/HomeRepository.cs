using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Shared.Enums;
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


        public async Task<HomeViewModel> ExecuteResultSerachByUserAsync(QueryDto queryDto)
        {
            var viewModel = new HomeViewModel();

            if (queryDto.QueryTypes.Equals(EnumQueryTypes.DepositReport))
                viewModel.DepositViewModels = await ExecuteDeposistSearch(queryDto.FromAmount, queryDto.ToAmount, queryDto.FromDate, queryDto.ToDate);

            if (queryDto.QueryTypes.Equals(EnumQueryTypes.ExpenseReport))
                viewModel.ExpensesViewModels = await ExecuteExpenseSearch(queryDto.FromAmount, queryDto.ToAmount, queryDto.FromDate, queryDto.ToDate, queryDto.PaymentType);

            return viewModel;
        }

        private async Task<List<DepositViewModel>> ExecuteDeposistSearch(decimal fromAmount, decimal toAmount, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"SELECT DepositAmount, DepositDate, Remarks, CreatedBy, ModifiedBy, CreatedAt, ModifiedAt FROM Deposits
                                WHERE CAST(DepositDate AS DATE) >=  CAST(@FromDate AS DATE) and CAST(DepositDate AS DATE) <= CAST(@ToDate AS DATE)";
            _connection.Open();
            var deposits = await _connection.QueryAsync<DepositViewModel>(sql, new
            {
                @FromAmount = fromAmount,
                @ToAmount = toAmount,
                @FromDate = fromDate,
                @ToDate = toDate
            });
            _connection.Close();
            return deposits.ToList();
        }

        private async Task<List<ExpensesViewModel>> ExecuteExpenseSearch(decimal fromAmount, decimal toAmount, DateTime fromDate, DateTime toDate, EnumPaymentType paymentType)
        {
            const string sql = @"SELECT * FROM Expenses WHERE ExpenseId = @FromAmount ";
            _connection.Open();
            var expenses = await _connection.QueryAsync<ExpensesViewModel>(sql, new
            {
                @FromAmount = fromAmount,
                @ToAmount = toAmount,
                @FromDate = fromDate,
                @ToDate = toDate
            });
            _connection.Close();
            return expenses.ToList();
        }

    }
}
