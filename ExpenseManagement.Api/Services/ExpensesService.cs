using System.Transactions;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models;
using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Api.Repository;

namespace ExpenseManagement.Api.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpensesRepository _expensesRepository;

        public ExpensesService(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        // All
        public async Task<List<Expenses>> AllExpensesAsync()
        {
            return await _expensesRepository.AllExpensesAsync();
        }

        //GetBy ID
        public async Task<List<Expenses>> ExpensesByIdAsync(long expenseId)
        {
            return await _expensesRepository.ExpensesByIdAsync(expenseId);
        }


        // Add
        public async Task<ResponseModel> AddExpensesAsync(ExpensesDto expensesDto)
        {
            try
            {
                if (expensesDto.ExpenseAmount <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Expense Amount is Required."
                    };
                }

                if (expensesDto.ExpenseDate == default)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Expense Date is required."
                    };
                }

                if (string.IsNullOrWhiteSpace(expensesDto.PaymentMethod))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Payment Method is Required."
                    };
                }

                long result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _expensesRepository.AddExpensesAsync(expensesDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "Expense created successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Failed to create expense."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 500,
                    Message = ex.Message
                };
            }
        }

        // Update
        public async Task<ResponseModel> UpdateExpensesAsync(ExpensesDto expensesDto)
        {
            try
            {
                if (expensesDto.ExpenseId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Invalid Expense Id."
                    };
                }

                if (expensesDto.ExpenseCategoryId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Expense Category Id is Required."
                    };
                }

                if (expensesDto.ExpenseAmount <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Expense Amount is Required."
                    };
                }

                if (expensesDto.ExpenseDate == default)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Expense Date is required."
                    };
                }

                if (string.IsNullOrWhiteSpace(expensesDto.PaymentMethod))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Payment Method is Required."
                    };
                }

                int result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _expensesRepository.UpdateExpensesAsync(expensesDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Expense updated successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Failed to update expense."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 500,
                    Message = ex.Message
                };
            }
        }

        // Delete
        public async Task<ResponseModel> DeleteExpensesAsync(long expenseId)
        {
            try
            {
                if (expenseId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Invalid Expense Id."
                    };
                }

                int result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _expensesRepository.DeleteExpensesAsync(expenseId);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Expense deleted successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Expense not found or already deleted."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 500,
                    Message = ex.Message
                };
            }
        }

        
    }
}
