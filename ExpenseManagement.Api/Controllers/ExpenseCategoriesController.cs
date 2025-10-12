using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Api.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class ExpenseCategoriesController : ControllerBase
    {
        public readonly IExpenseCategoriesService _ExpenseCategoriesService;

        public ExpenseCategoriesController(IExpenseCategoriesService expenseCategoriesService)
        {
            _ExpenseCategoriesService = expenseCategoriesService;
        }

        [HttpGet("AllExpenseCategories")]
        public async Task<IActionResult> AllExpenseCategoriesAsync()
        {
            return Ok(await _ExpenseCategoriesService.AllExpenseCategoriesAsync());
        }

        [HttpPost("AddExpenseCategories")]
        public async Task<IActionResult> AddExpenseCategoriesAsync([FromBody] ExpenseCategoriesDto category)
        {
            return Ok(await _ExpenseCategoriesService.AddExpenseCategoriesAsync());
        }

        [HttpPut("UpdateExpenseCategories")]
        public async Task<IActionResult> UpdateExpenseCategoriesAsync([FromBody] ExpenseCategoriesDto category)
        {
            return Ok(await _ExpenseCategoriesService.UpdateExpenseCategoriesAsync());
        }

        [HttpDelete("DeleteExpenseCategories")]
        public async Task<IActionResult> DeleteExpenseCategoriesAsync([FromBody] long expenseCategoryId)
        {
            return Ok(await _ExpenseCategoriesService.DeleteExpenseCategoriesAsync());
        }
    }
}