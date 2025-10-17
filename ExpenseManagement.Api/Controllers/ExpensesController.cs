using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models.Dtos;
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

        // Add new expense
        [HttpPost("AddExpenses")]
        public async Task<IActionResult> AddExpensesAsync([FromBody] ExpensesDto expensesDto)
        {
            if (expensesDto == null)
                return BadRequest("Expense data cannot be null.");

            var result = await _expensesService.AddExpensesAsync(expensesDto);
            return Ok(result);
        }

        // Update expense
        [HttpPut("UpdateExpenses/{id}")]
        public async Task<IActionResult> UpdateExpensesAsync(long id, [FromBody] ExpensesDto expensesDto)
        {
            if (expensesDto == null)
                return BadRequest("Expense data cannot be null.");

          
            expensesDto.ExpenseId = id;

            var result = await _expensesService.UpdateExpensesAsync(expensesDto);
            return Ok(result);
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
