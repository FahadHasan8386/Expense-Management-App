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


        public async Task<ReportViewModel> ExecuteResultSerachByUserAsync(QueryDto queryDto)
        {
            var viewModel = new ReportViewModel();

            if (queryDto.QueryTypes.Equals(EnumQueryTypes.DepositReport))
                viewModel.DepositViewModels = await ExecuteDeposistSearch(queryDto.FromAmount, queryDto.ToAmount, queryDto.FromDate, queryDto.ToDate);

            else if (queryDto.QueryTypes.Equals(EnumQueryTypes.ExpenseReport))
                viewModel.ExpensesViewModels = await ExecuteExpenseSearch(queryDto.FromAmount, queryDto.ToAmount, queryDto.FromDate, queryDto.ToDate, queryDto.PaymentType, queryDto.ExpenseCategoryId);

            return viewModel;
        }

        private async Task<List<DepositViewModel>> ExecuteDeposistSearch(decimal fromAmount, decimal toAmount, DateTime fromDate, DateTime toDate)
        {
            string sql = @"SELECT DepositId, DepositAmount, DepositDate, Remarks,CreatedBy,ModifiedBy,CreatedAt, ModifiedAt FROM Deposits";
            object sqlParam = new
            {
                @FromDate = fromDate,
                @ToDate = toDate
            }; ;

            if (!fromAmount.Equals(0) && toAmount.Equals(0))
            {
                sql = @"SELECT DepositId, DepositAmount, DepositDate, Remarks,CreatedBy,ModifiedBy,CreatedAt, ModifiedAt 
                        FROM Deposits
                        WHERE DepositAmount >= @FromAmount
                        AND CAST(DepositDate AS DATE) >= CAST(@FromDate AS DATE)
                        AND CAST(DepositDate AS DATE) <= CAST(@ToDate AS DATE)";

                sqlParam = new
                {
                    @FromAmount = fromAmount,
                    @FromDate = fromDate,
                    @ToDate = toDate
                };
            }

            if (!toAmount.Equals(0))
            {
                sql = @"SELECT DepositId, DepositAmount, DepositDate, Remarks,CreatedBy,ModifiedBy,CreatedAt, ModifiedAt
                        FROM Deposits
                        WHERE DepositAmount >= @FromAmount
                        AND DepositAmount <= @ToAmount
                        AND CAST(DepositDate AS DATE) >= CAST(@FromDate AS DATE)
                        AND CAST(DepositDate AS DATE) <= CAST(@ToDate AS DATE)";

                sqlParam = new
                {
                    @FromAmount = fromAmount,
                    @ToAmount = toAmount,
                    @FromDate = fromDate,
                    @ToDate = toDate
                };
            }

            if (fromAmount.Equals(0) && toAmount.Equals(0))
            {
                sql = @"SELECT DepositId, DepositAmount, DepositDate, Remarks,CreatedBy,ModifiedBy,CreatedAt, ModifiedAt
                        FROM Deposits
                        WHERE CAST(DepositDate AS DATE) >= CAST(@FromDate AS DATE)
                        AND CAST(DepositDate AS DATE) <= CAST(@ToDate AS DATE)";

                sqlParam = new
                {
                    @FromDate = fromDate,
                    @ToDate = toDate
                };
            }

            _connection.Open();
            var deposits = await _connection.QueryAsync<DepositViewModel>(sql: sql, param: sqlParam);
            _connection.Close();
            return deposits.ToList();
        }

        private async Task<List<ExpensesViewModel>> ExecuteExpenseSearch(decimal fromAmount, decimal toAmount, DateTime fromDate, DateTime toDate, EnumPaymentType paymentype, long expenseCategoryId)
        {
            string sql = @"SELECT e.ExpenseAmount, e.ExpenseDate, e.Remarks,c.ExpenseCategoryName AS ExpenseCategory,
                            e.PaymentMethod, e.CreatedBy, e.ModifiedBy, e.CreatedAt, e.ModifiedAt ";

            if (!fromAmount.Equals(0) && toAmount.Equals(0))
            {
                sql = @"SELECT e.ExpenseAmount, e.ExpenseDate, e.Remarks,c.ExpenseCategoryName AS ExpenseCategory,
                        e.PaymentMethod, e.CreatedBy, e.ModifiedBy, e.CreatedAt, e.ModifiedAt 
                        FROM Expenses e
                        INNER JOIN ExpenseCategories c ON e.ExpenseCategoryId = c.ExpenseCategoryId
                        WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
                          AND CAST(ExpenseDate AS DATE) <= @ToDate
                          AND e.ExpenseAmount >= @FromAmount
                          AND e.ExpenseCategoryId = @CategoryId
                          AND e.PaymentMethod = @PaymentMethod";

            }

            if (!toAmount.Equals(0))
            {
                sql = @"SELECT e.ExpenseAmount, e.ExpenseDate, e.Remarks,c.ExpenseCategoryName AS ExpenseCategory,
                         e.PaymentMethod, e.CreatedBy, e.ModifiedBy, e.CreatedAt, e.ModifiedAt 
                         FROM Expenses e
                         INNER JOIN ExpenseCategories c ON e.ExpenseCategoryId = c.ExpenseCategoryId
                         WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
                           AND CAST(e.ExpenseDate AS DATE) <= @ToDate
                           AND e.ExpenseAmount >= @FromAmount
                           AND e.ExpenseAmount <= @ToAmount
                           AND e.ExpenseCategoryId = @CategoryId
                           AND e.PaymentMethod = @PaymentMethod";
            }

            if (fromAmount.Equals(0) && toAmount.Equals(0))
            {
                sql = @"SELECT e.ExpenseAmount, e.ExpenseDate, e.Remarks,c.ExpenseCategoryName AS ExpenseCategory,
                         e.PaymentMethod, e.CreatedBy, e.ModifiedBy, e.CreatedAt, e.ModifiedAt 
                         FROM Expenses e
                         INNER JOIN ExpenseCategories c ON e.ExpenseCategoryId = c.ExpenseCategoryId
                         WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
                           AND CAST(e.ExpenseDate AS DATE) <= @ToDate
                           AND e.ExpenseCategoryId = @CategoryId
                           AND e.PaymentMethod = @PaymentMethod";
            }
            _connection.Open();
            var expenses = await _connection.QueryAsync(sql,
                map: (ExpensesViewModel e, ExpenseCategoriesViewModel ec) =>
                {
                    e.ExpenseCategories = ec;
                    return e;
                },
                splitOn: "ExpenseCategoryId",
                param: new
                {
                    @FromAmount = fromAmount,
                    @ToAmount = toAmount,
                    @FromDate = fromDate,
                    @ToDate = toDate,
                    @CategoryId = expenseCategoryId,
                    @PaymentMethod = paymentype.ToString()
                });
            _connection.Close();
            return expenses.ToList();
        }

        //private async Task<List<ExpensesViewModel>> ExecuteExpenseSearch(decimal fromAmount, decimal toAmount, DateTime fromDate, DateTime toDate, EnumPaymentType paymentType, long expenseCategoryId)
        //{ 
        //    const string sql = @"SELECT e.ExpenseAmount, e.ExpenseDate, e.Remarks,c.ExpenseCategoryName AS ExpenseCategory,
        //                    e.PaymentMethod, e.CreatedBy, e.ModifiedBy, e.CreatedAt, e.ModifiedAt 
        //             FROM Expenses e
        //             INNER JOIN ExpenseCategories c ON e.ExpenseCategoryId = c.ExpenseCategoryId
        //             WHERE e.ExpenseDate >= @FromDate
        //               AND e.ExpenseDate < DATEADD(DAY, 1, @ToDate)
        //               AND e.ExpenseAmount >= @FromAmount
        //               AND e.ExpenseAmount <= @ToAmount
        //               AND e.ExpenseCategoryId = @CategoryId
        //               AND e.PaymentMethod = @PaymentMethod";

        //    _connection.Open();
        //    var parameters = new
        //    {
        //        FromAmount = fromAmount,
        //        ToAmount = toAmount,
        //        FromDate = fromDate,
        //        ToDate = toDate,
        //        CategoryId = expenseCategoryId, 
        //        PaymentMethod = (int)paymentType
        //    };
        //    var expenses = await _connection.QueryAsync<ExpensesViewModel>(sql, parameters);
        //    _connection.Close();
        //    return expenses.ToList();
        //}

    }
}
