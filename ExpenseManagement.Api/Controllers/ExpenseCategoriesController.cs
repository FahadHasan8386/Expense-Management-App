using DocumentFormat.OpenXml.Office2010.Excel;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models.Dtos;
using ExpenseManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> AddExpenseCategoriesAsync([FromBody] ExpenseCategoriesDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();

            return Ok(await _ExpenseCategoriesService.AddExpenseCategoriesAsync(categoryDto));
        }


        [HttpPut("UpdateExpenseCategories/{id}")]
        public async Task<IActionResult> UpdateExpenseCategoriesAsync(long id ,[FromBody] ExpenseCategoriesDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();

            return Ok(await _ExpenseCategoriesService.UpdateExpenseCategoriesAsync(categoryDto));
        }


        [HttpDelete("DeleteExpenseCategories/{expenseCategoryId}")]
        public async Task<IActionResult> DeleteExpenseCategoriesAsync(long expenseCategoryId)
        {
            if (expenseCategoryId == 0)
                return BadRequest();

            return Ok(await _ExpenseCategoriesService.DeleteExpenseCategoriesAsync(expenseCategoryId));
        }
    }
}