using Dapper;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Shared.Enums;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Shared.Models.ViewModel;
using System.Data;

namespace ExpenseManagement.Api.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDbConnection _connection;

        public ReportRepository(IDbConnection connection)
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
            };
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
            string sql = @"SELECT	e.ExpenseId,
		                            e.Remarks,
		                            e.ExpenseDate,
		                            e.PaymentMethod,
		                            e.ExpenseAmount,
		                            ec.ExpenseCategoryId,
		                            ec.ExpenseCategoryName
                            FROM
                            Expenses AS e
                            INNER JOIN ExpenseCategories AS ec
	                            ON e.ExpenseCategoryId = ec.ExpenseCategoryId";

            object sqlParam = new
            {
                @FromDate = fromDate,
                @ToDate = toDate,
                @CategoryId = expenseCategoryId,
                @PaymentMethod = paymentype.ToString()
            };
            if (!fromAmount.Equals(0) && toAmount.Equals(0))
            {
                sql = @"IF @CategoryId > 0
							BEGIN
								IF @PaymentMethod = 'NONE'
								BEGIN
									SELECT	e.ExpenseId,
											e.Remarks,
											e.ExpenseDate,
											e.PaymentMethod,
											e.ExpenseAmount,
											ec.ExpenseCategoryId,
											ec.ExpenseCategoryName
									FROM
									Expenses AS e
									INNER JOIN ExpenseCategories AS ec
										ON e.ExpenseCategoryId = ec.ExpenseCategoryId
									 WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
									 AND CAST(e.ExpenseDate AS DATE) <= @ToDate
									 AND e.ExpenseAmount >= @FromAmount
									 AND ec.ExpenseCategoryId = @CategoryId
								END
								ELSE
									SELECT	e.ExpenseId,
											e.Remarks,
											e.ExpenseDate,
											e.PaymentMethod,
											e.ExpenseAmount,
											ec.ExpenseCategoryId,
											ec.ExpenseCategoryName
									FROM
									Expenses AS e
									INNER JOIN ExpenseCategories AS ec
										ON e.ExpenseCategoryId = ec.ExpenseCategoryId
									 WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
									 AND CAST(e.ExpenseDate AS DATE) <= @ToDate
									 AND e.ExpenseAmount >= @FromAmount
									 AND ec.ExpenseCategoryId = @CategoryId
									 AND e.PaymentMethod = @PaymentMethod
		                    END
                    ELSE
	                    BEGIN
		                    IF @PaymentMethod = 'NONE'
		                    BEGIN
			                    SELECT	e.ExpenseId,
					                    e.Remarks,
					                    e.ExpenseDate,
					                    e.PaymentMethod,
					                    e.ExpenseAmount,
					                    ec.ExpenseCategoryId,
					                    ec.ExpenseCategoryName
			                    FROM
			                    Expenses AS e
			                    INNER JOIN ExpenseCategories AS ec
				                    ON e.ExpenseCategoryId = ec.ExpenseCategoryId
			                     WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
			                     AND CAST(e.ExpenseDate AS DATE) <= @ToDate
			                     AND e.ExpenseAmount >= @FromAmount
		                    END
		                    ELSE
			                    SELECT	e.ExpenseId,
					                    e.Remarks,
					                    e.ExpenseDate,
					                    e.PaymentMethod,
					                    e.ExpenseAmount,
					                    ec.ExpenseCategoryId,
					                    ec.ExpenseCategoryName
			                    FROM
			                    Expenses AS e
			                    INNER JOIN ExpenseCategories AS ec
				                    ON e.ExpenseCategoryId = ec.ExpenseCategoryId
			                     WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
			                     AND CAST(e.ExpenseDate AS DATE) <= @ToDate
			                     AND e.ExpenseAmount >= @FromAmount
			                     AND e.PaymentMethod = @PaymentMethod
	                    END";
                sqlParam = new
                {
                    @FromAmount = fromAmount,
                    @FromDate = fromDate,
                    @ToDate = toDate,
                    @CategoryId = expenseCategoryId,
                    @PaymentMethod = paymentype.ToString()
                };
            }
            if (!toAmount.Equals(0))
            {
                sql = @"IF @CategoryId > 0
							BEGIN
								IF @PaymentMethod = 'NONE'
								BEGIN
									SELECT	e.ExpenseId,
											e.Remarks,
											e.ExpenseDate,
											e.PaymentMethod,
											e.ExpenseAmount,
											ec.ExpenseCategoryId,
											ec.ExpenseCategoryName
									FROM
									Expenses AS e
									INNER JOIN ExpenseCategories AS ec
										ON e.ExpenseCategoryId = ec.ExpenseCategoryId
									 WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
									 AND CAST(e.ExpenseDate AS DATE) <= @ToDate
									 AND e.ExpenseAmount >= @FromAmount
									 AND e.ExpenseAmount <= @ToAmount
									 AND ec.ExpenseCategoryId = @CategoryId
								END
								ELSE
									SELECT	e.ExpenseId,
											e.Remarks,
											e.ExpenseDate,
											e.PaymentMethod,
											e.ExpenseAmount,
											ec.ExpenseCategoryId,
											ec.ExpenseCategoryName
									FROM
									Expenses AS e
									INNER JOIN ExpenseCategories AS ec
										ON e.ExpenseCategoryId = ec.ExpenseCategoryId
									 WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
									 AND CAST(e.ExpenseDate AS DATE) <= @ToDate
									 AND e.ExpenseAmount >= @FromAmount
									 AND e.ExpenseAmount <= @ToAmount
									 AND ec.ExpenseCategoryId = @CategoryId
									 AND e.PaymentMethod = @PaymentMethod
		                    END
                    ELSE
	                    BEGIN
		                    IF @PaymentMethod = 'NONE'
		                    BEGIN
			                    SELECT	e.ExpenseId,
					                    e.Remarks,
					                    e.ExpenseDate,
					                    e.PaymentMethod,
					                    e.ExpenseAmount,
					                    ec.ExpenseCategoryId,
					                    ec.ExpenseCategoryName
			                    FROM
			                    Expenses AS e
			                    INNER JOIN ExpenseCategories AS ec
				                    ON e.ExpenseCategoryId = ec.ExpenseCategoryId
			                     WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
			                     AND CAST(e.ExpenseDate AS DATE) <= @ToDate
			                     AND e.ExpenseAmount >= @FromAmount
								 AND e.ExpenseAmount <= @ToAmount
			                     AND e.PaymentMethod = @PaymentMethod
		                    END
		                    ELSE
			                    SELECT	e.ExpenseId,
					                    e.Remarks,
					                    e.ExpenseDate,
					                    e.PaymentMethod,
					                    e.ExpenseAmount,
					                    ec.ExpenseCategoryId,
					                    ec.ExpenseCategoryName
			                    FROM
			                    Expenses AS e
			                    INNER JOIN ExpenseCategories AS ec
				                    ON e.ExpenseCategoryId = ec.ExpenseCategoryId
			                     WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
			                     AND CAST(e.ExpenseDate AS DATE) <= @ToDate
			                     AND e.ExpenseAmount >= @FromAmount
								 AND e.ExpenseAmount <= @ToAmount
			                     AND e.PaymentMethod = @PaymentMethod
	                    END";

                sqlParam = new
                {
                    @FromAmount = fromAmount,
                    @ToAmount = toAmount,
                    @FromDate = fromDate,
                    @ToDate = toDate,
                    @CategoryId = expenseCategoryId,
                    @PaymentMethod = paymentype.ToString()
                };
            }
            if (fromAmount.Equals(0) && toAmount.Equals(0))
            {
                sql = @"IF @CategoryId > 0
							BEGIN
								IF @PaymentMethod = 'NONE'
								BEGIN
									SELECT	e.ExpenseId,
											e.Remarks,
											e.ExpenseDate,
											e.PaymentMethod,
											e.ExpenseAmount,
											ec.ExpenseCategoryId,
											ec.ExpenseCategoryName
									FROM
									Expenses AS e
									INNER JOIN ExpenseCategories AS ec
										ON e.ExpenseCategoryId = ec.ExpenseCategoryId
									 WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
									 AND CAST(e.ExpenseDate AS DATE) <= @ToDate
									 AND ec.ExpenseCategoryId = @CategoryId
								END
								ELSE
									SELECT	e.ExpenseId,
											e.Remarks,
											e.ExpenseDate,
											e.PaymentMethod,
											e.ExpenseAmount,
											ec.ExpenseCategoryId,
											ec.ExpenseCategoryName
									FROM
									Expenses AS e
									INNER JOIN ExpenseCategories AS ec
										ON e.ExpenseCategoryId = ec.ExpenseCategoryId
									 WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
									 AND CAST(e.ExpenseDate AS DATE) <= @ToDate
									 AND ec.ExpenseCategoryId = @CategoryId
									 AND e.PaymentMethod = @PaymentMethod
		                    END
                    ELSE
	                    BEGIN
		                    IF @PaymentMethod = 'NONE'
		                    BEGIN
			                    SELECT	e.ExpenseId,
					                    e.Remarks,
					                    e.ExpenseDate,
					                    e.PaymentMethod,
					                    e.ExpenseAmount,
					                    ec.ExpenseCategoryId,
					                    ec.ExpenseCategoryName
			                    FROM
			                    Expenses AS e
			                    INNER JOIN ExpenseCategories AS ec
				                    ON e.ExpenseCategoryId = ec.ExpenseCategoryId
			                     WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
			                     AND CAST(e.ExpenseDate AS DATE) <= @ToDate
			                    AND e.PaymentMethod = @PaymentMethod
		                    END
		                    ELSE
			                    SELECT	e.ExpenseId,
					                    e.Remarks,
					                    e.ExpenseDate,
					                    e.PaymentMethod,
					                    e.ExpenseAmount,
					                    ec.ExpenseCategoryId,
					                    ec.ExpenseCategoryName
			                    FROM
			                    Expenses AS e
			                    INNER JOIN ExpenseCategories AS ec
				                    ON e.ExpenseCategoryId = ec.ExpenseCategoryId
			                     WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
			                     AND CAST(e.ExpenseDate AS DATE) <= @ToDate
			                     AND e.PaymentMethod = @PaymentMethod
	                    END";

                sqlParam = new
                {
                    @FromDate = fromDate,
                    @ToDate = toDate,
                    @CategoryId = expenseCategoryId,
                    @PaymentMethod = paymentype.ToString()
                };
            }
            if (!toAmount.Equals(0) && expenseCategoryId.Equals(0) && paymentype.Equals(EnumPaymentType.NONE))
            {
                sql = @"SELECT	e.ExpenseId,
					                    e.Remarks,
					                    e.ExpenseDate,
					                    e.PaymentMethod,
					                    e.ExpenseAmount,
					                    ec.ExpenseCategoryId,
					                    ec.ExpenseCategoryName
			                    FROM
			                    Expenses AS e
			                    INNER JOIN ExpenseCategories AS ec
				                    ON e.ExpenseCategoryId = ec.ExpenseCategoryId
			                    WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
			                    AND CAST(e.ExpenseDate AS DATE) <= @ToDate
								AND e.ExpenseAmount >= @FromAmount
								AND e.ExpenseAmount <= @ToAmount";

                sqlParam = new
                {
                    @FromDate = fromDate,
                    @ToDate = toDate,
                    @FromAmount = fromAmount,
                    @ToAmount = toAmount
                };
            }
            if (fromAmount.Equals(0) && toAmount.Equals(0) && expenseCategoryId.Equals(0) && paymentype.Equals(EnumPaymentType.NONE))
            {
                sql = @"SELECT	e.ExpenseId,
					                    e.Remarks,
					                    e.ExpenseDate,
					                    e.PaymentMethod,
					                    e.ExpenseAmount,
					                    ec.ExpenseCategoryId,
					                    ec.ExpenseCategoryName
			                    FROM
			                    Expenses AS e
			                    INNER JOIN ExpenseCategories AS ec
				                    ON e.ExpenseCategoryId = ec.ExpenseCategoryId
			                    WHERE CAST(e.ExpenseDate AS DATE) >= @FromDate
			                    AND CAST(e.ExpenseDate AS DATE) <= @ToDate";

                sqlParam = new
                {
                    @FromDate = fromDate,
                    @ToDate = toDate
                };
            }

            _connection.Open();
            var expennses = await _connection.QueryAsync(sql: sql,
                map: (ExpensesViewModel e, ExpenseCategoriesViewModel ec) =>
                {
                    e.ExpenseCategories = ec;
                    return e;
                },
                 param: sqlParam,
                splitOn: "ExpenseCategoryId");
            _connection.Close();
            return expennses.ToList();
        }
    }
}
