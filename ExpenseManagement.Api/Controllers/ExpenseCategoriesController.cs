using DocumentFormat.OpenXml.Office2010.Excel;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.Shared.Models.DtoModels;

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

        [HttpGet("GetExpenseCategoriesById/{expenseCategoryId}")]
        public async Task<IActionResult> GetExpenseCategoriesByIdAsync(long expenseCategoryId)
        {
            return Ok(await _ExpenseCategoriesService.GetExpenseCategoriesByIdAsync(expenseCategoryId));
        }



        [HttpPost("AddExpenseCategories")]
        public async Task<IActionResult> AddExpenseCategoriesAsync([FromBody] ExpenseCategoriesDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();

            return Ok(await _ExpenseCategoriesService.AddExpenseCategoriesAsync(categoryDto));
        }


        [HttpPut("UpdateExpenseCategories")]
        public async Task<IActionResult> UpdateExpenseCategoriesAsync([FromBody] ExpenseCategoriesDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();

            return Ok(await _ExpenseCategoriesService.UpdateExpenseCategoriesAsync(categoryDto));
        }

        [HttpPatch("UpdateExpenseCategoryStatus")]
        public async Task<IActionResult> UpdateExpenseCategoryStatusAsync([FromBody] ExpenseCategoriesDto categoryDto)
        {
            if (categoryDto.ExpenseCategoryId <= 0)
                return BadRequest();

            return Ok(await _ExpenseCategoriesService.ExpenseCategoryInActiveAsync(categoryDto.ExpenseCategoryId, categoryDto.CreatedBy));
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