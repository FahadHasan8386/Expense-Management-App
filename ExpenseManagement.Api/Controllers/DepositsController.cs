using ExpenseManagement.Api.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class DepositsController : ControllerBase
    {
        public readonly IDepositsService _DepositsService;

        public DepositsController(IDepositsService depositService)
        {
            _DepositsService = depositService;
        }

        [HttpGet("GetAllDeposits")]
        public async Task<IActionResult> GetAllDepositsAsync()
        {
            return Ok(await _DepositsService.GetAllDepositsAsync());
        }

        //[HttpPost("NewDeposits")]
        //public async Task<IActionResult> NewDepositsAsync([FromBody] )
        //{
        //    return Ok(await _DepositsService.NewDepositsAsync());
        //}
    }
}