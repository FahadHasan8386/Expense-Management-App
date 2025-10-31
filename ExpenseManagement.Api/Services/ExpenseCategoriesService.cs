using System.Transactions;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Api.Models.Entities;
using ExpenseManagement.Api.Repository;
using ExpenseManagement.Shared.Models;

namespace ExpenseManagement.Api.Services
{
    public class ExpenseCategoriesService : IExpenseCategoriesService
    {
        private readonly IExpenseCategoriesRepository _expenseCategoriesRepository;

        public ExpenseCategoriesService(IExpenseCategoriesRepository expenseCategoriesRepository)
        {
            _expenseCategoriesRepository = expenseCategoriesRepository;
        }

        // Get all  
        public async Task<List<ExpenseCategories>> AllExpenseCategoriesAsync()
        {
            return await _expenseCategoriesRepository.AllExpenseCategoriesAsync();
        }

        // Get By Id  
        public async Task<ExpenseCategories> GetExpenseCategoriesByIdAsync(long expenseCategoryId)
        {
            return await _expenseCategoriesRepository.GetExpenseCategoriesByIdAsync(expenseCategoryId);
        }

        // Add new
        public async Task<ResponseModel> AddExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoryDto.ExpenseCategoryName))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Category Name is required."
                    };
                }

                if (string.IsNullOrWhiteSpace(categoryDto.Remarks))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Remarks is required."
                    };
                }

                long result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _expenseCategoriesRepository.AddExpenseCategoriesAsync(categoryDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "Expense category created successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Failed to create expense category."
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
        public async Task<ResponseModel> UpdateExpenseCategoriesAsync(ExpenseCategoriesDto categoryDto)
        {
            try
            {
                if (categoryDto.ExpenseCategoryId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Invalid Expense Category Id."
                    };
                }

                if (string.IsNullOrWhiteSpace(categoryDto.ExpenseCategoryName))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Category Name is Required."
                    };
                }

                if (string.IsNullOrWhiteSpace(categoryDto.Remarks))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Remarks is Required."
                    };
                }

                int result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _expenseCategoriesRepository.UpdateExpenseCategoriesAsync(categoryDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Expense category updated successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Category not found or no changes made."
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
        public async Task<ResponseModel> DeleteExpenseCategoriesAsync(long expenseCategoryId)
        {
            try
            {
                if (expenseCategoryId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Invaild Id."
                    };
                }
                int result;

                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _expenseCategoriesRepository.DeleteExpenseCategoriesAsync(expenseCategoryId);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Delete Sucessfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Expense Category not found."
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
