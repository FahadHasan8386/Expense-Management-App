using ExpenseManagement.Api.Interfaces.IServices;
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
    }
}