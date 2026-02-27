using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Services;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ReportController : ControllerBase
    {
        public readonly IReportService _homeService;

        public ReportController(IReportService homeService)
        {
            _homeService = homeService;
        }


        [HttpPost("SerachByUser")]
        public async Task<IActionResult> SerachByUserAsync([FromBody] QueryDto queryDto)
        {
            return Ok(await _homeService.GetResultSerachByUserAsync(queryDto));
        }

    }
}
    
    

