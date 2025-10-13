using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Models.Dtos;
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


        [HttpPost("AddDeposits")]
        public async Task<IActionResult> AddDepositsAsync([FromBody] DepositDto depositDto)
        {
            if (depositDto == null)
                return BadRequest();

            return Ok(await _DepositsService.AddDepositsAsync(depositDto));
        }


        [HttpPut("UpdateDeposits/{id}")]
        public async Task<IActionResult> UpdateDepositsAsync(long id ,[FromBody] DepositDto depositDto)
        {
            if(depositDto == null)
                return BadRequest();

            return Ok(await _DepositsService.UpdateDepositsAsync(depositDto));
        }


        [HttpDelete("DeleteDeposits/{DepositId}")]
        public async Task<IActionResult> DeleteDepositsAsync(long DepositId)
        {
            if(DepositId == 0)
                return BadRequest();

            return Ok(await _DepositsService.DeleteDepositsAsync(DepositId));
        }
    }
}