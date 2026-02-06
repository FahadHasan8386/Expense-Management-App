using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Services;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class HomeController : ControllerBase
    {
        public readonly IHomeService _HomeService;

        public HomeController(IHomeService homeService)
        {
            _HomeService = homeService;
        }


        [HttpPost("SerachByUser")]
        public async Task<IActionResult> SerachByUserAsync([FromBody] QueryDto queryDto)
        {
            return Ok(await _HomeService.GetResultSerachByUserAsync(queryDto));
        }


        [HttpPost("Search")]
        public async Task<IActionResult> SearchDepositAsync([FromBody] QueryDto queryDto)
        {
            {
                return Ok(await _HomeService.GetDepositResultSerachByUserAsync(queryDto));
            }
        }
    }
}
    
    

