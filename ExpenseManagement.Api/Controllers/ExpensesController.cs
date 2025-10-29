using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Shared.Models.DtoModels;
using ExpenseManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        // Get all expenses
        [HttpGet("AllExpenses")]
        public async Task<IActionResult> AllExpensesAsync()
        {
            var result = await _expensesService.AllExpensesAsync();
            return Ok(result);
        }

        [HttpGet("ExpensesById/{expenseId}")]
        public async Task<IActionResult> ExpensesByIdAsync(long expenseId)
        {
            return Ok(await _expensesService.ExpensesByIdAsync(expenseId));
        }

        // Add new expense
        [HttpPost("AddExpenses")]
        public async Task<IActionResult> AddExpensesAsync([FromBody] ExpensesDto expensesDto)
        {
            if (expensesDto == null)
                return BadRequest();

            return Ok(await _expensesService.AddExpensesAsync(expensesDto));
        }

        // Update expense
        [HttpPut("UpdateExpenses")]
        public async Task<IActionResult> UpdateExpensesAsync([FromBody] ExpensesDto expensesDto)
        {
            if (expensesDto == null)
                return BadRequest();

            return Ok(await _expensesService.UpdateExpensesAsync(expensesDto));
        }

        // Delete expense
        [HttpDelete("DeleteExpenses/{expenseId}")]
        public async Task<IActionResult> DeleteExpensesAsync(long expenseId)
        {
            if (expenseId <= 0)
                return BadRequest("Invalid expense ID.");

            var result = await _expensesService.DeleteExpensesAsync(expenseId);
            return Ok(result);
        }
    }
}
