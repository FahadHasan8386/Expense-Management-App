﻿using System.Data.Common;
using System.Transactions;
using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models;
using ExpenseManagement.Api.Models.Dtos.DepositDto;
using ExpenseManagement.Api.Models.Entities;

namespace ExpenseManagement.Api.Services
{
    public class DepositsService : IDepositsService
    { 
        private readonly IDepositsRepository _depositsRepository;

        public DepositsService(IDepositsRepository depositsRepository)
        {
            _depositsRepository = depositsRepository;
        }
          
        // GET
        public async Task<List<Deposits>> GetAllDepositsAsync()
        {
            return await _depositsRepository.GetAllDepositsAsync();
        }

        //Get By Id
        public async Task<List<Deposits>> GetDepositsByIdAsync(long depositId)
        { 
            return await _depositsRepository.GetDepositsByIdAsync(depositId);
        }

        // POST
        public async Task<ResponseModel> AddDepositsAsync(DepositDto depositDto)
        {
            try
            {
                if (depositDto.DepositAmount <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Bad request."
                    };
                }

                if (depositDto.DepositDate is null)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Bad request."
                    };
                }

                long result;

                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _depositsRepository.AddDepositsAsync(depositDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "The record has been saved."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Deposit posting unsuccessful."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 500,
                    Message = ex.Message.ToString()
                };
            }
        }


        //Put
        public async Task<ResponseModel> UpdateDepositsAsync(UpdateDepositDto updateDepositDto)
        {
            try
            {
                if (updateDepositDto.DepositId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Invalid deposit ID."
                    };
                }

              
                if (updateDepositDto.DepositAmount <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Invalid deposit amount."
                    };
                }

                int result;

                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _depositsRepository.UpdateDepositsAsync(updateDepositDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Deposit record updated successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Deposit not found or no changes made."
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


        //Delete
        public async Task<ResponseModel> DeleteDepositsAsync(long DepositId)
        {
            try
            {
                if (DepositId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Invalid deposit ID."
                    };
                }

                int result ;

                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _depositsRepository.DeleteDepositsAsync(DepositId);
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
                        Message = "Deposit not found."
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 500,
                    Message = ex.Message.ToString()
                };
            }
        }
    }
}
